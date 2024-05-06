using Controle_de_Transporte.Data;
using Controle_de_Transporte.Models;
using Controle_de_Transporte.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_Transporte.Repository
{
    public class TransporteRepository : ITransporteRepository
    {

        private readonly Context _context;
        public TransporteRepository(Context context)
        {
            _context = context;
        }

        public async Task<TransporteModel> GetByIdAsync(int id)
        {
            return await _context.transportes
                .Include(d => d.MatriculaTransporte)
                .Include(d => d.TipoDeTransportes)
                .Include(d => d.Manutencao)
                .Include(d => d.Funcionario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TransporteModel>> GetAllAsync()
        {
            return await _context.transportes
                .Include(d => d.MatriculaTransporte)
                .Include(d => d.TipoDeTransportes)
                .Include(d => d.Manutencao)
                .Include(d => d.Funcionario)
               .ToListAsync();
        }

        public async Task<TransporteModel> CreateAsync(TransporteModel transporte)
        {
            try
            {
                var matTransporte = await _context.matriculaTransportes.FindAsync(transporte.MatriculaTransporteId);
                var tpTransporte = await _context.tipoDeTransportes.FindAsync(transporte.TipoTransporteId);
                var funcionario = await _context.Funcionarios.FindAsync(transporte.FuncionarioId);
                var manutencao = transporte.ManutencaoId != null ? await _context.manutencaos.FindAsync(transporte.ManutencaoId.Value) : null;


                if (matTransporte == null)
                {
                    throw new InvalidOperationException("A matricula do Transporte especificada não foi encontrada.");
                }
                if (tpTransporte == null)
                {
                    throw new InvalidOperationException("O tipo de Transporte especificada não foi encontrada.");
                }
                if (funcionario == null)
                {
                    throw new InvalidOperationException("O Funcionario especificada não foi encontrada.");
                }

                transporte.Funcionario = funcionario;
                transporte.TipoDeTransportes = tpTransporte;
                transporte.MatriculaTransporte = matTransporte;
                transporte.Manutencao = manutencao;


                _context.transportes.Add(transporte);

                await _context.SaveChangesAsync();

                return transporte;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar Transporte no banco de dados.", ex);
            }
        }

        public async Task<TransporteModel> UpdateAsync(TransporteModel transporte)
        {
            TransporteModel transporteDb = await GetByIdAsync(transporte.Id);

            if (transporteDb == null)
            {
                throw new Exception("Houve um erro na atualização do Transporte!");
            }

            transporteDb.MatriculaTransporte = transporte.MatriculaTransporte;
            transporteDb.TipoDeTransportes = transporte.TipoDeTransportes;
            transporteDb.Funcionario = transporte.Funcionario;
            transporteDb.Manutencao = transporte.Manutencao; 
            transporteDb.DataInicio = transporte.DataInicio;
            transporteDb.DataFim = transporte.DataFim;

            _context.transportes.Update(transporteDb);
            await _context.SaveChangesAsync();

            return transporteDb;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            TransporteModel transporteDb = await GetByIdAsync(id);

            if (transporteDb == null) throw new Exception("Houve um erro ao apagar o Transporte!");

            _context.transportes.Remove(transporteDb);
            await _context.SaveChangesAsync();
            return true;
        }

        
    }
}
