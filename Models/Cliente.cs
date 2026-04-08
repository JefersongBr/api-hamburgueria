using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace APIHamburgueria.Models
{
    public class Cliente
    {
        public Cliente()
        {
            Pedidos = new Collection<Pedido>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        public int NumeroTelefone { get; set; }

        public ICollection<Pedido>? Pedidos { get; set; }
        public Endereco? Endereco { get; set; }

    }
}
