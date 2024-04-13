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
    public class InstituicaoController : Controller
    {
        private readonly IInstituicaoService _instituicaoService;
        public InstituicaoController(IInstituicaoService instituicaoService)
        {
            _instituicaoService = instituicaoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var retorno = _instituicaoService.GetAll();
                return StatusCode((int)HttpStatusCode.OK, null);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Erro = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var retorno = _instituicaoService.GetById(id);
            return StatusCode((int)HttpStatusCode.OK, null);
        }


        [HttpPost]
        public IActionResult Create(InstituicaoModel instituicao)
        {
            try
            {
                var retorno = _instituicaoService.Add(instituicao);
                return StatusCode((int)HttpStatusCode.Created, null);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, null);
            }
        }
        [HttpPut]
        public IActionResult Update(InstituicaoModel instituicao)
        {
            var retorno = _instituicaoService.Update(instituicao);
            return StatusCode((int)HttpStatusCode.OK, null);
        }

        [HttpDelete("{id:int}")]
        public virtual IActionResult Delete(int id)
        {
            var retorno = _instituicaoService.Delete(id);
            return StatusCode((int)HttpStatusCode.OK, null);
        }

    }
}
