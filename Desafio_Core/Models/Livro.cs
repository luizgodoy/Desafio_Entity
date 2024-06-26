﻿namespace Desafio_Core.Models
{
    public class Livro : EntityBase
    {
        public required string Nome { get; set; }
        public required string Editora { get; set; }                
        public virtual ICollection<Pedido> Pedidos{ get; set; }
    }
}