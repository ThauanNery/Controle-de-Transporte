using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Repository.Interface
{
    public interface IInstituicaoRepository
    {
        InstituicaoModel GetById(int id);
        List<InstituicaoModel> GetAll();
        InstituicaoModel create (InstituicaoModel instituicao);
        InstituicaoModel update (InstituicaoModel instituicao);
        bool deleteById (int id);
    }
}
