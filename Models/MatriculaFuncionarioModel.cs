﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_de_Transporte.Models
{
    public class MatriculaFuncionarioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Matricula { get; set; }

        public int FuncionarioId { get; set; }

        [ForeignKey("FuncionarioId")]
        public virtual FuncionariosModel Funcionarios { get; set; }
    }
}
