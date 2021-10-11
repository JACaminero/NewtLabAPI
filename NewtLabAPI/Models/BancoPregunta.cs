using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtlabAPI.Models
{
    public class BancoPregunta
    {
        public int BancoPreguntaId { get; set; }
        public string Tema { get; set; }
        public string TituloPublicado { get; set; }
        public DateTime FechaCreacion{ get; set; }
        public int ExperimentoId { get; set; }
        public Experimento Experimento { get; set; }
        public bool Publicado { get; set; }
        public DateTime FechaLimite { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsOn { get; set; }
    }
}
