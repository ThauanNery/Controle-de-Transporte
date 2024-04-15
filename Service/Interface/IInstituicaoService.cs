using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Service.Interface
{
    public interface IInstituicaoService
    {
        InstituicaoModel GetById(int id);
        List<InstituicaoModel> GetAll();
        Task<InstituicaoModel> AddAsync(InstituicaoModel instituicao);
        InstituicaoModel Update(InstituicaoModel instituicao);
        InstituicaoModel Delete(int id);
    }
}
