using MeuPrev.Models;

namespace MeuPrev.Service
{
    public class PrevidenciaService
    {
        public int CalcularTempoTotal(Servidor servidor)
        {
            int totalDias = 0;

            if (servidor.TempoAtual != null)
            {
                totalDias += servidor.TempoAtual.Sum(t => t.ToDias());
            }

            if (servidor.TempoAnterior != null)
            {
                totalDias += servidor.TempoAnterior.Sum(t => t.ToDias());
            }

            if (servidor.CargoHibrido)
            {
                totalDias = (int)(totalDias * 0.75);
            }

            return totalDias;
        }

        public string ConverterDiasParaFormato(int totalDias)
        {
            int anos = totalDias / 365;
            totalDias %= 365;
            int meses = totalDias / 30;
            int dias = totalDias % 30;

            return $"{anos} anos, {meses} meses, {dias} dias";
        }
    }

}
