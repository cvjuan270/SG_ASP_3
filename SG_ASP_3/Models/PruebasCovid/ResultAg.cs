using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SG_ASP_3.Models.PruebasCovid
{
    public class ResultAg
    {
        [Key]
        public int IdResAg { get; set; }
        public int IdAteCov { get; set; }
        public bool Ag { get; set; }
        public int R { get; set; }
    }
}