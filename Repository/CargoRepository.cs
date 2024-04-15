using Controle_de_Transporte.Data;
using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_Transporte.Repository
{
    public class CargoRepository : ICargoRepository
    {
        private readonly Context _context;
        public CargoRepository(Context context)
        {
            _context = context;
        }

        public async Task<CargoModel> GetByIdAsync(int id)
        {
            return await _context.Cargos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CargoModel>> GetAllAsync()
        {
            return await _context.Cargos.ToListAsync();
        }

        public async Task<CargoModel> CreateAsync(CargoModel cargo)
        {
            try
            {
                _context.Cargos.Add(cargo);
                await _context.SaveChangesAsync();
                return cargo;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar Cargo no banco de dados.", ex);
            }
        }

        public async Task<CargoModel> UpdateAsync(CargoModel cargo)
        {
            CargoModel cargoDb = await GetByIdAsync(cargo.Id);

            if (cargoDb == null) throw new Exception("Houve um erro na atualização do Cargo!");

            cargoDb.NomeCargo = cargo.NomeCargo;

            _context.Cargos.Update(cargoDb);
            await _context.SaveChangesAsync();

            return cargoDb;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            CargoModel cargoDb = await GetByIdAsync(id);

            if (cargoDb == null) throw new Exception("Houve um erro ao apagar o Cargo!");

            _context.Cargos.Remove(cargoDb);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
