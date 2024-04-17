using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Service.Interface
{
    public interface IMatriculaFuncionarioService
    {
        Task<MatriculaFuncionarioModel> GetByIdAsync(int id);
        Task<List<MatriculaFuncionarioModel>> GetAllAsync();
        Task<MatriculaFuncionarioModel> AddAsync(MatriculaFuncionarioModel matriculaFuncionario, int FuncionarioId);
        Task<MatriculaFuncionarioModel> UpdateAsync(MatriculaFuncionarioModel matriculaFuncionario);
        Task<bool> DeleteAsync(int id);
    }
}
