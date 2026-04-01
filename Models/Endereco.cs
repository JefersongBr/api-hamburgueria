namespace APIHamburgueria.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int NumeroCasa { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
