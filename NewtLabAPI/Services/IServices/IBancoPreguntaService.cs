using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewtlabAPI.Models;

namespace NewtlabAPI.Services.IServices
{
    public interface IBancoPreguntaService
    {
        IEnumerable<BancoPregunta> GetAll();
        Task Insert(BancoPregunta bancoPregunta);
        Task<BancoPregunta> GetById(int id);
        bool Update(BancoPregunta bancoPregunta);
        bool Delete(int id);
        void Publicar(int id, DateTime limit);
        void Deshabilitar(int id);
    }
}
