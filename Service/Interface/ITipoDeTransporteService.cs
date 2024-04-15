﻿using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Service.Interface
{
    public interface ITipodeTransporteService
    {
        Task<TipoDeTransporteModel> GetByIdAsync(int id);
        Task<List<TipoDeTransporteModel>> GetAllAsync();
        Task<TipoDeTransporteModel> AddAsync(TipoDeTransporteModel tpTransporte);
        Task<TipoDeTransporteModel> UpdateAsync(TipoDeTransporteModel tpTransporte);
        Task<bool> DeleteAsync(int id);
    }

}
