using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SG_ASP_3.Models
{
    public class Medicina
    {
        [Key]
        public int IdMedicina { get; set; }

        [Display(Name = "Hora Ingreso")]
        public TimeSpan? HorIng { get; set; }

        [Display(Name = "Hora Salida")]
        public TimeSpan? HorSal { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha de aptitud")]
        public DateTime? FecApt { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha de envío")]
        public DateTime? FecEnv { get; set; }

        [StringLength(100)]
        [Display(Name = "Comentarios")]
        public string Coment { get; set; }

        [StringLength(100)]
        [Display(Name = "Observaciones")]
        public string Observ { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }
        public int IdAtenciones { get; set; }

        [Display(Name ="Médico")]
        public int IdMedico { get; set; }

        [Display(Name = "Aptitud")]
        public int IdApti { get; set; }

        public virtual Atenciones Atenciones { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual Aptitud Aptitud { get; set; }
    }
}
