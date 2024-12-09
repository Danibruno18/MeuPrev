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

        private Servidor ObterServidorPorId(int id)
        {
            return new Servidor
            {
                Id = id,
                Nome = "João Silva",
                CargoHibrido = true,
                TempoAtual = new List<TempoContribuicao>
            {
                new TempoContribuicao { Anos = 10, Meses = 5, Dias = 15 }
            },
                TempoAnterior = new List<TempoContribuicao>
            {
                new TempoContribuicao { Anos = 5, Meses = 0, Dias = 10 }
            }
            };
        }
    }

}
