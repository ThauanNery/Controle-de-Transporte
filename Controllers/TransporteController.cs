using Controle_de_Transporte.Models;
using Controle_de_Transporte.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Controle_de_Transporte.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TransporteController : ControllerBase
    {
        private readonly ITransporteService _service;
        public TransporteController(ITransporteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var transportes = await _service.GetAllAsync();
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
                var transporte = await _service.GetByIdAsync(id);
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


        [HttpPost("{tipoTransporteId},{funcionarioId},{matriculaTransporteId},{manutencaoId}")]
        public async Task<IActionResult> CreateAsync(int tipoTransporteId, int funcionarioId, int matriculaTransporteId, int manutencaoId, [FromBody] TransporteModel transporte)
        {
            try
            {

                var novoTransporte = await _service.AddAsync(transporte, tipoTransporteId,  funcionarioId,  matriculaTransporteId,  manutencaoId);


                return CreatedAtAction(nameof(GetByIdAsync), new { id = novoTransporte.Id }, novoTransporte);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao criar um transporte.");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(TransporteModel transporte)
        {
            try
            {
                await _service.UpdateAsync(transporte);
                return Ok(transporte);
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
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }
    }
}
