using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewtlabAPI.Data;
using NewtlabAPI.Models;
using NewtlabAPI.Services.IServices;

namespace NewtlabAPI.Services.Service
{
    public class PreguntaService : IPreguntaService
    {
        private readonly NewtLabContext context;
        public PreguntaService(NewtLabContext context)
        {
            this.context = context;
        }

        public IEnumerable<Pregunta> GetAll()
        {
            return context.Preguntas;
        }

        public async Task<Pregunta> GetById(int id)
        {
            return await context.Preguntas.FindAsync(id);
        }

        public async Task Insert(Pregunta pregunta)
        {
            context.Preguntas.Add(pregunta);
            await context.SaveChangesAsync();
        }

        public bool Update(Pregunta pregunta)
        {
            context.Preguntas.Update(pregunta);
            context.Entry(pregunta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var getId = context.Preguntas.Find(id);
            getId.IsOn = false;
            context.SaveChanges();

            return true;
        }

        public bool Enable(int id)
        {
            var getId = context.Preguntas.Find(id);
            getId.IsOn = true;
            context.SaveChanges();

            return true;
        }
    }
}
