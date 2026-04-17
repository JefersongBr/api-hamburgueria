using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public ICollection<Pedido>? Pedidos { get; set; }
        [JsonIgnore]
        public Endereco? Endereco { get; set; }

    }
}
