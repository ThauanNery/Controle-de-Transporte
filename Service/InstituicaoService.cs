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
            catch (Exception Ex)
            {
                throw;
            }
        }

        public List<InstituicaoModel> GetAll()
        {
            return _repository.GetAll();
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
                throw;
            }
        }

        public InstituicaoModel Update(InstituicaoModel instituicao)
        {
            try
            {
                    _repository.update(instituicao);
                    return instituicao;

            }
            catch (Exception Ex)
            {
                throw;
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
            catch (Exception Ex)
            {
                throw;
            }
        }
             
    }
}
