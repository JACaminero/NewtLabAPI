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
    public class PreguntaController : ControllerBase
    {
        private readonly IPreguntaService service;
        private readonly IRespuestaService rServ;

        public PreguntaController(IPreguntaService service, IRespuestaService rServ)
        {
            this.service = service;
            this.rServ = rServ;
        }

        [HttpGet("respuestas/{id}")]
        public async Task<IActionResult> GetRespuestaByPregId(int id)
        {
            return Ok(rServ.GetAll().Where(r => id == r.PreguntaId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByBpId(int id)
        {
            return Ok(service.GetAll().Where(p => id == p.BancoPreguntaId));
        }

        [HttpGet]
        public async Task<IActionResult>Get()
        {
            return Ok(service.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Pregunta pregunta)
        {
            pregunta.TipoPreguntaId = 1;
            pregunta.IsOn = true;

            await service.Insert(pregunta);

            return Ok(new { message = "Agregado" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pregunta pregunta)
        {
            var getId = await service.GetById(id);

            getId.Puntuacion = pregunta.Puntuacion;
            getId.Descripcion = pregunta.Descripcion;

            service.Update(getId);

            return Ok(new { message = "Actualizado" });
        }

        [HttpDelete("habilitar/{id}")]
        public async Task<IActionResult> Enable(int id)
        {
            service.Enable(id);
            return Ok(new { message = "Exito" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            service.Delete(id);
            return Ok(new { message = "Exito" });
        }
    }
}
