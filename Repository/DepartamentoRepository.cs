using Controle_de_Transporte.Data;
using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_Transporte.Repository
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly Context _context;

        public DepartamentoRepository(Context context)
        {
            _context = context;
        }

        public async Task<DepartamentoModel> GetByIdAsync(int id)
        {
            return await _context.Departamentos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<DepartamentoModel>> GetAllAsync()
        {
            return await _context.Departamentos.ToListAsync();
        }

        public async Task<DepartamentoModel> createAsync(DepartamentoModel departamento)
        {
            try
            {
                _context.Departamentos.Add(departamento);
                await _context.SaveChangesAsync();
                return departamento;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar Departamento no banco de dados.", ex);
            }
        }

        public async Task<DepartamentoModel> updateAsync(DepartamentoModel departamento)
        {
            DepartamentoModel departamentoDb = await GetByIdAsync(departamento.Id);

            if (departamentoDb == null) throw new Exception("Houve um erro na atualização do Departamento!");

            departamentoDb.NomeDepartamento = departamento.NomeDepartamento;

            _context.Departamentos.Update(departamentoDb);
            await _context.SaveChangesAsync();

            return departamentoDb;
        }

        public async Task<bool> deleteByIdAsync(int id)
        {
            DepartamentoModel departamentoDb = await GetByIdAsync(id);

            if (departamentoDb == null) throw new Exception("Houve um erro ao apagar o Departamento!");

            _context.Departamentos.Remove(departamentoDb);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}

