using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Service.Interface
{
    public interface IMatriculaTransporteService
    {
        Task<MatriculaTransporteModel> GetByIdAsync(int id);
        Task<List<MatriculaTransporteModel>> GetAllAsync();
        Task<MatriculaTransporteModel> AddAsync(MatriculaTransporteModel matricula);
        Task<MatriculaTransporteModel> UpdateAsync(MatriculaTransporteModel matricula);
        Task<bool> DeleteAsync(int id);
    }
}
