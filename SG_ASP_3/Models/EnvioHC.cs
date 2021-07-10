using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SG_ASP_3.Models
{
    public class EnvioHC
    {
        [Key]
        public int IdEnvioHC { get; set; }
        public int IdAtenciones { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha de envio de HC")]
        public DateTime FecEnv { get; set; }

        [Display(Name ="Obsercaciones | Interconsultas")]
        public string Observ { get; set; }
        public string contro { get; set; }
        public string UserName { get; set; }

        public virtual  Atenciones Atenciones { get; set; }
    }
}