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

            public DepartamentoService(IDepartamentoRepository repository)
            {
                _repository = repository;
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

        public async Task<DepartamentoModel> AddAsync(DepartamentoModel departamento)
        {
            try
            {
                var instituicao = await _repository.GetByIdAsync(departamento.InstituicaoId);
                if (instituicao == null)
                {
                    throw new Exception("Instituicao não encontrada com o ID informado.");
                }

                await _repository.createAsync(departamento);
                return departamento;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao adicinonar um Departamento.";
                throw new Exception(errorMessage, ex);
            }
        }

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
