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
    public class GuiaExperimentoController : ControllerBase
    {
        private readonly IGuiaExperimento service;

        public GuiaExperimentoController(IGuiaExperimento service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenernerGuiaExperimento()
        {
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            return Ok(service.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Insertar(GuiaExperimento ex)
        {
            var add = new GuiaExperimento
            {
                Titulo = ex.Titulo,
                Descripcion = ex.Descripcion,
                Experimento = ex.Experimento,
                Instruccion = ex.Instruccion
            };

            await service.Insert(add);

            return Ok("Agregado!");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarGuiaExperimento(int id, GuiaExperimento ex)
        {
            var getId = await service.GetById(id);

            getId.Titulo = ex.Titulo;
            getId.Descripcion = ex.Descripcion;
            getId.Experimento = ex.Experimento;
            getId.Instruccion = ex.Instruccion;

            var update = service.Update(getId);

            return Ok(update);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarGuiaExperimento(int id)
        {
            var eliminar = service.Delete(id);

            return Ok(eliminar);
        }
    }
}
