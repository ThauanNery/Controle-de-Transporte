using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Controle_de_Transporte.Service.Interface;
using System.Net;
using System.Threading.Tasks;

namespace Controle_de_Transporte.Service
{
    public class InstituicaoService : IInstituicaoService
    {
        private readonly IInstituicaoRepository _repository;

        public InstituicaoService(IInstituicaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<InstituicaoModel> GetByIdAsync(int id)
        {
            var statusHttp = HttpStatusCode.NotFound;
            try
            {
                var instituicao = await _repository.GetByIdAsync(id);
                if (instituicao != null)
                {
                    statusHttp = HttpStatusCode.OK;
                }
                return instituicao;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar a instituição por Id.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<List<InstituicaoModel>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar a instituição.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<InstituicaoModel> AddAsync(InstituicaoModel instituicao)
        {
            try
            {
                await _repository.CreateAsync(instituicao);
                return instituicao;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao adicionar a instituição.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<InstituicaoModel> UpdateAsync(InstituicaoModel instituicao)
        {
            try
            {
                await _repository.UpdateAsync(instituicao);
                return instituicao;

            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao atualizar a instituição.";
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
                string errorMessage = "Ocorreu um erro ao apagar a instituição.";
                throw new Exception(errorMessage, ex);
            }
        }
    }
}
