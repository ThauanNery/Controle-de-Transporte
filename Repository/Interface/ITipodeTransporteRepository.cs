using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Repository.Interface
{
    public interface ITipodeTransporteRepository
    {
        Task<TipoDeTransporteModel> GetByIdAsync(int id);
        Task<List<TipoDeTransporteModel>> GetAllAsync();
        Task<TipoDeTransporteModel> CreateAsync(TipoDeTransporteModel tpTransporte);
        Task<TipoDeTransporteModel> UpdateAsync(TipoDeTransporteModel tpTransporte);
        Task<bool> DeleteByIdAsync(int id);
    }
}
