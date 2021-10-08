using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewtlabAPI.Models;

namespace NewtlabAPI.Services.IServices
{
    public interface IExperimentoService
    {
        IEnumerable<Experimento> GetAll();
        Task<Experimento> GetById(int id);
        Task Insert(Experimento experimento);
        bool Update(Experimento experimento);
        bool Delete(int id);
    }
}
