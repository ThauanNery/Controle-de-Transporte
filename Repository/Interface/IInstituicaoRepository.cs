using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Repository.Interface
{
    public interface IInstituicaoRepository
    {
        Task<InstituicaoModel> GetByIdAsync(int id);
        Task<List<InstituicaoModel>> GetAllAsync();
        Task<InstituicaoModel> CreateAsync(InstituicaoModel instituicao);
        Task<InstituicaoModel> UpdateAsync(InstituicaoModel instituicao);
        Task<bool> DeleteByIdAsync(int id);
    }
}
