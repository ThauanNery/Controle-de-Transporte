using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Repository.Interface
{
    public interface IManutencaoRepository
    {
        ManutencaoModel GetById(int id);
        List<ManutencaoModel> GetAll();
        Task<ManutencaoModel> createAsync(ManutencaoModel manutencao);
        ManutencaoModel update(ManutencaoModel manutencao);
        bool deleteById(int id);
    }
}
