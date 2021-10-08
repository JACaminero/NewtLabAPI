using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewtlabAPI.Models;

namespace NewtlabAPI.Services.IServices
{
    public interface ITipoPreguntaService
    {
        IEnumerable<TipoPregunta> GetAll();
        Task<TipoPregunta> GetById(int id);
        Task Insert(TipoPregunta tipoPregunta);
        bool Update(TipoPregunta tipoPregunta);
        bool Delete(int id);
    }
}
