namespace PrimeiraapiGael.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Pais { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public decimal SalarioAnual { get; set; }
    }
}
