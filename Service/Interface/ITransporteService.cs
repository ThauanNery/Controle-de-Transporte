using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Service.Interface
{
    public interface ITransporteService
    {
        Task<TransporteModel> GetByIdAsync(int id);
        Task<List<TransporteModel>> GetAllAsync();
        Task<TransporteModel> AddAsync(TransporteModel transporte, int tipoTransporteId, int funcionarioId, int matriculaTransporteId, int manutencaoId);
        Task<TransporteModel> UpdateAsync(TransporteModel funcionarios);
        Task<bool> DeleteAsync(int id);
    }
}
