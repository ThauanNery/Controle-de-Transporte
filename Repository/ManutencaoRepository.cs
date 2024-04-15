using Controle_de_Transporte.Data;
using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Controle_de_Transporte.Repository
{
    public class ManutencaoRepository : IManutencaoRepository
    {
        private readonly Context _context;
        public ManutencaoRepository(Context context)
        {
            _context = context;
        }

        public async Task<ManutencaoModel> GetByIdAsync(int id)
        {
            return await _context.manutencaos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ManutencaoModel>> GetAllAsync()
        {
            return await _context.manutencaos.ToListAsync();
        }

        public async Task<ManutencaoModel> CreateAsync(ManutencaoModel manutencao)
        {
            try
            {
                _context.manutencaos.Add(manutencao);
                await _context.SaveChangesAsync();
                return manutencao;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar Tipo de Matutenção no banco de dados.", ex);
            }
        }

        public async Task<ManutencaoModel> UpdateAsync(ManutencaoModel manutencao)
        {
            ManutencaoModel manutencaoDb = await GetByIdAsync(manutencao.Id);

            if (manutencaoDb == null) throw new Exception("Houve um erro na atualização do Tipo de Matutenção!");

            manutencaoDb.TipoManutencao = manutencao.TipoManutencao;
            manutencaoDb.Custo = manutencao.Custo;

            _context.manutencaos.Update(manutencaoDb);
            await _context.SaveChangesAsync();

            return manutencaoDb;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            ManutencaoModel manutencaoDb = await GetByIdAsync(id);

            if (manutencaoDb == null) throw new Exception("Houve um erro ao apagar o Tipo de Matutenção!");

            _context.manutencaos.Remove(manutencaoDb);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
