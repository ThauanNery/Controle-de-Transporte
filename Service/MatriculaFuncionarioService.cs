using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository;
using Controle_de_Transporte.Repository.Interface;
using Controle_de_Transporte.Service.Interface;
using System.Net;

namespace Controle_de_Transporte.Service
{
    public class MatriculaFuncionarioService : IMatriculaFuncionarioService
    {
        private readonly IMatriculaFuncionarioRepository _repository;
        private readonly IFuncionariosRepository _funcionarioRepository;

        public MatriculaFuncionarioService(IMatriculaFuncionarioRepository repository, IFuncionariosRepository funcionarioRepository)
        {
            _repository = repository;
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<MatriculaFuncionarioModel> GetByIdAsync(int id)
        {
            var statusHttp = HttpStatusCode.NotFound;
            try
            {
                var matriculaFuncionario = await _repository.GetByIdAsync(id);
                if (matriculaFuncionario != null)
                {
                    statusHttp = HttpStatusCode.OK;
                }
                return matriculaFuncionario;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar um Cargo por Id.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<List<MatriculaFuncionarioModel>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar Cargos.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<MatriculaFuncionarioModel> AddAsync(MatriculaFuncionarioModel matriculaFuncionario, int FuncionarioId)
        {
            try
            {

                var funcionario = await _funcionarioRepository.GetByIdAsync(FuncionarioId);

                if (funcionario == null)
                {
                    throw new InvalidOperationException("A instituição especificada não foi encontrada.");
                }


                matriculaFuncionario.FuncionarioId = FuncionarioId;


                await _repository.CreateAsync(matriculaFuncionario);


                return matriculaFuncionario;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar Departamento.", ex);
            }
        }

        public async Task<MatriculaFuncionarioModel> UpdateAsync(MatriculaFuncionarioModel matriculaFuncionario)
        {
            try
            {
                await _repository.UpdateAsync(matriculaFuncionario);
                return matriculaFuncionario;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao atualizar uma matricula.";
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
                string errorMessage = "Ocorreu um erro ao apagar uma matricula.";
                throw new Exception(errorMessage, ex);
            }
        }
    }
}
