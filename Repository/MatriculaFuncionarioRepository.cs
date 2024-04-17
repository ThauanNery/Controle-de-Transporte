using Controle_de_Transporte.Data;
using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_Transporte.Repository
{
    public class MatriculaFuncionarioRepository : IMatriculaFuncionarioRepository
    {
        private readonly Context _context;
        public MatriculaFuncionarioRepository(Context context)
        {
            _context = context;
        }

        public async Task<MatriculaFuncionarioModel> GetByIdAsync(int id)
        {
            return await _context.matriculaFuncionarios
                .Include(d => d.Funcionarios)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<MatriculaFuncionarioModel>> GetAllAsync()
        {
            return await _context.matriculaFuncionarios
                .Include(d => d.Funcionarios)
                .ToListAsync();
        }

        public async Task<MatriculaFuncionarioModel> CreateAsync(MatriculaFuncionarioModel matriculaFuncionario)
        {
            try
            {
                var funcionario = await _context.Funcionarios.FindAsync(matriculaFuncionario.FuncionarioId);
                if (funcionario == null)
                {
                    throw new InvalidOperationException("A Funcionario especificada não foi encontrada.");
                }

                matriculaFuncionario.Funcionarios = funcionario;

                _context.matriculaFuncionarios.Add(matriculaFuncionario);

                await _context.SaveChangesAsync();

                return matriculaFuncionario;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar Matricula no banco de dados.", ex);
            }            
        }

        public async Task<MatriculaFuncionarioModel> UpdateAsync(MatriculaFuncionarioModel matriculaFuncionario)
        {
            MatriculaFuncionarioModel MatriculaFuncionarioDb = await GetByIdAsync(matriculaFuncionario.Id);

            if (MatriculaFuncionarioDb == null) throw new Exception("Houve um erro na atualização da matricula!");

            MatriculaFuncionarioDb.Matricula = matriculaFuncionario.Matricula;

            _context.matriculaFuncionarios.Update(MatriculaFuncionarioDb);
            await _context.SaveChangesAsync();

            return MatriculaFuncionarioDb;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            MatriculaFuncionarioModel MatriculaFuncionarioModelDb = await GetByIdAsync(id);

            if (MatriculaFuncionarioModelDb == null) throw new Exception("Houve um erro ao apagar uma matricula!");

            _context.matriculaFuncionarios.Remove(MatriculaFuncionarioModelDb);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
