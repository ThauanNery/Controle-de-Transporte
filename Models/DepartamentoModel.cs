using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_de_Transporte.Models
{
    public class DepartamentoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NomeDepartamento { get; set; }
        public int InstituicaoId { get; set; }

        [ForeignKey("InstituicaoId")]
        public virtual InstituicaoModel Instituicao { get; set;}
    }
}
