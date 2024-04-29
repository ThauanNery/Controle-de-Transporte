using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Controle_de_Transporte.Service.Interface;
using System.Net;

namespace Controle_de_Transporte.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IFuncionariosRepository _funcionarioRepository;

        public UsuarioService(IUsuarioRepository repository, IFuncionariosRepository funcionarioRepository)
        {
            _repository = repository;
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<UsuarioModel> BuscarPorLogin(string login)
        {
            var statusHttp = HttpStatusCode.NotFound;
            try
            {
                var usuario = await _repository.BuscarPorLogin(login);
                if (usuario != null)
                {
                    statusHttp = HttpStatusCode.OK;
                }
                return usuario;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar um Usuario por Login.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<UsuarioModel> GetByIdAsync(int id)
        {
            var statusHttp = HttpStatusCode.NotFound;
            try
            {
                var usuario = await _repository.GetByIdAsync(id);
                if (usuario != null)
                {
                    statusHttp = HttpStatusCode.OK;
                }
                return usuario;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar um Usuario por Id.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<List<UsuarioModel>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao buscar Usuarios.";
                throw new Exception(errorMessage, ex);
            }
        }

        public async Task<UsuarioModel> AddAsync(UsuarioModel usuario, int FuncionarioId)
        {
            try
            {

                var matricula = await _funcionarioRepository.GetByIdAsync(FuncionarioId);

                if (matricula == null)
                {
                    throw new InvalidOperationException("A Usuario especificada não foi encontrada.");
                }


                usuario.FuncionarioId = FuncionarioId;


                await _repository.CreateAsync(usuario);


                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar Usuario.", ex);
            }
        }

        public async Task<UsuarioModel> UpdateAsync(UsuarioModel usuario)
        {
            try
            {
                await _repository.UpdateAsync(usuario);
                return usuario;
            }
            catch (Exception ex)
            {
                string errorMessage = "Ocorreu um erro ao atualizar uma Usuario.";
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
                string errorMessage = "Ocorreu um erro ao apagar uma Usuario.";
                throw new Exception(errorMessage, ex);
            }
        }

      
    }
}
