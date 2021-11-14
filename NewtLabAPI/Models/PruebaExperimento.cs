using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtlabAPI.Models
{
    public class PruebaExperimento
    {
        public int PruebaExperimentoId { get; set; }
        public string Titulo { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BancoPreguntaId { get; set; }
        public BancoPregunta BancoPregunta { get; set; }
        public DateTime FechaTomado { get; set; }
        public int CalificacionObtenida { get; set; }
        public int CalificacionObtenidaReal { get; set; }
        public int CalificacionTotal { get; set; }
        public bool IsCerrada { get; set; }
        public IEnumerable<PruebaRespuesta> PruebaRespuestas { get; set; }
        public string Periodo { get; set; }
    }
}
