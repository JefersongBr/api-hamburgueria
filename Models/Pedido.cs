namespace APIHamburgueria.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public string Status { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}
