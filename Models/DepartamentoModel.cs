namespace Controle_de_Transporte.Models
{
    public class DepartamentoModel
    {
        public int Id { get; set; }
        public string NomeDepartamento { get; set; }
        public int InstituicaoId { get; set; }
        public virtual InstituicaoModel Instituicao { get; set;}
    }
}
