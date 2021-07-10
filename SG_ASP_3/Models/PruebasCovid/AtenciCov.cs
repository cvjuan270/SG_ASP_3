using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SG_ASP_3.Models.PruebasCovid
{
    public class AtenciCov
    {
        [Key]
        public int IdAteCov { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha de toma de muestra")]
        public DateTime FecTomMue { get; set; }

        [Column(TypeName = "time")]
        [Display(Name = "Hora de toma de muestra")]
        public TimeSpan HorTomMue { get; set; }

        [Display(Name = "Tipo de documento de identidad")]
        public int IdDocIde { get; set; }
        [Display(Name = "Número de documento")]
        public string NumDocIde { get; set; }

        [Display(Name ="Nombres y apellidos")]
        public string NomApe { get; set; }

        [Display(Name = "Tipo de prueba")]
        public int IdTipPru  { get; set; }

        [Display(Name = "Resultado")]
        public int IdRes { get; set; }
        public virtual DocIde DocIde { get; set; }
        public virtual TipoPrueba TipoPrueba { get; set; }
        public virtual ResultSer ResultSer { get; set; }
        public virtual ResultAg ResultAg { get; set; }
        public virtual ResultCua ResultCua { get; set; }
        public  virtual ResultMol ResultMol { get; set; }
    }
}