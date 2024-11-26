using System.ComponentModel.DataAnnotations;

namespace MeuPrev.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public int Matricula {  get; set; }
        [Display(Name = "Pessoa")]

        public int PessoaId { get; set; }
        [Display(Name = "Situação Funcional")]
        public SituacaoFuncional SituacaoFuncional { get; set; }
        [Display(Name = "Situação")]
        public Situacao Situacao {  get; set; }
        [DataType (DataType.Date)]
        [Display(Name = "Data de Admissão")]
        public DateTime DataAdmissao { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data de Demissão")]
        public DateTime DataDemissao { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data de Aposentadoria")]
        public DateTime DataAposentadoria { get; set; }
        [DataType (DataType.Date)]
        [Display(Name = "Data de Falecimento")]
        public DateTime DataFalecimentos { get; set; }
        public int CargoId { get; set; }
    }

    public enum SituacaoFuncional : int
    {
        Vivo = 0,
        Exonerado = 1,
        Falecido = 2
    }

    public enum Situacao : int
    {
        Ativo = 0,
        Aposentado = 1,
        Pensionista = 2
    }

}
