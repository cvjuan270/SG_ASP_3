using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SG_ASP_3.Models
{
    public class ExaMedico
    {
        [Key]
        public int IdExMed { get; set; }
        public String Examen { get; set; }
        public virtual ICollection<Auditoria> Auditorias { get; set; }
    }
}