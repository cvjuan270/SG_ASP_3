using System.ComponentModel.DataAnnotations;

namespace SG_ASP_3.Models.PruebasCovid
{
    public class TipoPrueba
    {
        [Key]
        public int IdTipPru { get; set; }
        public string Descri { get; set; }
        

    }
}