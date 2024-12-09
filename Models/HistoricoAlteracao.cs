namespace MeuPrev.Models
{
    public class HistoricoAlteracao
    {
        public int Id { get; set; }
        public int ServidorId { get; set; }
        public string? SituacaoAntiga { get; set; }
        public string? SituacaoNova { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string? Responsavel { get; set; }
    }
}
