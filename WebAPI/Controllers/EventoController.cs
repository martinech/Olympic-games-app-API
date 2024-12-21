using Microsoft.AspNetCore.Mvc;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using Dto;
using LogicaDeNegocio.Exceptions;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IGetEventosPorIdAtleta _getEventosPorIdAtleta;

        public EventoController(IGetEventosPorIdAtleta getEventosPorIdAtleta)
        {
            _getEventosPorIdAtleta = getEventosPorIdAtleta;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int id)
        {
            try
            {
                List<EventoDto> eventos = _getEventosPorIdAtleta.Ejecutar(id);
                if (!eventos.Any())
                {
                    return BadRequest("No se encontraron eventos para el atleta con el ID proporcionado.");
                }
                return Ok(eventos);
            }
            catch (DatoInvalidoException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
