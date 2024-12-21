using Microsoft.AspNetCore.Mvc;
using Dto;
using LogicaDeNegocio.Exceptions;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using LogicaDeAplicacion.InterfacesCU.IDisciplinaCU;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisciplinasController : ControllerBase
    {
        private readonly ICrearDisciplina _crearDisciplina;
        private readonly IEliminarDisciplina _eliminarDisciplina;
        private readonly IModificarDisciplina _modificarDisciplina;
        private readonly IGetDisciplinas _getDisciplinas;
        private readonly IGetDisciplinaPorId _getDisciplinaPorId;
        private readonly IGetDisciplinasPorNombre _getDisciplinasPorNombre;


        public DisciplinasController(ICrearDisciplina crearDisciplina,
                                    IEliminarDisciplina eliminarDisciplina,
                                    IModificarDisciplina modificarDisciplina,
                                    IGetDisciplinas getDisciplinas,
                                    IGetDisciplinaPorId getDisciplinaPorId,
                                    IGetDisciplinasPorNombre getDisciplinasPorNombre)
        {
            _crearDisciplina = crearDisciplina;
            _eliminarDisciplina = eliminarDisciplina;
            _modificarDisciplina = modificarDisciplina;
            _getDisciplinas = getDisciplinas;
            _getDisciplinaPorId = getDisciplinaPorId;
            _getDisciplinasPorNombre = getDisciplinasPorNombre;
        }

        [HttpGet()]
        public IActionResult Get([FromQuery] string? name = "")
        {
            return Ok(_getDisciplinasPorNombre.Ejecutar(name));
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetDisciplinas()
        {
            return Ok(_getDisciplinas.Ejecutar());
        }

        [Authorize]
        [HttpGet("BuscarPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                DisciplinaDto disciplinaDto = _getDisciplinaPorId.Ejecutar(id);
                return Ok(disciplinaDto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [Authorize]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearDisciplina([FromBody] DisciplinaDto disciplinaDto)
        {
            try
            {
                string emailUsuario = "";
                _crearDisciplina.Ejecutar(disciplinaDto, emailUsuario);
                return Ok(disciplinaDto);
            }
            catch (DatoInvalidoException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult EliminarDisciplina(int id)
        {
            try
            {
                string emailUsuario = "";
                _eliminarDisciplina.Ejecutar(id, emailUsuario);
                return Ok("Disciplina eliminada");
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ModificarDisciplina(int id, [FromBody] DisciplinaDto disciplinaDto)
        {
            try
            {
                string emailUsuario = "";
                _modificarDisciplina.Ejecutar(id, disciplinaDto, emailUsuario);
                return Ok("Disciplina actualizada");
            } 
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DisciplinaInvalidaException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
