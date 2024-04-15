using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Controle_de_Transporte.Models
{
    public class InstituicaoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string NomeInstituicao { get; set; }

        [Required]
        public string CNPJ { get; set; }
    }
}
