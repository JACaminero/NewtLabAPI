using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NewtlabAPI.Models
{
    public class Experimento
    {
        public int ExperimentoId { get; set; }
        public string Title { get; set; }
        public string Concepto { get; set; }
        public int Puntuacion { get; set; }
    }
}
