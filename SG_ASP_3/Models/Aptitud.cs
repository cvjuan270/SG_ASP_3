using System.ComponentModel.DataAnnotations;

namespace SG_ASP_3.Models
{
    public class Aptitud
    {
        [Key]
        public int IdApti { get; set; }

        [StringLength(50)]
        [Required]
        public string Descri { get; set; }
    }
}