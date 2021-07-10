using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SG_ASP_3.Models.PruebasCovid
{
    public class ResultSer
    {
        [Key]
        public int IdResSer { get; set; }
        public int IdAteCov { get; set; }
        public bool Igg { get; set; }
        public int Igm { get; set; }
        public int R { get; set; }

    }
}