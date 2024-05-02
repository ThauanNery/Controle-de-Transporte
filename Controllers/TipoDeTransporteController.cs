using Controle_de_Transporte.Models;
using Controle_de_Transporte.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var transportes = await _tpTransporteService.GetAllAsync();
                return Ok(transportes);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var transporte = await _tpTransporteService.GetByIdAsync(id);
                if (transporte == null)
                {
                    return NotFound();
                }
                return Ok(transporte);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(TipoDeTransporteModel tpTransporte)
        {
            try
            {
                var retorno = await _tpTransporteService.AddAsync(tpTransporte);
                return StatusCode((int)HttpStatusCode.Created, retorno);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(TipoDeTransporteModel tpTransporte)
        {
            try
            {
                await _tpTransporteService.UpdateAsync(tpTransporte);
                return Ok(tpTransporte);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _tpTransporteService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }
    }
}
