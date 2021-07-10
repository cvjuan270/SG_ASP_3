using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using SG_ASP_3.Models.PruebasCovid;

namespace SG_ASP_3.Controllers.PruebasCovid
{
    public class AtenciCovsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AtenciCovs
        public ActionResult Index()
        {
            var atenciCovs = db.AtenciCovs.Include(a => a.DocIde).Include(a => a.TipoPrueba);
            return View(atenciCovs.ToList());
        }

        // GET: AtenciCovs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtenciCov atenciCov = db.AtenciCovs.Find(id);
            if (atenciCov == null)
            {
                return HttpNotFound();
            }
            return View(atenciCov);
        }

        // GET: AtenciCovs/Create
        public ActionResult Create()
        {
            ViewBag.IdDocIde = new SelectList(db.DocIdes, "IdDocIde", "Descri");
            ViewBag.IdTipPru = new SelectList(db.TipoPruebas, "IdTipPru", "Descri");
            return View();
        }

        // POST: AtenciCovs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAteCov,FecTomMue,HorTomMue,IdDocIde,NumDocIde,NomApe,IdTipPru,IdRes")] AtenciCov atenciCov)
        {
            if (ModelState.IsValid)
            {
                db.AtenciCovs.Add(atenciCov);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDocIde = new SelectList(db.DocIdes, "IdDocIde", "Descri", atenciCov.IdDocIde);
            ViewBag.IdTipPru = new SelectList(db.TipoPruebas, "IdTipPru", "Descri", atenciCov.IdTipPru);
            return View(atenciCov);
        }

        // GET: AtenciCovs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtenciCov atenciCov = db.AtenciCovs.Find(id);
            if (atenciCov == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDocIde = new SelectList(db.DocIdes, "IdDocIde", "Descri", atenciCov.IdDocIde);
            ViewBag.IdTipPru = new SelectList(db.TipoPruebas, "IdTipPru", "Descri", atenciCov.IdTipPru);
            return View(atenciCov);
        }

        // POST: AtenciCovs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAteCov,FecTomMue,HorTomMue,IdDocIde,NumDocIde,NomApe,IdTipPru,IdRes")] AtenciCov atenciCov)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atenciCov).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDocIde = new SelectList(db.DocIdes, "IdDocIde", "Descri", atenciCov.IdDocIde);
            ViewBag.IdTipPru = new SelectList(db.TipoPruebas, "IdTipPru", "Descri", atenciCov.IdTipPru);
            return View(atenciCov);
        }

        // GET: AtenciCovs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtenciCov atenciCov = db.AtenciCovs.Find(id);
            if (atenciCov == null)
            {
                return HttpNotFound();
            }
            return View(atenciCov);
        }

        // POST: AtenciCovs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AtenciCov atenciCov = db.AtenciCovs.Find(id);
            db.AtenciCovs.Remove(atenciCov);
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
