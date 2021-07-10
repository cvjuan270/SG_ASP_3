using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SG_ASP_3.Models.PruebasCovid
{
    public class ResultCua
    {
        [Key]
        public int IdResCua { get; set; }
        public int IdAteCov { get; set; }
        public int Igg { get; set; }
        public int Igm { get; set; }
    }
}