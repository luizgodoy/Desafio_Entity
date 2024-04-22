using Desafio_Core.Models;

namespace Desafio_Infrastructure.Repository
{
    public class TipoEnderecoRepository : EFRepository<TipoEndereco>, ITipoEnderecoRepository
    {
        public TipoEnderecoRepository(PostgreContext context) : base(context)
        {
        }
    }
}