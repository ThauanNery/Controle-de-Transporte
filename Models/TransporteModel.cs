﻿namespace Controle_de_Transporte.Models
{
    public class TransporteModel
    {
        public int Id { get; set; }
        public int TipoTransporteId { get; set; }
        public int MatriculaFuncionarioId { get; set; }
        public int MatriculaTransporteId { get; set; }
        public int ManutencaoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public virtual TipoDeTransporteModel TipoDeTransporte { get; set; }
        public virtual MatriculaFuncionarioModel MatriculaFuncionario { get; set; }
        public virtual MatriculaTransporteModel MatriculaTransporte { get; set; }
        public virtual ManutencaoModel Manutencao { get; set; }
    }
}
