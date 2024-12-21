using Microsoft.AspNetCore.Mvc;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using Dto;
using LogicaDeNegocio.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IGetEventosPorIdAtleta _getEventosPorIdAtleta;
        private readonly IGetEventosPorDisciplina _getEventosPorDisciplina;
        private readonly IGetEventosPorNombre _getEventosPorNombre;
        private readonly IGetEventosPorFechas _getEventosPorFechas;
        private readonly IGetEventosPorPuntajes _getEventosPorPuntajes;

        public EventosController(IGetEventosPorIdAtleta getEventosPorIdAtleta,
                                IGetEventosPorDisciplina geteventosPorDisciplina,
                                IGetEventosPorNombre getEventosPorNombre,
                                IGetEventosPorFechas getEventosPorFechas,
                                IGetEventosPorPuntajes getEventosPorPuntajes)
        {
            _getEventosPorIdAtleta = getEventosPorIdAtleta;
            _getEventosPorDisciplina = geteventosPorDisciplina;
            _getEventosPorNombre = getEventosPorNombre;
            _getEventosPorFechas = getEventosPorFechas;
            _getEventosPorPuntajes = getEventosPorPuntajes;
        }

        [Authorize]
        [HttpGet("BuscarPorIdDisciplina")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetEventoPorDisciplina([FromQuery]int id)
        {
            try
            {
                if (id == null)
                {
                    var eventosConDisciplinaVacia = new List<EventoDto>();
                    return Ok(eventosConDisciplinaVacia);
                }
                if (id < 0)
                {
                    return BadRequest("El ID debe ser mayor a 0");
                }
                List<EventoDto> eventos = _getEventosPorDisciplina.Ejecutar(id);
                if (eventos.Count == 0)
                {
                    return BadRequest("No se encontraron eventos para la disciplina con el ID proporcionado.");
                }
                return Ok(eventos);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [Authorize]
        [HttpGet("BuscarPorNombre")]
        public IActionResult Get([FromQuery] string? nombre = "")
        {
            return Ok(_getEventosPorNombre.Ejecutar(nombre));
        }

        [Authorize]
        [HttpGet("BuscarPorFechas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetEventosPorFechas([FromQuery] DateTime? fechaInicio,[FromQuery] DateTime? fechaFin)
        {
            try
            {
                if (fechaInicio == null || fechaFin == null)
                {
                    return BadRequest("Debe proporcionar 2 fechas");
                }
                else if (fechaInicio == null && fechaFin == null)
                {
                    var eventosVacia = new List<EventoDto>();
                    return Ok(eventosVacia);
                }
                else
                {
                    List<EventoDto> eventos = _getEventosPorFechas.Ejecutar((DateTime)fechaInicio, (DateTime)fechaFin);
                    if (eventos.Count == 0)
                        return NotFound("No se encontraron eventos para las fechas proporcionadas");
                    else
                    {
                        return Ok(eventos);
                    }
                }
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [Authorize]
        [HttpGet("BuscarPorPuntajes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetEventosPorPuntajes([FromQuery] int? puntaje1, [FromQuery] int? puntaje2)
        {
            try
            {
                if (puntaje1 < 0 || puntaje2 < 0)
                {
                    return BadRequest("Los puntajes deben ser mayores a 0");
                }
                else if (puntaje1 > puntaje2)
                {
                    return BadRequest("El segundo puntaje debe ser mayor al primero");
                }
                else if (puntaje1 >= 0 && puntaje2 >= 0)
                {
                    List<EventoDto> eventos = _getEventosPorPuntajes.Ejecutar((int)puntaje1, (int)puntaje2);
                    if (eventos.Count == 0)
                        return NotFound("No se encontraron eventos para las fechas proporcionadas");
                    else
                    {
                        return Ok(eventos);
                    }
                }
                return BadRequest();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
