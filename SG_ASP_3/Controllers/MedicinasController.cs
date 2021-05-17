using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using SG_ASP_3.Models;

namespace SG_ASP_3.Controllers
{
    public class MedicinasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Medicina
        public ActionResult Index()
        {
            var medicinas = db.Medicinas.Include(m => m.Atenciones).Include(m => m.Medico);
            var ass = medicinas.ToList();
            return View(medicinas.ToList());
        }

        // GET: Medicina/Details/5
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atenciones atenciones = db.Atenciones.Find(Id);
            if (atenciones.Medicina == null)
            {
                return HttpNotFound();
            }
            return View(atenciones.Medicina.First());
        }

        // GET: Medicina/Create
        public ActionResult Create(int Id)
        {
            MedicinaViewModel med = new MedicinaViewModel();
            var aten = db.Atenciones.Find(Id);
            ViewBag.IdAtenciones = Id;
            ViewBag.IdApti = new SelectList(db.Aptituds, "IdApti", "Descri");
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "NomApe");

            med.oMedicina.HorIng = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
            med.oMedicina.HorSal = TimeSpan.Parse(DateTime.Now.ToShortTimeString());

            ViewBag.DocIde = aten.DocIde;
            ViewBag.NomApe = aten.NomApe;
            ViewBag.Empres = aten.Empres;

            return View(med);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicinaViewModel viewModel, int IdAtenciones, int IdMedico, int IdApti)
        {
            if (ModelState.IsValid)
            {
                Medicina medicina = viewModel.oMedicina;
                medicina.HorSal = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                medicina.IdMedico = IdMedico;
                medicina.IdApti = IdApti;

                Atenciones atenciones = db.Atenciones.Find(IdAtenciones);
                atenciones.Medicina.Add(medicina);

                if (viewModel.oInterconsulta != null)
                {
                    foreach (var item in viewModel.oInterconsulta)
                    {
                        var interc = new Interconsulta();
                        interc.Descri = item.Descri;
                        interc.UserName = HttpContext.User.Identity.Name;
                        atenciones.Interconsultas.Add(interc);
                    }
                }

                db.Entry(atenciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Atenciones");
            }

            ViewBag.IdAtenciones = new SelectList(db.Atenciones, "IdAtenciones", "Local0", viewModel.oMedicina.IdAtenciones);
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "NomApe", viewModel.oMedicina.IdMedico);
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicina medicina = db.Medicinas.Find(id);
            if (medicina == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAtenciones = new SelectList(db.Atenciones, "IdAtenciones", "Local0", medicina.IdAtenciones);
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "NomApe", medicina.IdMedico);
            ViewBag.IdApti = new SelectList(db.Aptituds, "IdApti", "Descri", medicina.IdApti);
            return View(medicina);
        }

        // POST: Medicina/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMedicina,HorIng,HorSal,IdApti,FecApt,FecEnv,Coment,Observ,UserName,IdAtenciones,IdMedico")] Medicina medicina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAtenciones = new SelectList(db.Atenciones, "IdAtenciones", "Local0", medicina.IdAtenciones);
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "NomApe", medicina.IdMedico);
            return View(medicina);
        }

        // GET: Medicina/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicina medicina = db.Medicinas.Find(id);
            if (medicina == null)
            {
                return HttpNotFound();
            }
            return View(medicina);
        }

        // POST: Medicina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicina medicina = db.Medicinas.Find(id);
            db.Medicinas.Remove(medicina);
            db.SaveChanges();
            return RedirectToAction("Index");
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
