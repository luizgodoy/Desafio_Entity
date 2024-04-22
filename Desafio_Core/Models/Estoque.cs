namespace Desafio_Core.Models
{
    public class Estoque : EntityBase
    {
        public int Quantidade { get; set; }

        public int LivroId { get; set; }        
        public virtual Livro Livro { get; set; }
    }
}