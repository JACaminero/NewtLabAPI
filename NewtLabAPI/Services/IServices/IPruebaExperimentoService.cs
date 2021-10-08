using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewtlabAPI.Models;

namespace NewtlabAPI.Services.IServices
{
    public interface IPruebaExperimentoService
    {
        IEnumerable<PruebaExperimento> GetAll();
        Task Insert(PruebaExperimento pruebaExperimento);
        Task<PruebaExperimento> GetById(int id);
        bool Update(PruebaExperimento pruebaExperimento);
        bool Delete(int id);
    }
}
