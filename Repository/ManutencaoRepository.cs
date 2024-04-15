using Controle_de_Transporte.Data;
using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;

namespace Controle_de_Transporte.Repository
{
    public class ManutencaoRepository : IManutencaoRepository
    {
        private readonly Context _context;
        public ManutencaoRepository(Context context)
        {
            _context = context;
        }

        public ManutencaoModel GetById(int id)
        {
            return _context.manutencaos.FirstOrDefault(x => x.Id == id);
        }

        public List<ManutencaoModel> GetAll()
        {
            return _context.manutencaos.ToList();
        }
        public async Task<ManutencaoModel> createAsync(ManutencaoModel manutencao)
        {
            try
            {
                _context.manutencaos.Add(manutencao);
                await _context.SaveChangesAsync();
                return manutencao;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar instituição no banco de dados.", ex);
            }
        }

        public ManutencaoModel update(ManutencaoModel manutencao)
        {
            ManutencaoModel manutencaoDb = GetById(manutencao.Id);

            if (manutencaoDb == null) throw new Exception("Houve um erro na atualização da Instituição!");

            manutencaoDb.TipoManutencao = manutencao.TipoManutencao;
            manutencaoDb.Custo = manutencao.Custo;

            _context.manutencaos.Update(manutencaoDb);
            _context.SaveChanges();

            return manutencaoDb;
        }
        public bool deleteById(int id)
        {
            ManutencaoModel manutencaoDb = GetById(id);

            if (manutencaoDb == null) throw new Exception("Houve um erro ao apagar a Instituição!");

            _context.manutencaos.Remove(manutencaoDb);
            _context.SaveChanges();
            return true;
        }
    }
}
