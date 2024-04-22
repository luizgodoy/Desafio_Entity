using Desafio_API.Input;
using Desafio_Core.Models;
using Desafio_Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_clienteRepository.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                return Ok(_clienteRepository.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("pedidos-seis-meses/{id:int}")]
        public IActionResult ClienteEPedidosSeisMeses([FromRoute] int id)
        {
            try
            {
                var x = _clienteRepository.ObterPedidosSeisMeses(id);
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClienteInput input)
        {
            try
            {
                var cliente = new Cliente()
                {
                    Nome = input.Nome,
                    CPF = input.CPF,
                    DataNascimento = input.DataNascimento
                };

                _clienteRepository.Create(cliente);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] ClienteUpdateInput input)
        {
            try
            {
                var cliente = _clienteRepository.GetById(input.Id);
                cliente.Nome = input.Nome;
                cliente.CPF = input.CPF;
                cliente.DataNascimento = input.DataNascimento;

                _clienteRepository.Update(cliente);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Put([FromRoute] int id)
        {
            try
            {
                _clienteRepository.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}