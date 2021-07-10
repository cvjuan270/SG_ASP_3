using System;
using System.ComponentModel.DataAnnotations;

namespace SG_ASP_3.Models
{
    public class EspecialidadMedica
    {
        [Key]
        public int IdEspeMedic { get; set; }
        public String Especialidad { get; set; }
    }
}