using System.ComponentModel.DataAnnotations;

namespace MeuPrev.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }
        [Required]
        public Sexo Sexo { get; set; }
        [Required]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string? Rg { get; set; }
    }

    public enum Sexo : int
    {
        MASCULINO = 0,
        FEMININO = 1
    }
}
