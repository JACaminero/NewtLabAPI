using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewtlabAPI.Models;
using NewtlabAPI.Services.IServices;

namespace NewtlabAPI.Controllers
{
    [Route("newtlabapi/[controller]")]
    [ApiController]
    public class TipoPreguntaController : ControllerBase
    {
        private readonly ITipoPreguntaService tpServ;

        public TipoPreguntaController(ITipoPreguntaService _tpServ)
        {
            tpServ = _tpServ;
        }


        [HttpGet("conceptos")]
        public ActionResult GetHist()
        {
            return Ok(tpServ.GetAll());
        }

        [HttpPost("conceptos")]
        public ActionResult InsertHist([FromBody] TipoPregunta h)
        {
            tpServ.Insert(h);
            return Ok();
        }

        [HttpPut("conceptos")]
        public async Task<ActionResult> U([FromBody] TipoPregunta tipPregunta)
        {

            var getId = await tpServ.GetById(tipPregunta.TipoPreguntaId);

            getId.Concepto = tipPregunta.Concepto;
            getId.Descripcion = tipPregunta.Descripcion;

            tpServ.Update(getId);
            return Ok();
        }

    }
}
