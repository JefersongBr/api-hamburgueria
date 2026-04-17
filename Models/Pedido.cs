using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIHamburgueria.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        [Required]
        public DateTime DataPedido { get; set; }

        [Column(TypeName = "decimal (10,2)")]
        public decimal ValorTotal { get; set; }

        public string Status { get; set; }

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }
    }
}
