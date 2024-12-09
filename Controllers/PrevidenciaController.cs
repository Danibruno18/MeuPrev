using MeuPrev.Models;
using MeuPrev.Service;
using Microsoft.AspNetCore.Mvc;

namespace MeuPrev.Controllers
{
    public class PrevidenciaController : Controller
    {
        private readonly PrevidenciaService _previdenciaService;

        public PrevidenciaController()
        {
            _previdenciaService = new PrevidenciaService();
        }

        public IActionResult CalcularTempo(int servidorId)
        {
            var servidor = ObterServidorPorId(servidorId);

            if (servidor == null)
                return NotFound("Servidor não encontrado.");

            int totalDias = _previdenciaService.CalcularTempoTotal(servidor);
            string tempoFormatado = _previdenciaService.ConverterDiasParaFormato(totalDias);

            return Json(new { TotalDias = totalDias, TempoFormatado = tempoFormatado });
        }

        private static Servidor ObterServidorPorId(int id)
        {
            return new Servidor
            {
                Id = id,
                Nome = "João Silva",
                TempoAtual = new List<TempoContribuicao>
        {
            new() { Anos = 10, Meses = 0, Dias = 0, Cargo = "Professor" },
            new() { Anos = 2, Meses = 3, Dias = 15, Cargo = "Coordenador" }
        },
                TempoAnterior = new List<TempoContribuicao>
        {
            new() { Anos = 5, Meses = 0, Dias = 10, Cargo = "Professor" }
        }
            };
        }

        public IActionResult AlterarSituacao(int servidorId, string novaSituacao, string responsavel)
        {
            var servidor = ObterServidorPorId(servidorId);

            if (servidor == null)
                return NotFound("Servidor não encontrado.");

            var historico = _previdenciaService.AtualizarSituacao(servidor, novaSituacao, responsavel);

            return Json(new
            {
                Sucesso = true,
                Mensagem = $"Situação alterada com sucesso para {novaSituacao}.",
                Historico = historico
            });
        }
        public IActionResult CalcularTempoPorCargo(int servidorId, string cargo)
        {
            var servidor = ObterServidorPorId(servidorId);

            if (servidor == null)
                return NotFound("Servidor não encontrado.");

            int totalDias = _previdenciaService.CalcularTempoPorCargo(servidor, cargo);
            string tempoFormatado = _previdenciaService.ConverterDiasParaFormato(totalDias);

            return Json(new
            {
                Sucesso = true,
                Cargo = cargo,
                TotalDias = totalDias,
                TempoFormatado = tempoFormatado
            });
        }

        public IActionResult SomarPeriodosPorCargo(int servidorId, string cargo)
        {
            var servidor = ObterServidorPorId(servidorId);

            if (servidor == null)
                return NotFound("Servidor não encontrado.");

            var (anos, meses, dias) = _previdenciaService.SomarPeriodosPorCargo(servidor, cargo);

            return Json(new
            {
                Sucesso = true,
                Cargo = cargo,
                TempoTotal = new { Anos = anos, Meses = meses, Dias = dias },
                TempoFormatado = $"{anos} anos, {meses} meses, {dias} dias"
            });
        }

    }
}
