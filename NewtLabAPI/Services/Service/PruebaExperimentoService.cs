using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewtlabAPI.Data;
using NewtlabAPI.Models;
using NewtlabAPI.Services.IServices;

namespace NewtlabAPI.Services.Service
{
    public class PruebaExperimentoService: IPruebaExperimentoService
    {

        private readonly NewtLabContext context;
        public PruebaExperimentoService(NewtLabContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            var getId = context.PruebaExperimentos.Find(id);
            context.Remove(getId);
            context.SaveChanges();

            return true;
        }

        public IEnumerable<PruebaExperimento> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PruebaExperimento> GetById(int id)
        {
            return await context.PruebaExperimentos.FindAsync(id);
        }

        public async Task Insert(PruebaExperimento pruebaExperimento)
        {
            context.PruebaExperimentos.Add(pruebaExperimento);
            await context.SaveChangesAsync();
        }

        public bool Update(PruebaExperimento pruebaExperimento)
        {
            context.PruebaExperimentos.Update(pruebaExperimento);
            context.Entry(pruebaExperimento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();

            return true;
        }
    }
}
