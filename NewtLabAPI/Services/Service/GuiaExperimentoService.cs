using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewtlabAPI.Data;
using NewtlabAPI.Models;
using NewtlabAPI.Services.IServices;

namespace NewtlabAPI.Services.Service
{
    public class GuiaExperimentoService: IGuiaExperimento
    {
        private readonly NewtLabContext context;
        public GuiaExperimentoService(NewtLabContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            var getId = context.GuiaExperimentos.Find(id);
            context.Remove(getId);
            context.SaveChanges();

            return true;
        }

        public IEnumerable<GuiaExperimento> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<GuiaExperimento> GetById(int id)
        {
            return await context.GuiaExperimentos.FindAsync(id);
        }

        public async Task Insert(GuiaExperimento experimento)
        {
            context.GuiaExperimentos.Add(experimento);
           await context.SaveChangesAsync();
        }

        public bool Update(GuiaExperimento experimento)
        {
            context.GuiaExperimentos.Update(experimento);
            context.Entry(experimento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return true;
        }
    }
}
