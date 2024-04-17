using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Service.Interface
{
    public interface IFuncionariosService
    {
        Task<FuncionariosModel> GetByIdAsync(int id);
        Task<List<FuncionariosModel>> GetAllAsync();
        Task<FuncionariosModel> AddAsync(FuncionariosModel funcionarios, int departamentoId, int cargoId);
        Task<FuncionariosModel> UpdateAsync(FuncionariosModel funcionarios);
        Task<bool> DeleteAsync(int id);
    }
}
