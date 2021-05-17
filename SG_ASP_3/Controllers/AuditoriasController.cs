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
    public class AuditoriasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Auditorias
        public ActionResult Index()
        {
            var auditorias = db.Auditorias.Include(a => a.Atenciones).Include(a => a.Medico);
            return View(auditorias.ToList());
        }

        // GET: Auditorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atenciones atenciones = db.Atenciones.Find(id);
            if (atenciones.Auditorias == null)
            {
                return HttpNotFound();
            }
            return View(atenciones.Auditorias.First());
        }

        // GET: Auditorias/Create
        public ActionResult Create(int Id)
        {

            ViewBag.IdAtenciones = Id;
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "NomApe");
            var aten = db.Atenciones.Find(Id);
            var audi = new Auditoria();
            audi.IdAtenciones = aten.IdAtenciones;

            audi.HorAud = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
            audi.FecAud = DateTime.Parse(DateTime.Now.ToShortDateString());
            /**/

            var AllExam = from t in db.ExaMedicoes select t;
            AuditoriaViewModel viewModel = new AuditoriaViewModel(audi, AllExam.ToList());
            /**/
            ViewBag.AtenId = Id;
            ViewBag.DocIde = aten.DocIde;
            ViewBag.NomApe = aten.NomApe;
            ViewBag.Empres = aten.Empres;


            return View(viewModel);
        }

        // POST: Auditorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(AuditoriaViewModel auditoriaViewModel, int IdMedico)
        {
            Auditoria auditoria = auditoriaViewModel.auditoria;
            auditoria.IdMedico = IdMedico;
            if (ModelState.IsValid)
            {
                if (auditoriaViewModel.SelectExaMed != null)
                {
                    foreach (var item in auditoriaViewModel.SelectExaMed)
                    {
                        ExaMedico exaMedico = db.ExaMedicoes.Where(t => t.IdExMed == item).First();
                        auditoria.ExaMedicos.Add(exaMedico);
                    }
                }

                db.Auditorias.Add(auditoria);
                db.SaveChanges();
                return RedirectToAction("Index", "Atenciones");
            }

            return View(auditoria);
        }


        // GET: Auditorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditoria auditoria = db.Auditorias.Find(id);
            if (auditoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAtenciones = new SelectList(db.Atenciones, "IdAtenciones", "Local0", auditoria.IdAtenciones);
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "NomApe", auditoria.IdMedico);
            return View(auditoria);
        }

        // POST: Auditorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAudi,IdAtenciones,ExaCom,ExaCom1,DatInc,DatInc1,AptErr,AptErr1,FaFiMe,FaFiMe1,FaFiPa,FaFiPa1,Restri,Restri1,Contro,Contro1,Diagno,Diagno1,ErrLle,ErrLle1,ObNoRe,EmSnOb,EmSnOb1,HorAud,FecAud,UserName,IdMedico,OmiInt,OmiInt1")] Auditoria auditoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auditoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAtenciones = new SelectList(db.Atenciones, "IdAtenciones", "Local0", auditoria.IdAtenciones);
            ViewBag.IdMedico = new SelectList(db.Medicos, "IdMedico", "NomApe", auditoria.IdMedico);
            return View(auditoria);
        }

        // GET: Auditorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditoria auditoria = db.Auditorias.Find(id);
            if (auditoria == null)
            {
                return HttpNotFound();
            }
            return View(auditoria);
        }

        // POST: Auditorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auditoria auditoria = db.Auditorias.Find(id);
            db.Auditorias.Remove(auditoria);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Atenciones()
        {
            return RedirectToAction("Index", "Atenciones");
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
