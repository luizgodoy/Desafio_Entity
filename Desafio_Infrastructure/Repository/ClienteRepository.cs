using Desafio_Core.DTO;
using Desafio_Core.Models;

namespace Desafio_Infrastructure.Repository
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(PostgreContext context) : base(context)
        {
        }       

        public ClienteDto ObterPedidosSeisMeses(int id)
        {
            var cliente = _context.Cliente.FirstOrDefault(c => c.Id == id) 
                ?? throw new Exception("Registro não encontrado!");

            return new ClienteDto()
            {
                Id = cliente.Id,
                DataCriacao = cliente.DataAtualizacao,
                Nome = cliente.Nome,
                DataNascimento = cliente.DataNascimento,
                Pedidos = cliente.Pedidos
                    .Where(c => c.DataAtualizacao >= DateTime.Now.AddMonths(-6))
                    .Select(pedido => new PedidoDto()
                    {
                        Id = pedido.Id,
                        DataCriacao = pedido.DataAtualizacao,
                        LivroId = pedido.LivroId,
                        ClienteId = pedido.ClienteId,
                        Livro = new LivroDto()
                        {
                            Id = pedido.Livro.Id,
                            DataCriacao = pedido.Livro.DataAtualizacao,
                            Nome = pedido.Livro.Nome,
                            Editora = pedido.Livro.Editora
                        }
                    }).ToList()
            };
        }
    }
}