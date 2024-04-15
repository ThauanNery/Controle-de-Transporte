using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_de_Transporte.Models
{
    public class UsuarioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }
        public int FuncionarioId { get; set; }

        public virtual FuncionariosModel Funcionarios { get; set; }
    }
}
