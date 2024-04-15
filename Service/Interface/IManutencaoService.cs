using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Service.Interface
{
    public interface IManutencaoService
    {
        ManutencaoModel GetById(int id);
        List<ManutencaoModel> GetAll();
        Task<ManutencaoModel> AddAsync(ManutencaoModel manutencao);
        ManutencaoModel Update(ManutencaoModel manutencao);
        ManutencaoModel Delete(int id);
    }
}
