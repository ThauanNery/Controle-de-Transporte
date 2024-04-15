using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_de_Transporte.Models
{
    public class FuncionariosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string NomeFuncionario { get; set; }
        public int DepartamentoId { get; set; }
        public int MatriculaFuncionarioId { get; set; }
        public int CargoId { get; set; }

        public virtual DepartamentoModel Departamento { get; set; }
        public virtual CargoModel Cargo  { get; set; }
        public virtual MatriculaFuncionarioModel Matricula { get; set; }
    }
}
