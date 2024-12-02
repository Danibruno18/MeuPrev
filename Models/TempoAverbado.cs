using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeuPrev.Models
{
    public class TempoAverbado
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Funcionario")]
        public int Matricula { get; set; }

        [Required]
        [MaxLength(100)]
        public string Cargo { get; set; } = string.Empty;

        [Required]
        public DateTime DataAdmissao { get; set; }

        [Required]
        public DateTime DataDemissao { get; set; }

        public int TotalDias { get; set; }

        public Funcionario? Funcionario { get; set; }
    }
}
