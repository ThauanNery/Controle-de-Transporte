using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Controle_de_Transporte.Service.Interface;
using System.Net;

namespace Controle_de_Transporte.Service
{
    public class ManutencaoService : IManutencaoService
    {
        private readonly IManutencaoRepository _repository;

        public ManutencaoService(IManutencaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ManutencaoModel> GetByIdAsync(int id)
        {
            var statusHttp = HttpStatusCode.NotFound;
            try
            {
                var manutencao = await _repository.GetByIdAsync(id);
                if (manutencao != null)
                {
                    statusHttp = HttpStatusCode.OK;
                }
                return manutencao;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar um Tipo de Manutenção por Id.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<List<ManutencaoModel>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar Tipos de Manutenção.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<ManutencaoModel> AddAsync(ManutencaoModel manutencao)
        {
            try
            {
                await _repository.CreateAsync(manutencao);
                return manutencao;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao adicionar um Tipo de Manutenção.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<ManutencaoModel> UpdateAsync(ManutencaoModel manutencao)
        {
            try
            {
                await _repository.UpdateAsync(manutencao);
                return manutencao;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao atualizar um Tipo de Manutenção.";
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
                string errorMessage = "Ocorreu um erro ao apagar um Tipo de Manutenção.";
                throw new Exception(errorMessage, ex);
            }
        }
    }
}
