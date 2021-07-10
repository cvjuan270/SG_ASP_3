using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SG_ASP_3.Models.PruebasCovid
{
    public class ResultMol
    {
        [Key]
        public int IdResMol { get; set; }
        public int IdAteCov { get; set; }
        public bool Result { get; set; }
    }
}