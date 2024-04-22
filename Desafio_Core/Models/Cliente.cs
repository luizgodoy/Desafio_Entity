using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_Core.Models
{
    public class Cliente : EntityBase
    {
        public required string Nome { get; set; }
        public int CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}