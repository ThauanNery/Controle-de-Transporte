using System;
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

        [ForeignKey("TipoTransporteId")]
        public virtual TipoDeTransporteModel? TipoTransportes { get; set; }

        [ForeignKey("FuncionarioId")]
        public virtual FuncionariosModel? Funcionario { get; set; }

        [ForeignKey("MatriculaTransporteId")]
        public virtual MatriculaTransporteModel? MatriculaTransporte { get; set; }

        [ForeignKey("ManutencaoId")]
        public virtual ManutencaoModel? Manutencao { get; set; }
    }
}
