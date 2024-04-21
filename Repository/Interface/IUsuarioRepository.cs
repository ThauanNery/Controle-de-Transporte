using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Repository.Interface
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel> GetByIdAsync(int id);
        Task<List<UsuarioModel>> GetAllAsync();
        Task<UsuarioModel> CreateAsync(UsuarioModel usuario);
        Task<UsuarioModel> UpdateAsync(UsuarioModel usuario);
        Task<bool> DeleteByIdAsync(int id);
    }
}
