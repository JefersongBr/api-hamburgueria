using System.Collections.ObjectModel;

namespace APIHamburgueria.Models
{
    public class Cliente
    {
        public Cliente()
        {
            Pedidos = new Collection<Pedido>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public int NumeroTelefone { get; set; }

        public ICollection<Pedido>? Pedidos { get; set; }
        public Endereco? Endereco { get; set; }

    }
}
