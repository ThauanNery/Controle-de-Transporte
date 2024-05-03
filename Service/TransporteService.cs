using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Controle_de_Transporte.Service.Interface;
using System.Net;

namespace Controle_de_Transporte.Service
{
    public class TransporteService : ITransporteService
    {
        private readonly ITransporteRepository _repository;
        private readonly IFuncionariosRepository _funcRepository;
        private readonly IMatriculaTransporteRepository _matTranspRepository;
        private readonly ITipodeTransporteRepository _tpTranspRepository;
        private readonly IManutencaoRepository _manuRepository;

        public TransporteService(ITransporteRepository repository, IFuncionariosRepository funcRepository, IMatriculaTransporteRepository matTranspRepository, ITipodeTransporteRepository tpTranspRepository, IManutencaoRepository manuRepository)
        {
            _repository = repository;
            _funcRepository = funcRepository;
            _matTranspRepository = matTranspRepository;
            _tpTranspRepository = tpTranspRepository;
            _manuRepository = manuRepository;
           
        }

        public async Task<TransporteModel> GetByIdAsync(int id)
        {
            var statusHttp = HttpStatusCode.NotFound;
            try
            {
                var transporte = await _repository.GetByIdAsync(id);
                if (transporte != null)
                {
                    statusHttp = HttpStatusCode.OK;
                }
                return transporte;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar um transporte por Id.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<List<TransporteModel>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar transportes.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<TransporteModel> AddAsync(TransporteModel transporte, int tipoTransporteId, int funcionarioId, int matriculaTransporteId, int manutencaoId)
        {
            try
            {

                var funcionario = await _funcRepository.GetByIdAsync(funcionarioId);
                var tpTransporte = await _tpTranspRepository.GetByIdAsync(tipoTransporteId);
                var matTransporte = await _matTranspRepository.GetByIdAsync(matriculaTransporteId);
                var manutencao = await _manuRepository.GetByIdAsync(manutencaoId);


                if (funcionario == null)
                {
                    throw new InvalidOperationException("O funcionario especificada não foi encontrada.");
                }
                if (tpTransporte == null)
                {
                    throw new InvalidOperationException("O tipoTransporte especificada não foi encontrada.");
                } 
                if (matTransporte == null)
                {
                    throw new InvalidOperationException("O matricula do Transporte especificada não foi encontrada.");
                }


                transporte.FuncionarioId = funcionarioId;
                transporte.MatriculaTransporteId = matriculaTransporteId; 
                transporte.TipoTransporteId = tipoTransporteId;
                transporte.ManutencaoId = manutencaoId;


                await _repository.CreateAsync(transporte);


                return transporte;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar transporte.", ex);
            }
        }

        public async Task<TransporteModel> UpdateAsync(TransporteModel transporte)
        {
            try
            {
                await _repository.UpdateAsync(transporte);
                return transporte;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao atualizar um transporte.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _repository.DeleteByIdAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao apagar um transporte.";
                throw new Exception(errorMessage, ex);
            }
        }
    }
}
