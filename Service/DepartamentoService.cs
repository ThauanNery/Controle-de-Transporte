using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository;
using Controle_de_Transporte.Repository.Interface;
using Controle_de_Transporte.Service.Interface;
using System.Net;

namespace Controle_de_Transporte.Service
{
   
        public class DepartamentoService : IDepartamentoService
        {
            private readonly IDepartamentoRepository _repository;
            private readonly IInstituicaoRepository _instituicaoRepository;

            public DepartamentoService(IDepartamentoRepository repository, IInstituicaoRepository instituicaoRepository)
            {
                _repository = repository;
                _instituicaoRepository = instituicaoRepository;
            }

        public async Task<DepartamentoModel> GetByIdAsync(int id)
        {
            var statusHttp = HttpStatusCode.NotFound;
            try
            {
                var departamento = await _repository.GetByIdAsync(id);
                if (departamento != null)
                {
                    statusHttp = HttpStatusCode.OK;
                }
                return departamento;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar um Departamento por Id.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<List<DepartamentoModel>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar Departamentos.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<DepartamentoModel> AddAsync(DepartamentoModel departamento, int instituicaoId)
        {
            try
            {
                // Verifica se a instituição associada ao departamento existe
                var instituicao = await _instituicaoRepository.GetByIdAsync(instituicaoId);

                if (instituicao == null)
                {
                    throw new InvalidOperationException("A instituição especificada não foi encontrada.");
                }

                // Associa a instituição ao departamento
                departamento.InstituicaoId = instituicaoId;

                // Adiciona o departamento ao repositório
                await _repository.createAsync(departamento);

                // Retorna o departamento adicionado
                return departamento;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar Departamento.", ex);
            }
        }




        //public async Task<DepartamentoModel> AddAsync(DepartamentoModel departamento)
        //{
        //    try
        //    {

        //        await _repository.createAsync(departamento);
        //        return departamento;
        //    }
        //    catch (Exception ex)
        //    {
        //        string errorMessage = "Ocorreu um erro ao adicinonar um Departamento.";
        //        throw new Exception(errorMessage, ex);
        //    }
        //}

        public async Task<DepartamentoModel> UpdateAsync(DepartamentoModel departamento)
        {
            try
            {
                await _repository.updateAsync(departamento);
                return departamento;

            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao atualiza um Departamento.";
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
                string errorMessage = "Ocorreu um erro ao apagar um Departamento.";
                throw new Exception(errorMessage, ex);
            }
        }
    }
}
