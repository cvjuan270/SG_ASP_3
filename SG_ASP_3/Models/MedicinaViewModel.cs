using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SG_ASP_3.Models
{
    public class MedicinaViewModel
    {
        public Medicina oMedicina { get; set; }
        public List<Interconsulta> oInterconsulta { get; set; }

        public MedicinaViewModel() 
        {
            oMedicina = new Medicina();
        }
        public MedicinaViewModel(Medicina _Medicina, List<Interconsulta> _Interconsultas)
        {
            oMedicina = _Medicina;
            oInterconsulta = oInterconsulta;
        }
    }
}