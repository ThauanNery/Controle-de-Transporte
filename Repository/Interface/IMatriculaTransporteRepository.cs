using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Repository.Interface
{
    public interface IMatriculaTransporteRepository
    {
        Task<MatriculaTransporteModel> GetByIdAsync(int id);
        Task<List<MatriculaTransporteModel>> GetAllAsync();
        Task<MatriculaTransporteModel> CreateAsync(MatriculaTransporteModel matricula);
        Task<MatriculaTransporteModel> UpdateAsync(MatriculaTransporteModel matricula);
        Task<bool> DeleteByIdAsync(int id);
    }
}
