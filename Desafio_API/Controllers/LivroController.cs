using Desafio_API.Input;
using Desafio_Core.DTO;
using Desafio_Core.Models;
using Desafio_Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;

        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                return Ok(_livroRepository.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var livrosDto = new List<LivroDto>();
                var livros = _livroRepository.GetAll();

                foreach (var livro in livros)
                {
                    livrosDto.Add(new LivroDto()
                    {
                        Id = livro.Id,
                        DataCriacao = livro.DataAtualizacao,
                        Nome = livro.Nome,
                        Editora = livro.Editora,
                        Pedidos = livro.Pedidos.Select(pedido => new PedidoDto()
                        {
                            ClienteId = pedido.ClienteId,
                            LivroId = pedido.LivroId,
                        }).ToList()
                    });
                }

                return Ok(livrosDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] LivroInput input)
        {
            try
            {
                var livro = new Livro()
                {
                    Nome = input.Nome,
                    Editora = input.Editora,
                };
                _livroRepository.Create(livro);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] LivroUpdateInput input)
        {
            try
            {
                var livro = _livroRepository.GetById(input.Id);
                livro.Nome = input.Nome;
                livro.Editora = input.Editora;
                _livroRepository.Update(livro);
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
                _livroRepository.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
      
        [HttpPost("cadastro-em-massa")]
        public IActionResult CadastroEmMassa()
        {
            try
            {
                var livros = new List<Livro>() {
                    new Livro() { Nome = "SQL Server Completo de Total", Editora = "Jurumirim" },
                    new Livro() { Nome = "C# Guia de passagens parao céu", Editora = "Proxies" },
                    new Livro() { Nome = "Java Certification Guide", Editora = "Marajo" },
                    new Livro() { Nome = "Steve Jobs: a cabeça", Editora = "Sextante" },
                    new Livro() { Nome = "Por que o Brasil é um país atrasado", Editora = "Moura" },
                    new Livro() { Nome = "Negócios Digitais", Editora = "Graxie" },
                    new Livro() { Nome = "100 ensaios", Editora = "Empiricus" },
                    new Livro() { Nome = "Metanoia", Editora = "Kenedy" },
                    new Livro() { Nome = "Dark side of the sun", Editora = "Medieval" },
                    new Livro() { Nome = "Costa Diadema", Editora = "Ultramarine" },
                };

                _livroRepository.CadastrarEmMassa(livros);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}