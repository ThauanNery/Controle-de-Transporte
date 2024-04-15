using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Controle_de_Transporte.Service.Interface;
using System.Net;

namespace Controle_de_Transporte.Service
{
    public class InstituicaoService : IInstituicaoService
    {
        private readonly IInstituicaoRepository _repository;

        public InstituicaoService(IInstituicaoRepository repository)
        {
            _repository = repository;
        }

        public InstituicaoModel GetById(int id)
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
                string errorMessage = "Ocorreu um erro ao buscar a instituição por Id.";
                throw new Exception(errorMessage, ex);
            }
        }

        public List<InstituicaoModel> GetAll()
        {
            try
            {
                return _repository.GetAll();
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
               
                await _repository.createAsync(instituicao);
                return instituicao;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao adicinonar a instituição.";
                throw new Exception(errorMessage, ex);
            }
        }

        public InstituicaoModel Update(InstituicaoModel instituicao)
        {
            try
            {
                    _repository.update(instituicao);
                    return instituicao;

            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao atualiza a instituição.";
                throw new Exception(errorMessage, ex);
            }
        }

        public InstituicaoModel Delete(int id)
        {
            var statusHttp = HttpStatusCode.NoContent;
            try
            {
                _repository.deleteById(id);
                return null;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao apagar a instituição.";
                throw new Exception(errorMessage, ex);
            }
        }
             
    }
}
