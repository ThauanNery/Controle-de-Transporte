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

        public TipoDeTransporteModel GetById(int id)
        {
            return _context.tipoDeTransportes.FirstOrDefault(x => x.Id == id);
        }

        public List<TipoDeTransporteModel> GetAll()
        {
            return _context.tipoDeTransportes.ToList();
        }
        public async Task<TipoDeTransporteModel> createAsync(TipoDeTransporteModel tpTransporte)
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
      
        public TipoDeTransporteModel update(TipoDeTransporteModel tpTransporte)
        {
            TipoDeTransporteModel tpTransporteDb = GetById(tpTransporte.Id);

            if (tpTransporteDb == null) throw new Exception("Houve um erro na atualização do Tipo de Transporte!");

            tpTransporteDb.NomeTransporte = tpTransporte.NomeTransporte;

            _context.tipoDeTransportes.Update(tpTransporteDb);
            _context.SaveChanges();

            return tpTransporte;
        }
        public bool deleteById(int id)
        {
            TipoDeTransporteModel tpTransporteDb = GetById(id);

            if (tpTransporteDb == null) throw new Exception("Houve um erro ao apagar o Tipo de Transporte!");

            _context.tipoDeTransportes.Remove(tpTransporteDb);
            _context.SaveChanges();
            return true;
        }

    }
}
