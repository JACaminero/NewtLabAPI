using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewtlabAPI.Models;
using NewtlabAPI.Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewtlabAPI.Controllers
{
    [Route("newtlabapi/[controller]")]
    [ApiController]
    public class ExperimentoController : ControllerBase
    {
        private readonly IExperimentoService service;

        public ExperimentoController(IExperimentoService service)
        {
            this.service = service;
        }


        [HttpGet]
        public async Task<IActionResult> ObtenerExperimentos()
        {
            var get = service.GetAll();

            return Ok(get);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getById = service.GetById(id);

            return Ok(getById);
        }

        [HttpPost]
        public async Task<IActionResult> InsertExperimento(Experimento experimento)
        {
            var add = new Experimento
            {
                Title = experimento.Title,
                Concepto = experimento.Concepto,
                Puntuacion = experimento.Puntuacion
            };


            await service.Insert(add);


            return Ok("Agregado");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarExperimetno(int id, Experimento experimento)
        {

            var getId =  await service.GetById(id);

            getId.Title = experimento.Title;
            getId.Concepto = experimento.Concepto;
            getId.Puntuacion = experimento.Puntuacion;

            service.Update(getId);


            return Ok("Actualizado!");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarExperimento(int id)
        {
            return Ok(service.Delete(id));
        }
    }
}
