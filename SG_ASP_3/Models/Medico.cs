using System.ComponentModel.DataAnnotations;

namespace SG_ASP_3.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }

        [StringLength(50)]
        [Required]
        public string NomApe { get; set; }
    }
}