using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Service.Interface
{
    public interface IUsuarioService
    {
        Task<UsuarioModel> GetByIdAsync(int id);
        Task<List<UsuarioModel>> GetAllAsync();
        Task<UsuarioModel> AddAsync(UsuarioModel usuario, int FuncionarioId);
        Task<UsuarioModel> UpdateAsync(UsuarioModel usuario);
        Task<bool> DeleteAsync(int id);
    }
}
