using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_Core.Models
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}