using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Controle_de_Transporte.Models
{
    public class TransporteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TipoTransporteId { get; set; }
        public int FuncionarioId { get; set; }
        public int MatriculaTransporteId { get; set; }
        public int? ManutencaoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        [NotMapped]
        [ForeignKey("TipoTransporteId")]
        public virtual TipoDeTransporteModel? TipoDeTransporte { get; set; }

        [NotMapped]
        [ForeignKey("FuncionarioId")]
        public virtual FuncionariosModel? Funcionario { get; set; }

        [NotMapped]
        [ForeignKey("MatriculaTransporteId")]
        public virtual MatriculaTransporteModel? MatriculaTransporte { get; set; }

        [NotMapped]
        [ForeignKey("ManutencaoId")]
        public virtual ManutencaoModel? Manutencao { get; set; }
    }
}
