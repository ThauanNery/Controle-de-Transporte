using Controle_de_Transporte.Models;
using Controle_de_Transporte.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Controle_de_Transporte.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MatriculaTransporteController : ControllerBase
    {
        private readonly IMatriculaTransporteService _service;
        public MatriculaTransporteController(IMatriculaTransporteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var matriculas = await _service.GetAllAsync();
                return Ok(matriculas);
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
                var matricula = await _service.GetByIdAsync(id);
                if (matricula == null)
                {
                    return NotFound();
                }
                return Ok(matricula);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(MatriculaTransporteModel matricula)
        {
            try
            {
                var retorno = await _service.AddAsync(matricula);
                return StatusCode((int)HttpStatusCode.Created, matricula);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(MatriculaTransporteModel matricula)
        {
            try
            {
                await _service.UpdateAsync(matricula);
                return Ok(matricula);
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
