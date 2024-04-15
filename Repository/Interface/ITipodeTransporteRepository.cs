using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Repository.Interface
{
    public interface ITipodeTransporteRepository
    {
        TipoDeTransporteModel GetById(int id);
        List<TipoDeTransporteModel> GetAll();
        Task<TipoDeTransporteModel> createAsync(TipoDeTransporteModel tpTransporte);
        TipoDeTransporteModel update (TipoDeTransporteModel tpTransporte);
        bool deleteById (int id);
    }
}
