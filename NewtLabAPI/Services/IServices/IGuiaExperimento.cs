using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewtlabAPI.Models;

namespace NewtlabAPI.Services.IServices
{
    public interface IGuiaExperimento
    {
        IEnumerable<GuiaExperimento> GetAll();
        Task<GuiaExperimento> GetById(int id);
        Task Insert(GuiaExperimento experimento);
        bool Update(GuiaExperimento experimento);
        bool Delete(int id);
    }
}
