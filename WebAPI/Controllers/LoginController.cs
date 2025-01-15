using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;
using LogicaDeNegocio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginUsuario _loginUsuario;

        public LoginController(ILoginUsuario loginUsuario)
        {
            _loginUsuario = loginUsuario;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Login([FromBody] Credenciales credenciales)
        {
            if (!credenciales.SonValidas())
                return BadRequest("Faltan datos");

            if (_loginUsuario.Ejecutar(credenciales.Email, credenciales.Password) == null)
                return Unauthorized("Datos incorrectos");

            return Ok(_loginUsuario.Ejecutar(credenciales.Email, credenciales.Password));
        }
    }
}
