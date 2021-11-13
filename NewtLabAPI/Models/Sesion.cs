using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtlabAPI.Models
{
    public class Sesion
    {
        public int SesionId { get; set; }
        public string Grado { get; set; }
        public string SesionNombre { get; set; }
        public bool IsOn { get; set; }
    }
}
