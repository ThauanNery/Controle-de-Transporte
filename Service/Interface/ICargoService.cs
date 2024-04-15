using Controle_de_Transporte.Models;

namespace Controle_de_Transporte.Service.Interface
{
    public interface ICargoService
    {
        Task<CargoModel> GetByIdAsync(int id);
        Task<List<CargoModel>> GetAllAsync();
        Task<CargoModel> AddAsync(CargoModel cargo);
        Task<CargoModel> UpdateAsync(CargoModel cargo);
        Task<bool> DeleteAsync(int id);
    }

}
