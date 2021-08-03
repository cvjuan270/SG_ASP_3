using IdentitySample.Models;
using SG_ASP_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SG_ASP_3.Controllers
{
    public class ReportesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private DateTime oFecIni = DateTime.Now.Date;
        private DateTime oFecFin = DateTime.Now.Date;

        private IQueryable<Atenciones> queryable(DateTime? FecIni, DateTime? FecFin, string NomApe, string Dni, string Empres, string SubCon, string TipExa, bool? TodExa) 
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
                atenciones = atenciones.Where(c => c.TipExa != "OTROS"&&c.TipExa!= "EXAMENES ADICIONALES");
            }

            return atenciones;
        }
        // GET: Reportes
        public ActionResult ReportMedicina(DateTime? FecIni, DateTime? FecFin, string NomApe, string Dni, string Empres, string SubCon, string TipExa, bool? TodExa)
        {
            var query = queryable(FecIni, FecFin, NomApe, Dni, Empres, SubCon, TipExa, TodExa).ToList();
           
            return View(query);
        }
        public ActionResult ReporteAuditoria(DateTime? FecIni, DateTime? FecFin, string NomApe, string Dni, string Empres, string SubCon, string TipExa, bool? TodExa)
        {
            var query = queryable(FecIni, FecFin, NomApe, Dni, Empres, SubCon, TipExa, TodExa);
            var lst = query.Where(c => c.Auditorias.Count >= 1).ToList();

            return View(lst);
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