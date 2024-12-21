using Dto;
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
        public IActionResult Login([FromBody] Credenciales credenciales)
        {
            if (credenciales == null)
            {
                return BadRequest("Faltan credenciales");
            }
            try
            {
                string email = credenciales.Email;
                string password = credenciales.Password;
                if (email == null || password == null)
                {
                    return BadRequest("Falta email o contraseña");
                }
                else
                {
                    UsuarioDto usuario = _loginUsuario.Ejecutar(email, password);
                    return Ok(usuario);
                }                
            }
            catch (UsuarioInvalidoException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
