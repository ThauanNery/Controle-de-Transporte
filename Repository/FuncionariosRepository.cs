using Controle_de_Transporte.Data;
using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_Transporte.Repository
{
    public class FuncionariosRepository : IFuncionariosRepository
    {
        private readonly Context _context;
        public FuncionariosRepository(Context context)
        {
            _context = context;
        }

        public async Task<FuncionariosModel> GetByIdAsync(int id)
        {
            return await _context.Funcionarios
                .Include(d => d.Cargo)
                .Include(d => d.Departamento)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<FuncionariosModel>> GetAllAsync()
        {
            return await _context.Funcionarios
               .Include(d => d.Cargo)
               .Include(d => d.Departamento)
               .ToListAsync();
        }

        public async Task<FuncionariosModel> createAsync(FuncionariosModel funcionario)
        {
            try
            {
                var departamento = await _context.Departamentos.FindAsync(funcionario.DepartamentoId);
                var cargo = await _context.Cargos.FindAsync(funcionario.CargoId);
                if (departamento == null)
                {
                    throw new InvalidOperationException("O departamento especificada não foi encontrada.");
                }
                if (cargo == null)
                {
                    throw new InvalidOperationException("O cargo especificada não foi encontrada.");
                }

                funcionario.Departamento = departamento;
                funcionario.Cargo = cargo;


                _context.Funcionarios.Add(funcionario);

                await _context.SaveChangesAsync();

                return funcionario;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar Funcionario no banco de dados.", ex);
            }
        }

        public async Task<FuncionariosModel> updateAsync(FuncionariosModel funcionario)
        {
            FuncionariosModel FuncionarioDb = await GetByIdAsync(funcionario.Id);

            if (FuncionarioDb == null) throw new Exception("Houve um erro na atualização do Funcionario!");

            FuncionarioDb.NomeFuncionario = funcionario.NomeFuncionario;
            FuncionarioDb.Cargo = funcionario.Cargo;
            FuncionarioDb.Departamento = funcionario.Departamento;

            _context.Funcionarios.Update(FuncionarioDb);
            await _context.SaveChangesAsync();

            return FuncionarioDb;
        }

        public async Task<bool> deleteByIdAsync(int id)
        {
            FuncionariosModel aFuncionarioModelDb = await GetByIdAsync(id);

            if (aFuncionarioModelDb == null) throw new Exception("Houve um erro ao apagar o Funcionario!");

            _context.Funcionarios.Remove(aFuncionarioModelDb);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
