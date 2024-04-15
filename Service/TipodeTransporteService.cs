using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Controle_de_Transporte.Service.Interface;
using System.Net;

namespace Controle_de_Transporte.Service
{
    public class TipodeTransporteService : ITipodeTransporteService
    {
        private readonly ITipodeTransporteRepository _repository;

        public TipodeTransporteService(ITipodeTransporteRepository repository)
        {
            _repository = repository;
        }

        public TipoDeTransporteModel GetById(int id)
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

        public List<TipoDeTransporteModel> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<TipoDeTransporteModel> AddAsync(TipoDeTransporteModel tpTransporte)
        {
            try
            {
               
                await _repository.createAsync(tpTransporte);
                return tpTransporte;
            }
            catch (Exception ex)
            {               
                throw;
            }
        }

        public TipoDeTransporteModel Update(TipoDeTransporteModel instituicao)
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

        public TipoDeTransporteModel Delete(int id)
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
