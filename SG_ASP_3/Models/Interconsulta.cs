using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SG_ASP_3.Models
{
    public class Interconsulta
    {
        [Key]
        public int IdInter { get; set; }

        public int IdAtenciones { get; set; }

        [StringLength(50)]
        [Display(Name = "Interconsulta")]
        public string Descri { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? FecEnv { get; set; }

        [StringLength(50)]
        public string PeEnCo { get; set; }

        public bool EnHoIn { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? FeCoPa { get; set; }

        [StringLength(50)]
        public string PeCoPa { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? FeLeObs { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }
    }

}
