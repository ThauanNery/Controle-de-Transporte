using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Repository.Interface
{
    public interface IDepartamentoRepository
    {
        Task<DepartamentoModel> GetByIdAsync(int id);
        Task<List<DepartamentoModel>> GetAllAsync();
        Task<DepartamentoModel> createAsync(DepartamentoModel cargo);
        Task<DepartamentoModel> updateAsync(DepartamentoModel cargo);
        Task<bool> deleteByIdAsync(int id);
    }
}
