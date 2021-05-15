using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SG_ASP_3.Models
{
    public class Auditoria
    {
        [Key]
        public int IdAudi { get; set; }
        public int IdAtenciones { get; set; }

        [Display(Name = "Examenes Incompletos")]
        public bool ExaCom { get; set; }

        [StringLength(20)]
        public string ExaCom1 { get; set; }

        [Display(Name = "Datos incompletos")]
        public bool DatInc { get; set; }

        [StringLength(20)]
        public string DatInc1 { get; set; }

        [Display(Name = "Aptitud errada")]
        public bool AptErr { get; set; }

        [StringLength(20)]
        public string AptErr1 { get; set; }

        [Display(Name = "Falta firma del médico")]
        public bool FaFiMe { get; set; }

        [StringLength(20)]
        public string FaFiMe1 { get; set; }

        [Display(Name = "Falta firma del paciente")]
        public bool FaFiPa { get; set; }

        [StringLength(20)]
        public string FaFiPa1 { get; set; }

        [Display(Name = "Restricciones")]
        public bool Restri { get; set; }

        [StringLength(20)]
        public string Restri1 { get; set; }

        [Display(Name = "Controles")]
        public bool Contro { get; set; }

        [StringLength(20)]
        public string Contro1 { get; set; }

        [Display(Name = "Diagnóstico")]
        public bool Diagno { get; set; }

        [StringLength(20)]
        public string Diagno1 { get; set; }

        [Display(Name = "Error de llenado")]
        public bool ErrLle { get; set; }

        [StringLength(20)]
        public string ErrLle1 { get; set; }

        [StringLength(100)]
        [Display(Name = "Observaciones")]
        public string ObNoRe { get; set; }

        [Display(Name = "Emo sin observaciones")]
        public bool EmSnOb { get; set; }

        [StringLength(20)]
        public string EmSnOb1 { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Hora de auditoría")]
        public TimeSpan? HorAud { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de auditoría")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? FecAud { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }
        public int IdMedico { get; set; }

        [Display(Name = "Omisión de interconsulta")]
        public bool OmiInt { get; set; }

        [StringLength(20)]
        public string OmiInt1 { get; set; }

        public virtual ICollection<ExaMedico> ExaMedicos { get; set; }
        public virtual Atenciones Atenciones { get; set; }
        public virtual Medico Medico { get; set; }

        public Auditoria()
        {
            ExaMedicos = new HashSet<ExaMedico>();
        }
    }
}
