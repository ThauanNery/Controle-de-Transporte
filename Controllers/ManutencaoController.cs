using Controle_de_Transporte.Models;
using Controle_de_Transporte.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Controle_de_Transporte.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ManutencaoController : ControllerBase
    {
        private readonly IManutencaoService _manutencaoService;
        public ManutencaoController(IManutencaoService manutencaoService)
        {
            _manutencaoService = manutencaoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var manutencoes = await _manutencaoService.GetAllAsync();
                return Ok(manutencoes);
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
                var manutencao = await _manutencaoService.GetByIdAsync(id);
                if (manutencao == null)
                {
                    return NotFound();
                }
                return Ok(manutencao);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(ManutencaoModel manutencao)
        {
            try
            {
                var retorno = await _manutencaoService.AddAsync(manutencao);
                return StatusCode((int)HttpStatusCode.Created, retorno);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ManutencaoModel manutencao)
        {
            try
            {
                await _manutencaoService.UpdateAsync(manutencao);
                return Ok(manutencao);
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
                await _manutencaoService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }
    }
}
