using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Repository.Interface
{
    public interface ICargoRepository
    {
        CargoModel GetById(int id);
        List<CargoModel> GetAll();
        Task<CargoModel> createAsync(CargoModel cargo);
        CargoModel update(CargoModel cargo);
        bool deleteById(int id);
    }
}
