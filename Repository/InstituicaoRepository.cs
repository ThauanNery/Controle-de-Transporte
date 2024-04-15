using Controle_de_Transporte.Data;
using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_Transporte.Repository
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly Context _context;
        public InstituicaoRepository(Context context)
        {
            _context = context;
        }

        public async Task<InstituicaoModel> GetByIdAsync(int id)
        {
            return await _context.Instituicaos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<InstituicaoModel>> GetAllAsync()
        {
            return await _context.Instituicaos.ToListAsync();
        }

        public async Task<InstituicaoModel> CreateAsync(InstituicaoModel instituicao)
        {
            try
            {
                _context.Instituicaos.Add(instituicao);
                await _context.SaveChangesAsync();
                return instituicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar instituição no banco de dados.", ex);
            }
        }

        public async Task<InstituicaoModel> UpdateAsync(InstituicaoModel instituicao)
        {
            InstituicaoModel InstituicaoDb = await GetByIdAsync(instituicao.Id);

            if (InstituicaoDb == null) throw new Exception("Houve um erro na atualização da Instituição!");

            InstituicaoDb.NomeInstituicao = instituicao.NomeInstituicao;
            InstituicaoDb.CNPJ = instituicao.CNPJ;

            _context.Instituicaos.Update(InstituicaoDb);
            _context.SaveChanges();

            return InstituicaoDb;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            InstituicaoModel InstituicaoDb = await GetByIdAsync(id);

            if (InstituicaoDb == null) throw new Exception("Houve um erro ao apagar a Instituição!");

            _context.Instituicaos.Remove(InstituicaoDb);
            _context.SaveChanges();
            return true;
        }

    }
}
