using Controle_de_Transporte.Models;
using Controle_de_Transporte.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Controle_de_Transporte.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TipoDeTransporteController : ControllerBase
    {
        private readonly ITipodeTransporteService _tpTransporteService;
        public TipoDeTransporteController(ITipodeTransporteService tpTransporteService)
        {
            _tpTransporteService = tpTransporteService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var retorno = _tpTransporteService.GetAll();
                return StatusCode((int)HttpStatusCode.OK, retorno);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var retorno = _tpTransporteService.GetById(id);
            return StatusCode((int)HttpStatusCode.OK, retorno);
        }


        [HttpPost]
        public async Task<IActionResult> Create(TipoDeTransporteModel tpTransporte)
        {
            try
            {
                var retorno = await _tpTransporteService.AddAsync(tpTransporte);
                return StatusCode((int)HttpStatusCode.Created, null);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }

        
        [HttpPut]
        public IActionResult Update(TipoDeTransporteModel tpTransporte)
        {
            var retorno = _tpTransporteService.Update(tpTransporte);
            return StatusCode((int)HttpStatusCode.OK, null);
        }

        [HttpDelete("{id:int}")]
        public virtual IActionResult Delete(int id)
        {
            var retorno = _tpTransporteService.Delete(id);
            return StatusCode((int)HttpStatusCode.OK, null);
        }

    }
}
