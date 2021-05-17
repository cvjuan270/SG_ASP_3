using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SG_ASP_3.Models
{
    public class AdmisionViewModel
    {
        public virtual List<Atenciones> Atenciones { get; set; }
        public virtual Admision Admision { get; set; }
        public virtual List<Interconsulta> Interconsultas { get; set; }

        public AdmisionViewModel()
        {
            Admision = new Admision();
            Interconsultas = new List<Interconsulta>();
            Atenciones = new List<Atenciones>();
        }
    }
}