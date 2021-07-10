using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using IdentitySample.Models;
using SG_ASP_3.Models;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        private static DateTime FecIni = DateTime.Now.Date;
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            
            DashBoardViewModel dash = new DashBoardViewModel();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                IQueryable<Atenciones> atenciones = db.Atenciones;


                atenciones = atenciones.Where(c => c.FecAte == FecIni && c.TipExa != "OTROS");

                var LisMed = await (from at in atenciones
                                    join me in db.Medicinas on at.IdAtenciones equals me.IdAtenciones
                                    select new { IdAtenciones = at.IdAtenciones, FecAte = at.FecAte, FecApt = me.FecApt }).ToListAsync();

                var LisAud = await (from at in atenciones
                                    join au in db.Auditorias on at.IdAtenciones equals au.IdAtenciones
                                    select new { at.IdAtenciones, at.FecAte, au.FecAud }).ToListAsync();

                var LisInt = await (from at in atenciones
                                    join en in db.Interconsultas on at.IdAtenciones equals en.IdAtenciones
                                    orderby en.FeCoPa ascending
                                    select new { at.IdAtenciones, at.FecAte, en.FeCoPa }).ToListAsync();
                var LisIntPro = await (from at in atenciones
                                       join en in db.Interconsultas on at.IdAtenciones equals en.IdAtenciones
                                       where en.FeCoPa != null
                                       orderby en.FeCoPa ascending
                                       select new { at.IdAtenciones, at.FecAte, en.FeCoPa }).ToListAsync();
                var LisAdm = await (from at in atenciones
                                    join ad in db.Admisions on at.IdAtenciones equals ad.IdAtenciones
                                    select new { at.IdAtenciones, ad.IdAdmi }).ToListAsync();


                var lisApt = (from at in atenciones
                              join line in db.Medicinas on at.IdAtenciones equals line.IdAtenciones
                              group line by line.IdApti into g
                              select new
                              {
                                  g.FirstOrDefault().IdApti,
                                  Suma = g.Count().ToString()
                              });

                var oLisApt = await (from li in lisApt
                                     join ap in db.Aptituds on li.IdApti equals ap.IdApti
                                     select new { ap.Descri, li.Suma }).ToListAsync();



               var  lst = await atenciones.ToListAsync();

                dash.NumAte = lst.Count;
                dash.NumInt = LisInt.Count;
                dash.ProMed = LisMed.Count;
                dash.ProAud = LisAud.Count;
                dash.ProEnf = LisIntPro.Count;
                dash.proAdm = LisAdm.Count;

                foreach (var item in oLisApt)
                {
                    Aptitud aptitud = new Aptitud();

                    aptitud.Descri = item.Descri;
                    aptitud.IdApti = int.Parse(item.Suma);
                    dash.Aptitudes.Add(aptitud);
                }

            }


            return View( dash);
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
    }
}
