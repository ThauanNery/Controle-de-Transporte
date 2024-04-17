using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Repository.Interface
{
    public interface IFuncionariosRepository
    {
        Task<FuncionariosModel> GetByIdAsync(int id);
        Task<List<FuncionariosModel>> GetAllAsync();
        Task<FuncionariosModel> createAsync(FuncionariosModel funcionarios);
        Task<FuncionariosModel> updateAsync(FuncionariosModel funcionarios);
        Task<bool> deleteByIdAsync(int id);
    }
}
