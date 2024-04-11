using Controle_de_Transporte.Data;
using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
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

        public InstituicaoModel GetById(int id)
        {
            return _context.Instituicaos.FirstOrDefault(x => x.Id == id);
        }

        public List<InstituicaoModel> GetAll()
        {
            return _context.Instituicaos.ToList();
        }

        public InstituicaoModel create(InstituicaoModel instituicao)
        {
            _context.Instituicaos.Add(instituicao);
            _context.SaveChangesAsync();
            return instituicao;
        }
              
        public InstituicaoModel update(InstituicaoModel instituicao)
        {
            InstituicaoModel InstitucaoDb = GetById(instituicao.Id);

            if (InstitucaoDb == null) throw new Exception("Houve um erro na atualização da Instituição!");

            InstitucaoDb.NomeInstituicao = instituicao.NomeInstituicao;
            InstitucaoDb.CNPJ = instituicao.CNPJ;           

            _context.Instituicaos.Update(InstitucaoDb);
            _context.SaveChanges();

            return InstitucaoDb;
        }
        public bool deleteById(int id)
        {
            InstituicaoModel InstitucaoDb = GetById(id);

            if (InstitucaoDb == null) throw new Exception("Houve um erro ao apagar a Instituição!");

            _context.Instituicaos.Remove(InstitucaoDb);
            _context.SaveChanges();
            return true;
        }

    }
}
