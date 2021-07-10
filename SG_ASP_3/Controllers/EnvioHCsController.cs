using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using SG_ASP_3.Models;

namespace SG_ASP_3.Controllers
{
    public class EnvioHCsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EnvioHCs
        private static DateTime oFecIni = DateTime.Now.Date;

        private async Task<IEnumerable<Atenciones>> _atenciones(DateTime? FecIni, DateTime? FecFin, string NomApe, string Dni, string Empres, string SubCon, string TipExa, bool? TodExa)
        {
            IQueryable<Atenciones> atenciones = db.Atenciones;

            if (String.IsNullOrEmpty(FecIni.ToString()) && String.IsNullOrEmpty(FecFin.ToString()))
            {
                atenciones = atenciones.Where(c => c.FecAte == oFecIni);
            }

            if (!String.IsNullOrEmpty(FecIni.ToString()) && !String.IsNullOrEmpty(FecFin.ToString()))
            {
                atenciones = atenciones.Where(c => c.FecAte >= FecIni && c.FecAte <= FecFin);
            }

            if (!String.IsNullOrEmpty(NomApe))
            {
                atenciones = atenciones.Where(c => c.NomApe.Contains(NomApe));
            }
            if (!String.IsNullOrEmpty(Dni))
            {
                atenciones = atenciones.Where(c => c.DocIde.Contains(Dni));
            }
            if (!String.IsNullOrEmpty(Empres))
            {
                atenciones = atenciones.Where(c => c.Empres.Contains(Empres));
            }
            if (!String.IsNullOrEmpty(TipExa))
            {
                atenciones = atenciones.Where(c => c.TipExa.Contains(TipExa));
            }

            if (!string.IsNullOrEmpty(SubCon))
            {
                atenciones = atenciones.Where(c => c.SubCon.Contains(SubCon));
            }

            if (TodExa == false || TodExa == null)
            {
                atenciones = atenciones.Where(c => c.TipExa != "OTROS");
            }

            var _atenciones = await atenciones.ToListAsync();

            IEnumerable<Atenciones> ate = _atenciones;

            return ate;
        }


        [HttpGet]
            public async Task<ActionResult> Index()
        {
            var ate = await _atenciones(null, null, null, null, null, null, null, null); 

            return View(ate);
        }

        public async Task<ActionResult> Index(DateTime? FecIni, DateTime? FecFin, string NomApe, string Dni, string Empres, string SubCon, string TipExa, bool? TodExa) 
        {
            var ate = await _atenciones(FecIni, FecFin, NomApe, Dni, Empres, SubCon, TipExa, TodExa);

            return View(ate);
        }



        // GET: EnvioHCs/Create
        [Authorize(Roles = "Admin,Enfermeria")]
        public ActionResult Create(int id)
        {
            EnvioHCViewModel vm = new EnvioHCViewModel();
            Atenciones ate = db.Atenciones.Find(id);

            vm.IdAtenciones = id;
            vm.NomApe = ate.NomApe;
            vm.DocIde = ate.DocIde;
            vm.Empres = ate.Empres;
            vm.SubCon = ate.SubCon;
            vm.Local0 = ate.Local0;
            vm.FecAte = ate.FecAte;
            vm.PueTra = ate.PueTra;
            if (ate.Medicina.Count>0)
            {
                vm.Aptitud = ate.Medicina.First().Aptitud.Descri;
            }
            if (ate.EnvioHCs.Count>0)
            {
                vm.EnvioHC.Observ = ate.EnvioHCs.First().Observ;
                vm.EnvioHC.contro = ate.EnvioHCs.First().contro;
                vm.EnvioHC.FecEnv = ate.EnvioHCs.First().FecEnv;
               
            }
            else
            {
                vm.EnvioHC.FecEnv = DateTime.Now.Date;
                var lst = new List<string>();
                string inter="";
                string obse = "";
                if (ate.Interconsultas.Count>0)
                {
                    foreach (var item in ate.Interconsultas)
                    {
                        lst.Add(item.Descri);
                    }
                inter   = string.Join("|", lst);
                   
                }

                if (ate.Medicina.Count!=0)
                {
                    obse = ate.Medicina.First().Observ;
                }

                vm.EnvioHC.Observ = "Observaciones: " + obse + ". Interconsultas: " + inter;

            }

            return View(vm);
        }

        // POST: EnvioHCs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Enfermeria")]
        public ActionResult Create(EnvioHCViewModel envioHCView)
        {
            if (ModelState.IsValid)
            {
                var atencion = db.Atenciones.Find(envioHCView.IdAtenciones);
                EnvioHC envioHC = envioHCView.EnvioHC;
                envioHC.UserName = HttpContext.User.Identity.Name;
                envioHC.IdAtenciones = envioHCView.IdAtenciones;
                if (atencion.EnvioHCs.Count == 0)
                {
                    db.EnvioHCs.Add(envioHC);
                    db.SaveChanges();
                }
                else
                {
                    foreach (var item in atencion.EnvioHCs)
                    {
                        item.FecEnv = envioHC.FecEnv;
                        item.Observ = envioHC.Observ;
                        item.contro = envioHC.contro;
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }


                return RedirectToAction("Index", "Atenciones");
            }

            return View(envioHCView);
        }

        // GET: EnvioHCs/Edit/5
       

        // GET: EnvioHCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnvioHC envioHC = db.EnvioHCs.Find(id);
            if (envioHC == null)
            {
                return HttpNotFound();
            }
            return View(envioHC);
        }

        // POST: EnvioHCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Enfermeria")]
        public ActionResult DeleteConfirmed(int id)
        {
            EnvioHC envioHC = db.EnvioHCs.Find(id);
            db.EnvioHCs.Remove(envioHC);
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
