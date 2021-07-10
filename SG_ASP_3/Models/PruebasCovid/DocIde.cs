using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SG_ASP_3.Models.PruebasCovid
{
    public class DocIde
    {
        [Key]
        public int IdDocIde { get; set; }
        public int Tipo { get; set; }
        public string Descri { get; set; }

    }
}