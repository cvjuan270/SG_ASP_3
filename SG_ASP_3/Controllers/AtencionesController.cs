using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using SG_ASP_3.Models;

namespace SG_ASP_3.Controllers
{
    public class AtencionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Atenciones
        #region scaffolding
        public ActionResult Index()
        {
            var listAleMed = (from ate in db.Atenciones
                                 join med in db.Medicinas on ate.IdAtenciones equals med.IdAtenciones 
                                 select new { IdAtenciones = ate.IdAtenciones,FecAte = ate.FecAte, FecApt = med.FecApt }).ToList();

            var atenciones = db.Atenciones.ToList();

            foreach (var item in listAleMed)
            {
                TimeSpan ts = new TimeSpan();
                ts = DateTime.Parse(item.FecApt.ToString()) - DateTime.Parse(item.FecAte.ToString());
                atenciones.Find( m => m.IdAtenciones ==item.IdAtenciones).AleMed = ts.Days;
            }

            
            return View(atenciones);
        }

        // GET: Atenciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atenciones atenciones = db.Atenciones.Find(id);
            if (atenciones == null)
            {
                return HttpNotFound();
            }
            return View(atenciones);
        }

        // GET: Atenciones/Create
        public ActionResult Create()
        {
            List<string> estado = new List<string>();
            estado.Add("");
            ViewBag.Estado = estado;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file)
        {
            if (file != null)
            {
                try
                {
                    List<string> estado = new List<string>();
                    estado.Add("Iniciando Importacion de datos");
                    int n = 0;
                    Stream st = file.InputStream;
                    var reader = new StreamReader(st, Encoding.UTF8);

                    while (reader.Peek() >= 0)
                    {
                        var ate = new Atenciones();
                        string[] LineaReg = reader.ReadLine().Split('\t');
                        ate.IdAtenciones = int.Parse(LineaReg[0].ToString());
                        ate.Local0 = LineaReg[1].ToString();
                        ate.TipExa = LineaReg[2].ToString();
                        ate.FecAte = DateTime.Parse(LineaReg[3].ToString());
                        ate.NomApe = LineaReg[4].ToString();
                        ate.DocIde = LineaReg[5].ToString();
                        ate.Empres = LineaReg[6].ToString();
                        ate.SubCon = LineaReg[7].ToString();
                        ate.Proyec = LineaReg[8].ToString();
                        ate.Perfil = LineaReg[9].ToString();
                        ate.Area = LineaReg[10].ToString();
                        ate.PueTra = LineaReg[11].ToString();
                        ate.PeReAd = LineaReg[12].ToString();
                        ate.Hora = TimeSpan.Parse(LineaReg[13].ToString());

                        if (!db.Atenciones.Any(c => c.IdAtenciones == ate.IdAtenciones))
                        {
                            db.Atenciones.Add(ate);
                            db.SaveChanges();

                            n++;
                            estado.Add("Registros incertados [ID]= " + ate.IdAtenciones);
                        }
                        else
                        {
                            n++;
                            estado.Add("-------------------Registro no insertado por que ID ya existe [ID]= " + ate.IdAtenciones);
                        }

                        ViewBag.Estado = estado;
                    }

                    ViewBag.Confirmacion = "Se Importaron " + n + "Registros";
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error de importacion: " + ex.Message;
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "No se seleccionó ningun archivo";
                return View();
            }
        }

        // GET: Atenciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atenciones atenciones = db.Atenciones.Find(id);
            if (atenciones == null)
            {
                return HttpNotFound();
            }
            return View(atenciones);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAtenciones,Local0,TipExa,FecAte,NomApe,DocIde,Empres,SubCon,Proyec,Perfil,Area,PueTra,PeReAd,Hora")] Atenciones atenciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atenciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atenciones);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atenciones atenciones = db.Atenciones.Find(id);
            if (atenciones == null)
            {
                return HttpNotFound();
            }
            return View(atenciones);
        }

        // POST: Atenciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atenciones atenciones = db.Atenciones.Find(id);
            db.Atenciones.Remove(atenciones);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        public ActionResult Medicina(int Id)
        {
            var atencion = db.Atenciones.Find(Id);
            if (atencion.Medicina.Count != 0)
            {
                return RedirectToAction("Details", "Medicinas", new { Id = Id });
            }
            else
            {
                return RedirectToAction("Create", "Medicinas", new { Id = Id });
            }
        }

        public ActionResult Auditoria(int Id)
        {
            var atencion = db.Atenciones.Find(Id);
            if (atencion.Auditorias.Count != 0)
            {
                return RedirectToAction("Details", "Auditorias", new { Id = Id });
            }
            else
            {
                return RedirectToAction("Create", "Auditorias", new { Id = Id });
            }
        }

        public ActionResult Enfermeria(int Id)
        {
            return RedirectToAction("Create", "Enfermeria", new { Id = Id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
