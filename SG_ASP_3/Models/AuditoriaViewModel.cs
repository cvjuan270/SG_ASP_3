using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SG_ASP_3.Models
{
    public class AuditoriaViewModel
    {
        public Auditoria auditoria { get; set; }
        public List<int> SelectExaMed { get; set; }
        public virtual List<ExaMedico> exaMedicos { get; set; }
        public AuditoriaViewModel()
        {
        }
        public AuditoriaViewModel(Auditoria _auditoria, List<ExaMedico> _exaMedicos)
        {
            auditoria = _auditoria;
            exaMedicos = _exaMedicos;
            SelectExaMed = new List<int>();
        }
    }
}