using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtlabAPI.Models
{
    public class PruebaRespuesta
    {
        public int PruebaRespuestaId { get; set; }
        public int PEId { get; set; }
        public PruebaExperimento PE { get; set; }
        public int PreguntaId { get; set; }
        public Pregunta Pregunta { get; set; }
        public int RespuestaId { get; set; }
        public Respuesta Respuesta { get; set; }
    }
}
