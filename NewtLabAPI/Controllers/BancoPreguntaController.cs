﻿using System;
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
    public class BancoPreguntaController : ControllerBase
    {
        private readonly IBancoPreguntaService service;

        public BancoPreguntaController(IBancoPreguntaService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            List<object> returnable = new List<object>();
            var users = service.GetAll().ToList();
            string k = "Gravedad";
            
            foreach (var i in users)
            {
                switch (i.ExperimentoId)
                {
                    case 1:
                        k = "Gravedad";
                        break;
                    case 2:
                        k = "Inercia";
                        break;
                    case 4:
                        k = "Accion y reaccion";
                        break;
                    default:
                        break;
                }
                returnable.Add(new
                {
                    bancoPreguntaId = i.BancoPreguntaId,
                    tema = i.Tema,
                    fechaCreacion = i.FechaCreacion.ToShortDateString(),
                    publicado = i.Publicado,
                    experimento = k,
                    userId = i.UserId,
                    isOn = i.IsOn,
                });
            }
            return Ok(returnable);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var get = await service.GetById(id);

            return Ok(new { 
            bancoPreguntaId = get.BancoPreguntaId,
            userId = get.UserId,
            tema = get.Tema,
            fechaCreacion = get.FechaCreacion,
            fechaLimite = get.FechaLimite.ToShortDateString(),
            publicado = get.Publicado,
            isOn = get.IsOn,
            });;
        }

        [HttpPost]
        public async Task<IActionResult> InsertarBancoPregunta([FromBody]BancoPregunta bancoPregunta)
        {
            var add = new BancoPregunta
            {
                Tema = bancoPregunta.Tema,
                FechaCreacion =  DateTime.Now,
                ExperimentoId = bancoPregunta.ExperimentoId,
                FechaLimite = bancoPregunta.FechaLimite,
                UserId = bancoPregunta.UserId
            };

            await service.Insert(add);
            return Ok(new { message = "Agregado" });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarBancoPregunta(int id, BancoPregunta bancoPregunta)
        {

            var getId = await service.GetById(id);

            getId.Tema = bancoPregunta.Tema;
            getId.FechaCreacion = DateTime.Now;

            var getS = service.Update(getId);


            return Ok(new { getS } );
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarPregunta(int id)
        {
            var get = service.Delete(id);

            return Ok(new { message = get + " Eliminado" });
        }

        [HttpPut("publicar/{id}")]
        public IActionResult Publicar(int id, [FromBody] LimitVM limit)
        {
            service.Publicar(id, limit.FechaLimite);
            return Ok(new { message = "done" });
        }

        [HttpPut("deshabilitar/{id}")]
        public IActionResult Deshabilitar(int id)
        {
            service.Deshabilitar(id);
            return Ok(new { message = "done" });
        }
    }
    public class LimitVM
    {
        public DateTime FechaLimite { get; set; }
    }
}
