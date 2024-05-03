using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Controle_de_Transporte.Service.Interface;
using System.Net;

namespace Controle_de_Transporte.Service
{
    public class MatriculaTransporteService : IMatriculaTransporteService
    {
        private readonly IMatriculaTransporteRepository _repository;

        public MatriculaTransporteService(IMatriculaTransporteRepository repository)
        {
            _repository = repository;
        }

        public async Task<MatriculaTransporteModel> GetByIdAsync(int id)
        {
            var statusHttp = HttpStatusCode.NotFound;
            try
            {
                var cargo = await _repository.GetByIdAsync(id);
                if (cargo != null)
                {
                    statusHttp = HttpStatusCode.OK;
                }
                return cargo;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar uma Matricula do Transporte por Id.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<List<MatriculaTransporteModel>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar a Matricula do Transporte.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<MatriculaTransporteModel> AddAsync(MatriculaTransporteModel matricula)
        {
            try
            {
                await _repository.CreateAsync(matricula);
                return matricula;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao adicionar uma Matricula do Transporte.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<MatriculaTransporteModel> UpdateAsync(MatriculaTransporteModel matricula)
        {
            try
            {
                await _repository.UpdateAsync(matricula);
                return matricula;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao atualizar uma Matricula do Transporte.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _repository.DeleteByIdAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao apagar uma Matricula do Transporte.";
                throw new Exception(errorMessage, ex);
            }
        }
    }
}
