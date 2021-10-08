using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewtlabAPI.Data;
using NewtlabAPI.Models;
using NewtlabAPI.Services.IServices;

namespace NewtlabAPI.Services.Service
{
    public class ExperimentoService : IExperimentoService
    {
        private readonly NewtLabContext context;
        public ExperimentoService(NewtLabContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            var getId = context.Experimentos.Find(id);

            context.Remove(getId);
            context.SaveChanges();


            return true;
        }

        public IEnumerable<Experimento> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Experimento> GetById(int id)
        {
            return await context.Experimentos.FindAsync(id);
        }

        public async Task Insert(Experimento experimento)
        {
            context.Experimentos.Add(experimento);
            await context.SaveChangesAsync();
        }

        public bool Update(Experimento experimento)
        {
            context.Experimentos.Update(experimento);
            context.Entry(experimento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return true;
        }
    }
}
