namespace MeuPrev.Models
{
    public class Servidor
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public DateTime? DataDemissao { get; set; }
        public DateTime? DataFalecimento { get; set; }
        public List<TempoContribuicao>? TempoAtual { get; set; }
        public List<TempoContribuicao>? TempoAnterior { get; set; }
        public bool CargoHibrido { get; set; }
        public string? Situacao { get; private set; }
        public List<string> Validar()
        {
            var erros = new List<string>();

            if (DataAdmissao != null && DataDemissao != null && DataAdmissao > DataDemissao)
            {
                erros.Add("A data de admissão deve ser anterior à data de demissão.");
            }

            if (DataFalecimento != null && DataDemissao != null && DataFalecimento <= DataDemissao)
            {
                erros.Add("A data de falecimento deve ser posterior à data de demissão.");
            }

            return erros;
        }
        public void AtualizarSituacao(string novaSituacao)
        {
            Situacao = novaSituacao;
        }
    }
}

