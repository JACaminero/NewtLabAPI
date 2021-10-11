using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewtlabAPI.Data;
using NewtlabAPI.Models;
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
        public PruebaController(IPruebaExperimentoService _peServ)
        {
            peServ = _peServ;
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
            List<object> returnable = new List<object>();
            var ps = peServ.GetAllPruebasByUser(id);
            foreach (var i in ps)
            {
                returnable.Add(new
                {
                    userId = i.UserId,
                    titulo = i.Titulo,
                    fechaTomado = i.FechaTomado.ToShortDateString(),
                    calificacionObtenida = i.CalificacionObtenida,
                    bancoPreguntaId = i.BancoPreguntaId,
                    i.isCerrada,
                    periodo = i.Periodo
                });
            }
            return Ok(new { data = returnable, message = "Operacion exitosa" });
        }

        [HttpGet("nota/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(new { message = "Operacion exitosa" });
        }

        public class PruebaVM
        {
            public IEnumerable<PruebaRespuesta> Prs { get; set; }
            public PruebaExperimento Pe { get; set; }
        }
        //[HttpGet]
        //public async Task<IActionResult> getAll()
        //{
        //    List<object> returnable = new List<object>();
        //    var users = service.GetAll().ToList();
        //    string k = "Gravedad";

        //    foreach (var i in users)
        //    {
        //        switch (i.ExperimentoId)
        //        {
        //            case 1:
        //                k = "Gravedad";
        //                break;
        //            case 2:
        //                k = "Inercia";
        //                break;
        //            case 4:
        //                k = "Accion y reaccion";
        //                break;
        //            default:
        //                break;
        //        }
        //        returnable.Add(new
        //        {
        //            bancoPreguntaId = i.BancoPreguntaId,
        //            tema = i.Tema,
        //            fechaCreacion = i.FechaCreacion.ToShortDateString(),
        //            fechaLimite = i.FechaLimite.ToShortDateString(),
        //            publicado = i.Publicado,
        //            experimento = k,
        //            userId = i.UserId,
        //            isOn = i.IsOn,
        //            tituloPublicado = i.TituloPublicado,
        //        });
        //    }
        //    return Ok(returnable);
        //}

    }
}
