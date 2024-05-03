using Controle_de_Transporte.Data;
using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_Transporte.Repository
{
    public class MatriculaTransporteRepository : IMatriculaTransporteRepository
    {
        private readonly Context _context;
        public MatriculaTransporteRepository(Context context)
        {
            _context = context;
        }

        public async Task<MatriculaTransporteModel> GetByIdAsync(int id)
        {
            return await _context.matriculaTransportes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<MatriculaTransporteModel>> GetAllAsync()
        {
            return await _context.matriculaTransportes.ToListAsync();
        }

        public async Task<MatriculaTransporteModel> CreateAsync(MatriculaTransporteModel matricula)
        {
            try
            {
                _context.matriculaTransportes.Add(matricula);
                await _context.SaveChangesAsync();
                return matricula;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar a Matricula do Transporte no banco de dados.", ex);
            }
        }

        public async Task<MatriculaTransporteModel> UpdateAsync(MatriculaTransporteModel matricula)
        {
            MatriculaTransporteModel matriculaDb = await GetByIdAsync(matricula.Id);

            if (matriculaDb == null) throw new Exception("Houve um erro na atualização da Matricula do Transporte!");

            matriculaDb.Matricula = matricula.Matricula;

            _context.matriculaTransportes.Update(matriculaDb);
            await _context.SaveChangesAsync();

            return matriculaDb;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            MatriculaTransporteModel matriculaDb = await GetByIdAsync(id);

            if (matriculaDb == null) throw new Exception("Houve um erro ao apagar a Matricula do Transporte!");

            _context.matriculaTransportes.Remove(matriculaDb);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
