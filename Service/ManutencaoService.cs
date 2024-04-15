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

        public ManutencaoModel GetById(int id)
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
                string errorMessage = "Ocorreu um erro ao buscar um Tipo de Manutenção por Id.";
                throw new Exception(errorMessage, ex);
            }
        }

        public List<ManutencaoModel> GetAll()
        {
            try
            {
                return _repository.GetAll();
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

                await _repository.createAsync(manutencao);
                return manutencao;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao adicinonar um Tipo de Manutenção.";
                throw new Exception(errorMessage, ex);
            }
        }

        public ManutencaoModel Update(ManutencaoModel manutencao)
        {
            try
            {
                _repository.update(manutencao);
                return manutencao;

            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao atualiza um Tipo de Manutenção.";
                throw new Exception(errorMessage, ex);
            }
        }

        public ManutencaoModel Delete(int id)
        {
            var statusHttp = HttpStatusCode.NoContent;
            try
            {
                _repository.deleteById(id);
                return null;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao apagar um Tipo de Manutenção.";
                throw new Exception(errorMessage, ex);
            }
        }
    }
}
