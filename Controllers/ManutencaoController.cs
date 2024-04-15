using Controle_de_Transporte.Models;
using Controle_de_Transporte.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public IActionResult GetAll()
        {

            var retorno = _manutencaoService.GetAll();
            return StatusCode((int)HttpStatusCode.OK, retorno);

        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var retorno = _manutencaoService.GetById(id);
            return StatusCode((int)HttpStatusCode.OK, retorno);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ManutencaoModel manutencao)
        {
            var retorno = await _manutencaoService.AddAsync(manutencao);
            return StatusCode((int)HttpStatusCode.Created, retorno);
        }


        [HttpPut]
        public IActionResult Update(ManutencaoModel manutencao)
        {
            var retorno = _manutencaoService.Update(manutencao);
            return StatusCode((int)HttpStatusCode.OK, retorno);
        }

        [HttpDelete("{id:int}")]
        public virtual IActionResult Delete(int id)
        {
            var retorno = _manutencaoService.Delete(id);
            return StatusCode((int)HttpStatusCode.OK, retorno);
        }

    }
}
