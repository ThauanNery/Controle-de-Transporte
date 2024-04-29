using Controle_de_Transporte.Data;
using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_Transporte.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Context _context;
        public UsuarioRepository(Context context)
        {
            _context = context;
        }

        public async Task<UsuarioModel> BuscarPorLogin(string login)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Login.ToUpper() == login.ToUpper());

        }
        public async Task<UsuarioModel> GetByIdAsync(int id)
        {
            return await _context.Usuarios
                .Include(d => d.Funcionarios)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> GetAllAsync()
        {
            return await _context.Usuarios
                .Include(d => d.Funcionarios)
                .ToListAsync();
        }

        public async Task<UsuarioModel> CreateAsync(UsuarioModel usuario)
        {
            try
            {
                var matricula = await _context.Funcionarios.FindAsync(usuario.FuncionarioId);
                if (matricula == null)
                {
                    throw new InvalidOperationException("A Matricula especificada não foi encontrada.");
                }

                usuario.Funcionarios = matricula;

                _context.Usuarios.Add(usuario);

                await _context.SaveChangesAsync();

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar Usuario no banco de dados.", ex);
            }
        }

        public async Task<UsuarioModel> UpdateAsync(UsuarioModel usuario)
        {
            UsuarioModel MatriculaDb = await GetByIdAsync(usuario.Id);

            if (MatriculaDb == null) throw new Exception("Houve um erro na atualização do Usuario!");

            MatriculaDb.Login = usuario.Login;
            MatriculaDb.Senha = usuario.Senha;

            _context.Usuarios.Update(MatriculaDb);
            await _context.SaveChangesAsync();

            return MatriculaDb;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            UsuarioModel MatriculaDb = await GetByIdAsync(id);

            if (MatriculaDb == null) throw new Exception("Houve um erro ao apagar um Usuario!");

            _context.Usuarios.Remove(MatriculaDb);
            await _context.SaveChangesAsync();
            return true;
        }

        
    }
}
