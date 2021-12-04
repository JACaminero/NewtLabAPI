using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewtlabAPI.Data;
using NewtlabAPI.Models;
using NewtlabAPI.Services;
using NewtlabAPI.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NewtlabAPI.Controllers
{
    [Route("newtlabapi/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        private readonly IPruebaExperimentoService peServ;
        private readonly IUserService uServ;
        public PruebaController(IPruebaExperimentoService _peServ, IUserService _uServ)
        {
            peServ = _peServ;
            uServ = _uServ;
        }

        [HttpPost]
        public async Task<IActionResult> UploadTest([FromBody] PruebaVM pe)
        {
            if (pe.Pe == null || pe.Prs == null)
                return StatusCode(1000, new { message = "Los objetos enviados son nulos" });

            await peServ.Insert(pe.Pe, pe.Prs);
            return Ok(new { message = "Operacion exitosa" });
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetPruebasByUserId(int id)
        {
            int califTotalAllPruebas = 0;
            List<object> returnable = new List<object>();
            var ps = peServ.GetAllPruebasByUser(id);
            foreach (var i in ps)
            {
                califTotalAllPruebas += i.CalificacionObtenida;
                returnable.Add(new
                {
                    userId = i.UserId,
                    titulo = i.Titulo,
                    fechaTomado = i.FechaTomado.ToShortDateString(),
                    calificacionObtenida = i.CalificacionObtenida,
                    calificacionObtenidaReal = i.CalificacionObtenidaReal,
                    calificacionTotal = i.CalificacionTotal,
                    bancoPreguntaId = i.BancoPreguntaId,
                    i.IsCerrada,
                    periodo = i.Periodo
                });
            }
            return Ok(new { data = returnable, califTotalAllPruebas, message = "Operacion exitosa" });
        }

        [HttpGet("respuestas/{id}")]
        public IActionResult GetRespuestasPrueba(int id)
        {
            var prs = peServ.GetPruebaRespuestasByPruebaId(id);
            return Ok(prs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var p = await peServ.GetById(id);
            return Ok(p);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = peServ.GetAll().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].User = uServ.GetById(list[i].UserId);
            }

            return Ok(new {
                data = list, 
                message = "Operacion exitosa" 
            });
        }

        public class PruebaVM
        {
            public IEnumerable<PruebaRespuesta> Prs { get; set; }
            public PruebaExperimento Pe { get; set; }
        }
       
    }
}
