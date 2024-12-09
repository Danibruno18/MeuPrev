using MeuPrev.Models;

namespace MeuPrev.Service
{
    public class PrevidenciaService
    {
        public (int anos, int meses, int dias) SomarPeriodosPorCargo(Servidor servidor, string cargo)
        {
            if (servidor == null) throw new ArgumentNullException(nameof(servidor));

            int totalDias = 0, totalMeses = 0, totalAnos = 0;

            if (servidor.TempoAtual != null)
            {
                var periodosAtuais = servidor.TempoAtual.Where(t => t.Cargo == cargo);
                totalAnos += periodosAtuais.Sum(t => t.Anos);
                totalMeses += periodosAtuais.Sum(t => t.Meses);
                totalDias += periodosAtuais.Sum(t => t.Dias);
            }

            if (servidor.TempoAnterior != null)
            {
                var periodosAnteriores = servidor.TempoAnterior.Where(t => t.Cargo == cargo);
                totalAnos += periodosAnteriores.Sum(t => t.Anos);
                totalMeses += periodosAnteriores.Sum(t => t.Meses);
                totalDias += periodosAnteriores.Sum(t => t.Dias);
            }

            totalMeses += totalDias / 30;
            totalDias %= 30;
            totalAnos += totalMeses / 12;
            totalMeses %= 12;

            return (totalAnos, totalMeses, totalDias);
        }
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
        public int CalcularTempoPorCargo(Servidor servidor, string cargo)
        {
            if (servidor == null) throw new ArgumentNullException(nameof(servidor));

            int totalDias = 0;

            if (servidor.TempoAtual != null)
            {
                totalDias += servidor.TempoAtual
                    .Where(t => t.Cargo == cargo)
                    .Sum(t => t.ToDias());
            }

            if (servidor.TempoAnterior != null)
            {
                totalDias += servidor.TempoAnterior
                    .Where(t => t.Cargo == cargo)
                    .Sum(t => t.ToDias());
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
        public List<string> ValidarServidor(Servidor servidor)
        {
            if (servidor == null)
                return new List<string> { "O servidor é nulo." };

            return servidor.Validar();
        }

        public HistoricoAlteracao AtualizarSituacao(Servidor servidor, string novaSituacao, string responsavel)
        {
            if (servidor == null) throw new ArgumentNullException(nameof(servidor));

            var situacaoAntiga = servidor.Situacao;
            servidor.AtualizarSituacao(novaSituacao);

            var historico = new HistoricoAlteracao
            {
                ServidorId = servidor.Id,
                SituacaoAntiga = situacaoAntiga,
                SituacaoNova = novaSituacao,
                DataAlteracao = DateTime.Now,
                Responsavel = responsavel
            };

            return historico;
        }
    }
}
