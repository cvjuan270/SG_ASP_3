using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SG_ASP_3.Models
{
    public class Admision
    {
        [Key]
        public int IdAdmi { get; set; }

        public int IdAtenciones { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Hora de ingreso")]
        public TimeSpan? HorIng { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Hora de Registro")]
        public TimeSpan? HorReg { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Hora de salida")]
        public TimeSpan? HorSal { get; set; }

        [StringLength(200)]
        [Display(Name = "Pendientes")]
        public string Pendie { get; set; }

        [Display(Name = "Envio de asistencia")]
        public bool EnvAsi { get; set; }

        [Display(Name = "Envio de aptitud")]
        public bool EnvApt { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Fech. envio de resultados a medicina")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? FecEnvResMed { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Fech. envio de resultados a Empresa")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? FecEnvResEmp { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        public virtual Atenciones Atenciones { get; set; }
    }
}
