using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewtlabAPI.Models;

namespace NewtlabAPI.Services.IServices
{
    public interface IRespuestaService
    {
        IEnumerable<Respuesta> GetAll();
        Task<Respuesta> GetById(int id);
        Task Insert(Respuesta respuesta);
        bool Update(Respuesta respuesta);
        bool Delete(int id);
    }
}
