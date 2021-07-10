using System.ComponentModel.DataAnnotations;

namespace SG_ASP_3.Models
{
    public class Medico
    {
        [Key]
        [Display(Name = "Médico")]
        public int IdMedico { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name ="Médico")]
        public string NomApe { get; set; }
    }
}