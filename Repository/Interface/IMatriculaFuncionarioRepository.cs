using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Repository.Interface
{
    public interface IMatriculaFuncionarioRepository
    {
        Task<MatriculaFuncionarioModel> GetByIdAsync(int id);
        Task<List<MatriculaFuncionarioModel>> GetAllAsync();
        Task<MatriculaFuncionarioModel> CreateAsync(MatriculaFuncionarioModel matriculaFuncionario);
        Task<MatriculaFuncionarioModel> UpdateAsync(MatriculaFuncionarioModel matriculaFuncionario);
        Task<bool> DeleteByIdAsync(int id);
    }
}
