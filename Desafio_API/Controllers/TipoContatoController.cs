using Desafio_API.Input;
using Desafio_Core.Models;
using Desafio_Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Desafio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoContatoController : ControllerBase
    {
        private readonly ITipoContatoRepository _tipoContatoRepository;

        public TipoContatoController(ITipoContatoRepository tipoContatoRepository)
        {
            _tipoContatoRepository = tipoContatoRepository;
        }

        // GET: api/<TipoContatoController>
        [HttpGet]
        public IActionResult Get()
        {
            try { 
                return Ok(_tipoContatoRepository.GetAll());
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
                return Ok(_tipoContatoRepository.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<TipoContatoController>
        [HttpPost]
        public IActionResult Post([FromBody] TipoContatoInput input)
        {
            try
            {
                var tipoContato = new TipoContato()
                {
                    Descricao = input.Descricao
                };

                _tipoContatoRepository.Create(tipoContato);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<TipoContatoController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] TipoContatoUpdateInput input)
        {
            try
            {
                var tipoContato = _tipoContatoRepository.GetById(input.Id);
                tipoContato.Descricao = input.Descricao;
                
                _tipoContatoRepository.Update(tipoContato);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<TipoContatoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromQuery] int id)
        {
            try
            {
                _tipoContatoRepository.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}