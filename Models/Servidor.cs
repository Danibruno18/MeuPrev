namespace MeuPrev.Models
{
    public class Servidor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<TempoContribuicao> TempoAtual { get; set; }
        public List<TempoContribuicao> TempoAnterior { get; set; }
        public bool CargoHibrido { get; set; }
    }
}
