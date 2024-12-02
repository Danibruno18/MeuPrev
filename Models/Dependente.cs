using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeuPrev.Models
{
    public class Dependente
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(100)] 
        public string Nome { get; set; } = string.Empty;

        [ForeignKey("Pai")]
        public int? PaiId { get; set; } 

        [ForeignKey("Mae")]
        public int? MaeId { get; set; }

        public Pessoa? Pai { get; set; }
        public Pessoa? Mae { get; set; }
    }
}
