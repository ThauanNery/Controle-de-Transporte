using Controle_de_Transporte.Data;
using Controle_de_Transporte.Models;
using Controle_de_Transporte.Service;
using Controle_de_Transporte.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Controle_de_Transporte.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoService _instituicaoService;
        public InstituicaoController(IInstituicaoService instituicaoService)
        {
            _instituicaoService = instituicaoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           
                var retorno = _instituicaoService.GetAll();
                return StatusCode((int)HttpStatusCode.OK, retorno);
           
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var retorno = _instituicaoService.GetById(id);
            return StatusCode((int)HttpStatusCode.OK, retorno);
        }


        [HttpPost]
        public async Task<IActionResult> Create(InstituicaoModel instituicao)
        {
                var retorno = await _instituicaoService.AddAsync(instituicao);
                return StatusCode((int)HttpStatusCode.Created, retorno);
        }

        
        [HttpPut]
        public IActionResult Update(InstituicaoModel instituicao)
        {
            var retorno = _instituicaoService.Update(instituicao);
            return StatusCode((int)HttpStatusCode.OK, retorno);
        }

        [HttpDelete("{id:int}")]
        public virtual IActionResult Delete(int id)
        {
            var retorno = _instituicaoService.Delete(id);
            return StatusCode((int)HttpStatusCode.OK, retorno);
        }

    }
}
