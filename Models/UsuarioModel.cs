namespace Controle_de_Transporte.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int FuncionarioId { get; set; }

        public virtual FuncionariosModel Funcionarios { get; set; }
    }
}
