using LogicaDeAplicacion.InterfacesCU.IDisciplinaCU;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtletasController : ControllerBase
    {
        private readonly IGetAtletas _getAtletas;
        private readonly IGetDisciplinaPorId _getDisciplinaPorId;
        private readonly IGetAtletasPorDisciplina _getAtletasPorDisciplina;

        public AtletasController(   IGetAtletasPorDisciplina getAtletasPorDisciplina,
                                    IGetAtletas getAtletas,
                                    IGetDisciplinaPorId getDisciplinaPorId)
        {
            _getAtletas = getAtletas;
            _getDisciplinaPorId = getDisciplinaPorId;
            _getAtletasPorDisciplina = getAtletasPorDisciplina;
        }

        [HttpGet("listaGral")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAtletas()
        {
            return Ok(_getAtletas.Ejecutar());
        }

        [HttpGet("atletasPorDisciplina/{idDisciplina}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAtletasPorIdDisciplina(int idDisciplina)
        {
            if (idDisciplina < 1)
                return BadRequest("El id no puede ser menor a 1");

            if (_getDisciplinaPorId.Ejecutar(idDisciplina) == null)
                return NotFound("No existe disciplina con ese Id");

            return Ok(_getAtletasPorDisciplina.Ejecutar(idDisciplina));
        }
    }
}
