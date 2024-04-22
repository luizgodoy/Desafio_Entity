namespace Desafio_Core.Models
{
    public class Contato : EntityBase
    {
        public string Descricao { get; set; }
        
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public int TipoContatoId { get; set; }
        public virtual TipoContato TipoContato { get; set; }
    }
}