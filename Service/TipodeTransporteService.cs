using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Controle_de_Transporte.Service.Interface;
using System.Net;
using System.Threading.Tasks;

namespace Controle_de_Transporte.Service
{
    public class TipodeTransporteService : ITipodeTransporteService
    {
        private readonly ITipodeTransporteRepository _repository;

        public TipodeTransporteService(ITipodeTransporteRepository repository)
        {
            _repository = repository;
        }

        public async Task<TipoDeTransporteModel> GetByIdAsync(int id)
        {
            var statusHttp = HttpStatusCode.NotFound;
            try
            {
                var tpTransporte = await _repository.GetByIdAsync(id);
                if (tpTransporte != null)
                {
                    statusHttp = HttpStatusCode.OK;
                }
                return tpTransporte;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar o Tipo de Transporte por Id.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<List<TipoDeTransporteModel>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar o Tipo de Transporte.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<TipoDeTransporteModel> AddAsync(TipoDeTransporteModel tpTransporte)
        {
            try
            {
                await _repository.CreateAsync(tpTransporte);
                return tpTransporte;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao adicionar o Tipo de Transporte.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<TipoDeTransporteModel> UpdateAsync(TipoDeTransporteModel tpTransporte)
        {
            try
            {
                await _repository.UpdateAsync(tpTransporte);
                return tpTransporte;

            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao atualizar o Tipo de Transporte.";
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
                string errorMessage = "Ocorreu um erro ao apagar o Tipo de Transporte.";
                throw new Exception(errorMessage, ex);
            }
        }
    }
}
