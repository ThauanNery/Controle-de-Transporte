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
            return _repository.GetById(id);
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

        //public InstituicaoModel Add(InstituicaoModel instituicao)
        //{
        //    var statusHttp = HttpStatusCode.Created;
        //    try
        //    {

        //        _repository.create(instituicao);               
        //        return instituicao;

        //    }
        //    catch (Exception Ex)
        //    {
        //        throw;
        //    }
        //}

        public InstituicaoModel Update(InstituicaoModel instituicao)
        {
            var statusHttp = HttpStatusCode.NoContent;
            try
            {
                bool atualizaEntidade = (bool)instituicao.GetType().GetProperty("AtualizaEntidade").GetValue(instituicao);
                if (atualizaEntidade)
                {
                    _repository.update(instituicao);
                }


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
