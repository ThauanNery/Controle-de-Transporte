using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Service.Interface
{
    public interface ICargoService
    {
        CargoModel GetById(int id);
        List<CargoModel> GetAll();
        Task<CargoModel> AddAsync(CargoModel cargo);
        CargoModel Update(CargoModel cargo);
        CargoModel Delete(int id);
    }
}
