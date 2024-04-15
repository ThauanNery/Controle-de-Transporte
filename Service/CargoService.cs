using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Controle_de_Transporte.Service.Interface;
using System.Net;

namespace Controle_de_Transporte.Service
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _repository;

        public CargoService(ICargoRepository repository)
        {
            _repository = repository;
        }

        public CargoModel GetById(int id)
        {
            var statusHttp = HttpStatusCode.NotFound;
            try
            {
                var repositorio = _repository.GetById(id);
                if (repositorio != null)
                {
                    statusHttp = HttpStatusCode.OK;

                }
                return repositorio;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar um Cargo por Id.";
                throw new Exception(errorMessage, ex);
            }
        }

        public List<CargoModel> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar Cargos.";
                throw new Exception(errorMessage, ex);
            }

        }

        public async Task<CargoModel> AddAsync(CargoModel cargo)
        {
            try
            {

                await _repository.createAsync(cargo);
                return cargo;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao adicinonar um Cargo.";
                throw new Exception(errorMessage, ex);
            }
        }

        public CargoModel Update(CargoModel cargo)
        {
            try
            {
                _repository.update(cargo);
                return cargo;

            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao atualiza um Cargo.";
                throw new Exception(errorMessage, ex);
            }
        }

        public CargoModel Delete(int id)
        {
            var statusHttp = HttpStatusCode.NoContent;
            try
            {
                _repository.deleteById(id);
                return null;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao apagar um Cargo.";
                throw new Exception(errorMessage, ex);
            }
        }
    }
}
