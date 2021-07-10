using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SG_ASP_3.Models
{
    public class EnvioHCViewModel
    {
 
        public int IdAtenciones { get; set; }

        [StringLength(20)]
        public string Local0 { get; set; }

        [StringLength(20)]
        [Display(Name = "Tip. Examen")]
        public string TipExa { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FecAte { get; set; }

        [StringLength(100)]
        [Display(Name = "Nombres y Apellidos")]
        public string NomApe { get; set; }

        [StringLength(20)]
        [Display(Name = "Doc. de Identidad")]
        public string DocIde { get; set; }

        [StringLength(100)]
        [Display(Name = "Empresa")]
        public string Empres { get; set; }

        [StringLength(100)]
        [Display(Name = "Sub Contrata")]
        public string SubCon { get; set; }

        [StringLength(100)]
        [Display(Name = "Proyecto")]
        public string Proyec { get; set; }

        [StringLength(100)]
        public string Perfil { get; set; }

        [StringLength(100)]
        public string Area { get; set; }

        [StringLength(100)]
        [Display(Name = "Puesto de trabajo")]
        public string PueTra { get; set; }

        [StringLength(50)]
        [Display(Name = "Admision")]
        public string PeReAd { get; set; }

        [Display(Name = "Hora de ingreso")]
        public TimeSpan? Hora { get; set; }

        /*envHC*/
        public EnvioHC EnvioHC { get; set; }

        public string Aptitud { get; set; }

        public EnvioHCViewModel() 
        {
            EnvioHC = new EnvioHC();
        }


    }
}