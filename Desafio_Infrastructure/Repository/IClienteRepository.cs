using Desafio_Core.DTO;
using Desafio_Core.Models;

namespace Desafio_Infrastructure.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        ClienteDto ObterPedidosSeisMeses(int id);
    }
}