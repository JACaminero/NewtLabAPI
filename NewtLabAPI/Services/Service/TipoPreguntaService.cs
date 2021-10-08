using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewtlabAPI.Data;
using NewtlabAPI.Models;
using NewtlabAPI.Services.IServices;

namespace NewtlabAPI.Services.Service
{
    public class TipoPreguntaService : ITipoPreguntaService
    {

        private readonly NewtLabContext context;

        public TipoPreguntaService(NewtLabContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            var getId = context.TipoPreguntas.Find(id);
            context.Remove(getId);
            context.SaveChanges();

            return true;
        }

        public IEnumerable<TipoPregunta> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<TipoPregunta> GetById(int id)
        {
            return await context.TipoPreguntas.FindAsync(id);
        }

        public async Task Insert(TipoPregunta tipoPregunta)
        {
            await context.TipoPreguntas.AddAsync(tipoPregunta);
            await context.SaveChangesAsync();
        }

        public bool Update(TipoPregunta tipoPregunta)
        {
            context.TipoPreguntas.Update(tipoPregunta);
            context.Entry(tipoPregunta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();

            return true;
        }
    }
}
