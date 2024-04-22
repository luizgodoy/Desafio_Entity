namespace Desafio_Core.Models
{
    public class Endereco : EntityBase
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int TipoEnderecoId { get; set; }
        public virtual TipoEndereco TipoEndereco {get; set;}
    }
}