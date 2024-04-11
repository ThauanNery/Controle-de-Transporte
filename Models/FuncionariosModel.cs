namespace Controle_de_Transporte.Models
{
    public class FuncionariosModel
    {
        public int Id { get; set; }
        public string NomeFuncionario { get; set; }
        public int DepartamentoId { get; set; }
        public int MatriculaFuncionarioId { get; set; }
        public int CargoId { get; set; }

        public virtual DepartamentoModel Departamento { get; set; }
        public virtual CargoModel Cargo  { get; set; }
        public virtual MatriculaFuncionarioModel Matricula { get; set; }
    }
}
