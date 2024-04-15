using Controle_de_Transporte.Models;
using Controle_de_Transporte.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Controle_de_Transporte.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargoService;
        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var retorno = _cargoService.GetAll();
            return StatusCode((int)HttpStatusCode.OK, retorno);

        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var retorno = _cargoService.GetById(id);
            return StatusCode((int)HttpStatusCode.OK, retorno);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CargoModel cargo)
        {
            var retorno = await _cargoService.AddAsync(cargo);
            return StatusCode((int)HttpStatusCode.Created, retorno);
        }


        [HttpPut]
        public IActionResult Update(CargoModel cargo)
        {
            var retorno = _cargoService.Update(cargo);
            return StatusCode((int)HttpStatusCode.OK, retorno);
        }

        [HttpDelete("{id:int}")]
        public virtual IActionResult Delete(int id)
        {
            var retorno = _cargoService.Delete(id);
            return StatusCode((int)HttpStatusCode.OK, retorno);
        }
    }
}
