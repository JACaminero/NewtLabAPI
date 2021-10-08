using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewtlabAPI.Models;

namespace NewtlabAPI.Services.IServices
{
    public interface IPreguntaService
    {
        IEnumerable<Pregunta> GetAll();
        Task Insert(Pregunta pregunta);
        Task<Pregunta> GetById(int id);
        bool Update(Pregunta pregunta);
        bool Delete(int id);
        bool Enable(int id);

    }
}
