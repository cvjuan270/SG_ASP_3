using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SG_ASP_3.Models
{
    public class EnfermeriaViewModel
    {
        public virtual List<Interconsulta> Interconsultas { get; set; }
        public EnfermeriaViewModel()
        {
            Interconsultas = new List<Interconsulta>();
        }
    }
}