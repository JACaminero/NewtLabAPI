using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewtlabAPI.Models;

namespace NewtlabAPI.Services.IServices
{
    public interface IPruebaExperimentoService
    {
        IEnumerable<PruebaRespuesta> GetPruebaRespuestasByPruebaId(int id);
        IEnumerable<PruebaExperimento> GetAll();
        IEnumerable<PruebaExperimento> GetAllPruebasByUser(int userId);
        Task Insert(PruebaExperimento pruebaExperimento, IEnumerable<PruebaRespuesta> prs);
        Task<PruebaExperimento> GetById(int id);
        bool Update(PruebaExperimento pruebaExperimento);
        bool Delete(int id);
    }
}
