using Controle_de_Transporte.Models;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_Transporte.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<InstituicaoModel> Instituicaos { get; set; }
        public DbSet<DepartamentoModel> Departamentos { get; set; }
        public DbSet<CargoModel> Cargos { get; set; }
        public DbSet<MatriculaFuncionarioModel> matriculaFuncionarios { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<FuncionariosModel> Funcionarios { get; set; }
        public DbSet<MatriculaTransporteModel> matriculaTransportes { get; set; }
        public DbSet<TipoDeTransporteModel> tipoDeTransportes { get; set; }
        public DbSet<ManutencaoModel> manutencaos { get; set; }
        public DbSet<TransporteModel> transportes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartamentoModel>()
                .HasOne(d => d.Instituicao)
                .WithMany()
                .HasForeignKey(d => d.InstituicaoId);

            modelBuilder.Entity<MatriculaFuncionarioModel>()
                .HasOne(d => d.Funcionarios)
                .WithMany()
                .HasForeignKey(d => d.FuncionarioId);
            
            modelBuilder.Entity<FuncionariosModel>()
                .HasOne(d => d.Departamento)
                .WithMany()
                .HasForeignKey(d => d.DepartamentoId);
            
            modelBuilder.Entity<FuncionariosModel>()
                .HasOne(d => d.Cargo)
                .WithMany()
                .HasForeignKey(d => d.CargoId);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Leia a string de conexão do arquivo appsettings.json
        //    var configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    var connectionString = configuration.GetConnectionString("MyDatabase");
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

    }
}
