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
    public class EspecialidadMedicasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EspecialidadMedicas
        public ActionResult Index()
        {
            return View(db.EspecialidadMedicas.ToList());
        }

        // GET: EspecialidadMedicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecialidadMedica especialidadMedica = db.EspecialidadMedicas.Find(id);
            if (especialidadMedica == null)
            {
                return HttpNotFound();
            }
            return View(especialidadMedica);
        }

        // GET: EspecialidadMedicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EspecialidadMedicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEspeMedic,Especialidad")] EspecialidadMedica especialidadMedica)
        {
            if (ModelState.IsValid)
            {
                db.EspecialidadMedicas.Add(especialidadMedica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidadMedica);
        }

        // GET: EspecialidadMedicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecialidadMedica especialidadMedica = db.EspecialidadMedicas.Find(id);
            if (especialidadMedica == null)
            {
                return HttpNotFound();
            }
            return View(especialidadMedica);
        }

        // POST: EspecialidadMedicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEspeMedic,Especialidad")] EspecialidadMedica especialidadMedica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidadMedica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidadMedica);
        }

        // GET: EspecialidadMedicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecialidadMedica especialidadMedica = db.EspecialidadMedicas.Find(id);
            if (especialidadMedica == null)
            {
                return HttpNotFound();
            }
            return View(especialidadMedica);
        }

        // POST: EspecialidadMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EspecialidadMedica especialidadMedica = db.EspecialidadMedicas.Find(id);
            db.EspecialidadMedicas.Remove(especialidadMedica);
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
