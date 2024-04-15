using Controle_de_Transporte.Data;
using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;

namespace Controle_de_Transporte.Repository
{
    public class CargoRepository : ICargoRepository
    {
        private readonly Context _context;
        public CargoRepository(Context context)
        {
            _context = context;
        }

        public CargoModel GetById(int id)
        {
            return _context.Cargos.FirstOrDefault(x => x.Id == id);
        }

        public List<CargoModel> GetAll()
        {
            return _context.Cargos.ToList();
        }
        public async Task<CargoModel> createAsync(CargoModel cargo)
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

        public CargoModel update(CargoModel cargo)
        {
            CargoModel cargoDb = GetById(cargo.Id);

            if (cargoDb == null) throw new Exception("Houve um erro na atualização do Cargo!");

            cargoDb.NomeCargo = cargo.NomeCargo;

            _context.Cargos.Update(cargoDb);
            _context.SaveChanges();

            return cargoDb;
        }
        public bool deleteById(int id)
        {
            CargoModel cargoDb = GetById(id);

            if (cargoDb == null) throw new Exception("Houve um erro ao apagar o Cargo!");

            _context.Cargos.Remove(cargoDb);
            _context.SaveChanges();
            return true;
        }
    }
}
