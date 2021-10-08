using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewtlabAPI.Data;
using NewtlabAPI.Models;
using NewtlabAPI.Services.IServices;

namespace NewtlabAPI.Services.Services
{
    public class RespuestaService : IRespuestaService
    {
        private readonly NewtLabContext context;
        public RespuestaService(NewtLabContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            var getId = context.Respuestas.Find(id);
            context.Remove(getId);
            context.SaveChanges();

            return true;
        }

        public IEnumerable<Respuesta> GetAll()
        {
            return context.Respuestas;
        }

        public async Task<Respuesta> GetById(int id)
        {
            return await context.Respuestas.FindAsync(id);
        }

        public async Task Insert(Respuesta respuesta)
        {
            await context.Respuestas.AddAsync(respuesta);
            await context.SaveChangesAsync();
            
        }

        public bool Update(Respuesta respuesta)
        {
            context.Respuestas.Update(respuesta);
            context.Entry(respuesta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return true;
        }
    }
}
