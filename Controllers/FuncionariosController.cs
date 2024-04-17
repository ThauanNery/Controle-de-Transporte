using Controle_de_Transporte.Models;
using Controle_de_Transporte.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Controle_de_Transporte.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FuncionariosController : Controller
    {
        private readonly IFuncionariosService _funcionarioService;
        public FuncionariosController(IFuncionariosService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var funcionarios = await _funcionarioService.GetAllAsync();
                return Ok(funcionarios);
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
                var funcionarios = await _funcionarioService.GetByIdAsync(id);
                if (funcionarios == null)
                {
                    return NotFound();
                }
                return Ok(funcionarios);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }


        [HttpPost("{funcionarioId}")]
        public async Task<IActionResult> CreateAsync(int departamentoId, int cargoId, [FromBody] FuncionariosModel funcionario)
        {
            try
            {

                var novaoFuncionario = await _funcionarioService.AddAsync(funcionario, departamentoId, cargoId);


                return CreatedAtAction(nameof(GetByIdAsync), new { id = novaoFuncionario.Id }, novaoFuncionario);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao criar um Funcionario.");
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync(FuncionariosModel funcionario)
        {
            try
            {
                await _funcionarioService.UpdateAsync(funcionario);
                return Ok(funcionario);
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
                await _funcionarioService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }
    }
}
