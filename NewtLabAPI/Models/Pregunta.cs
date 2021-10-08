using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtlabAPI.Models
{
    public class Pregunta
    {
        public int PreguntaId { get; set; }
        public int Puntuacion { get; set; }
        public string Descripcion { get; set; }
        public int BancoPreguntaId { get; set; }
        public string TP { get; set; }
        public int TipoPreguntaId { get; set; }
        public TipoPregunta TipoPregunta { get; set; }
        public BancoPregunta BancoPregunta { get; set; }
        public IEnumerable<Respuesta> Respuestas { get; set; }
        public bool IsOn { get; set; }
    }
}
