using Desafio_API.Input;
using Desafio_Core.Models;
using Desafio_Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Desafio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEnderecoController : ControllerBase
    {
        private readonly ITipoEnderecoRepository _tipoEnderecoRepository;

        public TipoEnderecoController(ITipoEnderecoRepository tipoEnderecoRepository)
        {
            _tipoEnderecoRepository = tipoEnderecoRepository;
        }

        // GET: api/<TipoEnderecoController>
        [HttpGet]
        public IActionResult Get()
        {
            try { 
                return Ok(_tipoEnderecoRepository.GetAll());
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
                return Ok(_tipoEnderecoRepository.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<TipoEnderecoController>
        [HttpPost]
        public IActionResult Post([FromBody] TipoEnderecoInput input)
        {
            try
            {
                var tipoEndereco = new TipoEndereco()
                {
                    Descricao = input.Descricao
                };

                _tipoEnderecoRepository.Create(tipoEndereco);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<TipoEnderecoController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] TipoEnderecoUpdateInput input)
        {
            try
            {
                var tipoEndereco = _tipoEnderecoRepository.GetById(input.Id);
                tipoEndereco.Descricao = input.Descricao;
                
                _tipoEnderecoRepository.Update(tipoEndereco);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<TipoEnderecoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromQuery] int id)
        {
            try
            {
                _tipoEnderecoRepository.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}