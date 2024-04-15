using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Service.Interface
{
    public interface ITipodeTransporteService
    {
        TipoDeTransporteModel GetById(int id);
        List<TipoDeTransporteModel> GetAll();
        Task<TipoDeTransporteModel> AddAsync(TipoDeTransporteModel tpTransporte);
        TipoDeTransporteModel Update(TipoDeTransporteModel tpTransporte);
        TipoDeTransporteModel Delete(int id);
    }
}
