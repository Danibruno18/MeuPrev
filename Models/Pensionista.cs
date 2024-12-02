namespace MeuPrev.Models
{
    public class Pensionista
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int InstituidorPensao { get; set; }
    }
}
