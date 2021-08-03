using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using IdentitySample.Models;
using Newtonsoft.Json;
using SG_ASP_3.Models;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        private static readonly DateTime FecIni = DateTime.Now.Date;
        private static readonly DateTime FecFin = DateTime.Now.Date;
        [HttpGet]
        public ActionResult Index()
        {

            DashBoardViewModel dash = new DashBoardViewModel();

            return View(dash);
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Dashboard()
        {
            ViewBag.Mensaje = "Hola mundo";
            return View();
        }

        [HttpPost]
        public ActionResult GetEmos(dates rango)
        {

            Emos returnEmos = new Emos();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var aud = db.Auditorias.Where(c => c.FecAud >= rango.FecIni && c.FecAud <= rango.FecFin).ToList();

                returnEmos.EmoSO = aud.Where(c => c.EmSnOb == true).Count();
                returnEmos.EmoCO = aud.Where(c => c.EmSnOb != true).Count();

            }

            return Json(returnEmos, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAuditorias(dates rango)
        {
            Audito audito = new Audito();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var lst = db.Auditorias.Where(c => c.FecAud >= rango.FecIni && c.FecAud <= rango.FecFin).ToList();

                audito.AptErr = lst.Where(c => c.AptErr == true).Count();
                audito.FalRes = lst.Where(c => c.FaFiMe == true).Count();
                audito.ExaInc = lst.Where(c => c.ExaCom == true).Count();
                audito.ConInc = lst.Where(c => c.Contro == true).Count();
                audito.ErrDia = lst.Where(c => c.Diagno == true).Count();
                audito.DatInc = lst.Where(c => c.DatInc == true).Count();
                audito.ErrLle = lst.Where(c => c.ErrLle == true).Count();
                audito.FaFiMe = lst.Where(c => c.FaFiMe == true).Count();
                audito.FaFiPa = lst.Where(c => c.FaFiPa == true).Count();
            }

            return Json(audito, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEscVal(dates rango)
        {
            Audito audito = new Audito();
            EscVal escVal = new EscVal();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var lst = db.Auditorias.Where(c => c.FecAud >= rango.FecIni && c.FecAud <= rango.FecFin).ToList();
                audito.AptErr = lst.Where(c => c.AptErr == true).Count();
                audito.FalRes = lst.Where(c => c.FaFiMe == true).Count();
                audito.ExaInc = lst.Where(c => c.ExaCom == true).Count();
                audito.ConInc = lst.Where(c => c.Contro == true).Count();
                audito.ErrDia = lst.Where(c => c.Diagno == true).Count();
                audito.DatInc = lst.Where(c => c.DatInc == true).Count();
                audito.ErrLle = lst.Where(c => c.ErrLle == true).Count();
                audito.FaFiMe = lst.Where(c => c.FaFiMe == true).Count();
                audito.FaFiPa = lst.Where(c => c.FaFiPa == true).Count();

                escVal.MGr = audito.AptErr + audito.FalRes;
                escVal.Gra = audito.ExaInc + audito.ConInc + audito.ErrDia;
                escVal.Mod = audito.DatInc;
                escVal.Lev = audito.ErrLle + audito.FaFiMe + audito.FaFiPa;

            }

            return Json(escVal, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEmosPro(dates rango)
        {
            DashBoardViewModel dash = new DashBoardViewModel();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                IQueryable<Atenciones> atenciones = db.Atenciones;


                atenciones = atenciones.Where(c => c.FecAte >= rango.FecIni && c.FecAte<=rango.FecFin && c.TipExa != "OTROS" && c.TipExa != "EXAMENES ADICIONALES");

                var LisMed = (from at in atenciones
                                   join me in db.Medicinas on at.IdAtenciones equals me.IdAtenciones
                                   select new { at.IdAtenciones, at.FecAte, me.FecApt }).ToList();

                var LisAud = (from at in atenciones
                                   join au in db.Auditorias on at.IdAtenciones equals au.IdAtenciones
                                   select new { at.IdAtenciones, at.FecAte, au.FecAud }).ToList();

                var LisInt = (from at in atenciones
                                   join en in db.Interconsultas on at.IdAtenciones equals en.IdAtenciones
                                   orderby en.FeCoPa ascending
                                   select new { at.IdAtenciones, at.FecAte,en.FecEnv, en.FeCoPa }).ToList();
                var LisIntPro = (from at in atenciones
                                      join en in db.Interconsultas on at.IdAtenciones equals en.IdAtenciones
                                      where en.FeCoPa != null
                                      orderby en.FeCoPa ascending
                                      select new { at.IdAtenciones, at.FecAte, en.FeCoPa }).ToList();
                var LisAdm = (from at in atenciones
                                   join ad in db.Admisions on at.IdAtenciones equals ad.IdAtenciones
                                   select new { at.IdAtenciones, ad.IdAdmi }).ToList();


                var lisApt = (from at in atenciones
                              join line in db.Medicinas on at.IdAtenciones equals line.IdAtenciones
                              group line by line.IdApti into g
                              select new
                              {
                                  g.FirstOrDefault().IdApti,
                                  Suma = g.Count().ToString()
                              });

                var oLisApt = (from li in lisApt
                                    join ap in db.Aptituds on li.IdApti equals ap.IdApti
                                    select new { ap.Descri, li.Suma }).ToList();

      

                var lst =  atenciones.ToList();
            
                dash.NumAte = lst.Count;
                dash.NumInt = LisInt.Count;
                dash.ProMed = LisMed.Count;
                dash.ProAud = LisAud.Count;
                dash.ProEnf = LisIntPro.Count;
                dash.proAdm = LisAdm.Count;
                dash.ProHiCl = lst.Where(c => c.EnvioHCs.Count()>0).Count();
                dash.ProAdmInt = LisInt.Where(c => c.FecEnv != null).Count();


                foreach (var item in oLisApt)
                {
                    Aptitud aptitud = new Aptitud
                    {
                        Descri = item.Descri,
                        IdApti = int.Parse(item.Suma)
                    };
                    dash.Aptitudes.Add(aptitud);
                }

            }

            return Json(dash, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Test() 
        {
            return View();
        }
    }

    public class dates
    {
        public DateTime FecIni { get; set; }
        public DateTime FecFin { get; set; }
    }

    public class Emos
    {
        public int EmoSO { get; set; }
        public int EmoCO { get; set; }
    }

    public class Audito
    {
        public int AptErr { get; set; }
        public int FalRes { get; set; }
        public int ExaInc { get; set; }
        public int ConInc { get; set; }
        public int ErrDia { get; set; }
        public int DatInc { get; set; }
        public int ErrLle { get; set; }
        public int FaFiMe { get; set; }
        public int FaFiPa { get; set; }


    }

    public class EscVal
    {
        public int MGr { get; set; }
        public int Gra { get; set; }
        public int Mod { get; set; }
        public int Lev { get; set; }
    }


}
