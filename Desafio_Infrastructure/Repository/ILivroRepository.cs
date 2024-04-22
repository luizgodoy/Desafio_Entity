using Desafio_Core.Models;

namespace Desafio_Infrastructure.Repository
{
    public interface ILivroRepository : IRepository<Livro>
    {
        void CadastrarEmMassa(IEnumerable<Livro> livros);
    }
}
