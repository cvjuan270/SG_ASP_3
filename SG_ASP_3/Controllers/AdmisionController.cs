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
    public class AdmisionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admision
        
        public ActionResult Create(int Id)
        {
            Atenciones atenciones = db.Atenciones.Find(Id);
            AdmisionViewModel viewModel = new AdmisionViewModel();

            ViewBag.DocIde = atenciones.DocIde;
            ViewBag.NomApe = atenciones.NomApe;
            ViewBag.Empres = atenciones.Empres;

            if (atenciones.Admisions.Count != 0)
            {
                viewModel.Admision = atenciones.Admisions.First();
            }
            else
            {
                viewModel.Admision.IdAtenciones = Id;
                viewModel.Admision.HorReg = atenciones.Hora;
            }

            if (atenciones.Interconsultas.Count != 0)
            {
                foreach (var item in atenciones.Interconsultas)
                {
                    viewModel.Interconsultas.Add(item);
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Admision")]
        public ActionResult Create(AdmisionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var atencion = db.Atenciones.Find(viewModel.Admision.IdAtenciones);
                Admision admision = viewModel.Admision;
                admision.UserName = HttpContext.User.Identity.Name;
                if (atencion.Admisions.Count == 0)
                {
                    db.Admisions.Add(admision);
                    db.SaveChanges();
                }
                else
                {
                    foreach (var item in atencion.Admisions)
                    {
                        item.EnvApt = admision.EnvApt;
                        item.EnvAsi = admision.EnvAsi;
                        item.FecEnvResEmp = admision.FecEnvResEmp;
                        item.FecEnvResMed = admision.FecEnvResMed;
                        item.HorIng = admision.HorIng;
                        item.HorReg = admision.HorReg;
                        item.HorSal = admision.HorSal;
                        item.Pendie = admision.Pendie;
                        item.UserName = admision.UserName;
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    
                }

                if (viewModel.Interconsultas.Count != 0)
                {
                    foreach (var item in viewModel.Interconsultas)
                    {
                        item.UserName = HttpContext.User.Identity.Name;
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }


                return RedirectToAction("Index", "Atenciones");
            }

            return View(viewModel);
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