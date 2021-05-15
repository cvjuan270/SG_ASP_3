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
    public class AptitudsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Aptituds
        public ActionResult Index()
        {
            return View(db.Aptituds.ToList());
        }

        // GET: Aptituds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aptitud aptitud = db.Aptituds.Find(id);
            if (aptitud == null)
            {
                return HttpNotFound();
            }
            return View(aptitud);
        }

        // GET: Aptituds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aptituds/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdApti,Descri")] Aptitud aptitud)
        {
            if (ModelState.IsValid)
            {
                db.Aptituds.Add(aptitud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aptitud);
        }

        // GET: Aptituds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aptitud aptitud = db.Aptituds.Find(id);
            if (aptitud == null)
            {
                return HttpNotFound();
            }
            return View(aptitud);
        }

        // POST: Aptituds/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdApti,Descri")] Aptitud aptitud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptitud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aptitud);
        }

        // GET: Aptituds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aptitud aptitud = db.Aptituds.Find(id);
            if (aptitud == null)
            {
                return HttpNotFound();
            }
            return View(aptitud);
        }

        // POST: Aptituds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aptitud aptitud = db.Aptituds.Find(id);
            db.Aptituds.Remove(aptitud);
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
