using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using NewtlabAPI.Data;
using NewtlabAPI.Models;
using NewtlabAPI.Services.IServices;

namespace NewtlabAPI.Services.Service
{
    public class PruebaExperimentoService : IPruebaExperimentoService
    {

        private readonly NewtLabContext context;
        public PruebaExperimentoService(NewtLabContext context)
        {
            this.context = context;
        }

        public async Task<PruebaExperimento> GetById(int id)
        {
            return await context.PruebaExperimentos.FindAsync(id);
        }

        public async Task Insert(PruebaExperimento pruebaExperimento, IEnumerable<PruebaRespuesta> prs)
        {
            pruebaExperimento.Periodo = 
                DateTime.Now >= new DateTime(DateTime.Now.Year, 9, 1) 
                && DateTime.Now <= new DateTime(DateTime.Now.Year, 12, 20) ? "Septiembre-Diciembre" : "Enero-Abril";
            pruebaExperimento.FechaTomado = DateTime.Now;
            pruebaExperimento.PruebaRespuestas = prs;
            pruebaExperimento.Titulo = context.BancoPreguntas
                .Find(pruebaExperimento.BancoPreguntaId).TituloPublicado;
            pruebaExperimento.CalificacionObtenida = CalcCalificacion(prs);

            context.PruebaExperimentos.Add(pruebaExperimento);

            await context.SaveChangesAsync();
        }

        public IEnumerable<Respuesta> GetRespuestasInPrueba(IEnumerable<PruebaRespuesta> prs)
        {
            var respuestas = context.Respuestas.ToList();
            var correctas = prs.Join(respuestas,
                pr => pr.RespuestaId,
                r => r.RespuestaId,
                (pr, r) => r);

            return correctas;
        }

        public IEnumerable<Pregunta> GetPreguntasInPrueba(IEnumerable<PruebaRespuesta> prs)
        {
            var preguntas = context.Preguntas.ToList();

            var correctas = prs.Join(preguntas,
                pr => pr.PreguntaId,
                p => p.PreguntaId,
                (pr, p) => p);
            
            return correctas;
        }

        public IEnumerable<PruebaRespuesta> GetPruebaRespuestasByPruebaId(int id)
        {
            var prs = context.PruebaRespuesta.Where(p => p.PEId == id).ToList();
            for (int i = 0; i < prs.Count; i++)
            {
                prs[i].Pregunta = GetPreguntasInPrueba(prs).Where(l => prs[i].PreguntaId == l.PreguntaId).FirstOrDefault();
                prs[i].Respuesta = GetRespuestasInPrueba(prs).Where(l => prs[i].RespuestaId == l.RespuestaId).FirstOrDefault();
            }
            return prs;
        } 

        public IEnumerable<PruebaExperimento> GetAllPruebasByUser(int userId)
        {
            return context.PruebaExperimentos.Where(pe => pe.UserId == userId);
        }

        public IEnumerable<PruebaExperimento> GetAll()
        {
            return context.PruebaExperimentos;
        }

        public int CalcCalificacion(IEnumerable<PruebaRespuesta> prs)
        {
            int calif = 0;
            var rCorrec = GetRespuestasInPrueba(prs).ToList()
                .Where(rw => rw.EsCorrecta == true).ToList()
                .Join(GetPreguntasInPrueba(prs).ToList(),
                r => r.PreguntaId,
                p => p.PreguntaId,
                (r, p) => p).ToList();

            foreach (var i in rCorrec)
            {
                calif += i.Puntuacion;
            }
            return calif;
        }

        public bool Update(PruebaExperimento pruebaExperimento)
        {
            context.PruebaExperimentos.Update(pruebaExperimento);
            context.Entry(pruebaExperimento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();

            return true;
        }

        public int GetNotaAcumulada(int id, DateTime fechaInicio, DateTime fechaFin)
        {

            //int nota = 0;
            //foreach (var i in )
            //{

            //}
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
