namespace MeuPrev.Models
{
    public class TempoContribuicao
    {
        public int Dias { get; set; }
        public int Meses { get; set; }
        public int Anos { get; set; }

        public int ToDias()
        {
            return Dias + (Meses * 30) + (Anos * 365);
        }
    }
}
