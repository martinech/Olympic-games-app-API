using Dto;
using LogicaDeAplicacion.ImplementacionCU.AtletaCU;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Obligatorio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtletasController : ControllerBase
    {
        private readonly IGetAtletasPorDisciplina _getAtletasPorDisciplina;

        public AtletasController(IGetAtletasPorDisciplina getAtletasPorDisciplina)
        {
            _getAtletasPorDisciplina = getAtletasPorDisciplina;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([FromQuery] int? id = null)
        {
            try
            {
                if (id == null)
                {
                    var atletasConDisciplinaVacia = new List<AtletaDto>();
                    return Ok(atletasConDisciplinaVacia);
                }

                List<AtletaDto> atletasConDisciplina = _getAtletasPorDisciplina.Ejecutar((int)id);
                if (atletasConDisciplina.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(atletasConDisciplina);
                }
           
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
