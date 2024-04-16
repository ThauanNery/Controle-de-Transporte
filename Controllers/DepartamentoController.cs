using Controle_de_Transporte.Models;
using Controle_de_Transporte.Service;
using Controle_de_Transporte.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Controle_de_Transporte.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;
        public DepartamentoController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var departamentos = await _departamentoService.GetAllAsync();
                return Ok(departamentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var departamento = await _departamentoService.GetByIdAsync(id);
                if (departamento == null)
                {
                    return NotFound();
                }
                return Ok(departamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{instituicaoId}")]
        public async Task<IActionResult> CreateDepartamento(int instituicaoId, [FromBody] DepartamentoModel departamento)
        {
            try
            {
                // Chama o método AddAsync do serviço, passando o departamento e o ID da instituição
                var novoDepartamento = await _departamentoService.AddAsync(departamento, instituicaoId);

                // Retorna o novo departamento criado
                return CreatedAtAction(nameof(GetByIdAsync), new { id = novoDepartamento.Id }, novoDepartamento);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message); // Retorna NotFound se a instituição não for encontrada
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao criar o departamento.");
            }
        }



        //[HttpPost]
        //public async Task<IActionResult> CreateAsync(DepartamentoModel departamento)
        //{
        //    try
        //    {
        //        var retorno = await _departamentoService.AddAsync(departamento);
        //        return StatusCode((int)HttpStatusCode.Created, retorno);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(DepartamentoModel departamento)
        {
            try
            {
                await _departamentoService.UpdateAsync(departamento);
                return Ok(departamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _departamentoService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
