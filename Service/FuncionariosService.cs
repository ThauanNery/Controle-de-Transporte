using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Controle_de_Transporte.Service.Interface;
using System.Net;

namespace Controle_de_Transporte.Service
{
    public class FuncionariosService : IFuncionariosService
    {
        private readonly IFuncionariosRepository _repository;
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly ICargoRepository _cargoRepository;

        public FuncionariosService(IFuncionariosRepository repository, IDepartamentoRepository departamentoRepository, ICargoRepository cargoRepository)
        {
            _repository = repository;
            _departamentoRepository = departamentoRepository;
            _cargoRepository = cargoRepository;
        }

        public async Task<FuncionariosModel> GetByIdAsync(int id)
        {
            var statusHttp = HttpStatusCode.NotFound;
            try
            {
                var funcionario = await _repository.GetByIdAsync(id);
                if (funcionario != null)
                {
                    statusHttp = HttpStatusCode.OK;
                }
                return funcionario;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar um Funcionario por Id.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<List<FuncionariosModel>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar Funcionario.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<FuncionariosModel> AddAsync(FuncionariosModel Funcionario, int departamentoId, int cargoId)
        {
            try
            {

                var departamento = await _departamentoRepository.GetByIdAsync(departamentoId);
                var cargo = await _cargoRepository.GetByIdAsync(cargoId);

                if (departamento == null)
                {
                    throw new InvalidOperationException("O departamento especificada não foi encontrada.");
                }
                if (cargo == null)
                {
                    throw new InvalidOperationException("O cargo especificada não foi encontrada.");
                }


                Funcionario.DepartamentoId = departamentoId;
                Funcionario.CargoId = cargoId;


                await _repository.createAsync(Funcionario);


                return Funcionario;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar Funcionario.", ex);
            }
        }

        public async Task<FuncionariosModel> UpdateAsync(FuncionariosModel funcionario)
        {
            try
            {
                await _repository.updateAsync(funcionario);
                return funcionario;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao atualizar um funcionario.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _repository.deleteByIdAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao apagar um funcionario.";
                throw new Exception(errorMessage, ex);
            }
        }
    }
}

