using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIHamburgueria.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Column(TypeName = "decimal (10,2)")]
        public decimal Valor { get; set; }
    }
}
