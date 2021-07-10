using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SG_ASP_3.Models
{
    public class DashBoardViewModel
    {
        /*procesados*/
        public int NumAte { get; set; }
        public int ProMed { get; set; }
        public int ProAud { get; set; }
        public int ProEnf { get; set; }
        public int proAdm { get; set; }
        /*interconsultas*/
        public int NumInt { get; set; }
        /*medicona*/
        public int  MedApt { get; set; }
        public int MeNoAp { get; set; }
        public int MeApRe { get; set; }
        public int MedEva { get; set; }
        public int MedObs { get; set; }
        public List<Aptitud> Aptitudes { get; set; }

        public DashBoardViewModel() 
        {
            Aptitudes = new List<Aptitud>();
        }
    }
}