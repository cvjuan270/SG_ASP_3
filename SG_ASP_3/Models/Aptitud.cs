using System.ComponentModel.DataAnnotations;

namespace SG_ASP_3.Models
{
    public class Aptitud
    {
        [Key]
        [Display(Name = "Aptitud")]
        public int IdApti { get; set; }

        [StringLength(50)]
        [Required]

        [Display(Name ="Aptitud")]
        public string Descri { get; set; }
    }
}