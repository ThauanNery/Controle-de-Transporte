using Controle_de_Transporte.Data;
using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_Transporte.Repository
{
    public class TipodeTransporteRepository : ITipodeTransporteRepository
    {
        private readonly Context _context;
        public TipodeTransporteRepository(Context context)
        {
            _context = context;
        }

        public async Task<TipoDeTransporteModel> GetByIdAsync(int id)
        {
            return await _context.tipoDeTransportes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TipoDeTransporteModel>> GetAllAsync()
        {
            return await _context.tipoDeTransportes.ToListAsync();
        }

        public async Task<TipoDeTransporteModel> CreateAsync(TipoDeTransporteModel tpTransporte)
        {
            try
            {
                _context.tipoDeTransportes.Add(tpTransporte);
                await _context.SaveChangesAsync();
                return tpTransporte;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar o Tipo de Transporte no banco de dados.", ex);
            }
        }

        public async Task<TipoDeTransporteModel> UpdateAsync(TipoDeTransporteModel tpTransporte)
        {
            TipoDeTransporteModel tpTransporteDb = await GetByIdAsync(tpTransporte.Id); 

            if (tpTransporteDb == null) throw new Exception("Houve um erro na atualização do Tipo de Transporte!");

            tpTransporteDb.NomeTransporte = tpTransporte.NomeTransporte;

            _context.tipoDeTransportes.Update(tpTransporteDb);
            await _context.SaveChangesAsync();

            return tpTransporteDb;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            TipoDeTransporteModel tpTransporteDb = await GetByIdAsync(id);

            if (tpTransporteDb == null) throw new Exception("Houve um erro ao apagar o Tipo de Transporte!");

            _context.tipoDeTransportes.Remove(tpTransporteDb);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
