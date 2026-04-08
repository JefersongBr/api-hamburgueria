using System.ComponentModel.DataAnnotations;

namespace APIHamburgueria.Models
{
    public class Endereco
    {
        public int Id { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Rua { get; set; }

        [Required]
        public int NumeroCasa { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
