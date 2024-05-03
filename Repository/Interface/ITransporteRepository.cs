using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Repository.Interface
{
    public interface ITransporteRepository
    {
        Task<TransporteModel> GetByIdAsync(int id);
        Task<List<TransporteModel>> GetAllAsync();
        Task<TransporteModel> CreateAsync(TransporteModel transporte);
        Task<TransporteModel> UpdateAsync(TransporteModel transporte);
        Task<bool> DeleteByIdAsync(int id);
    }
}
