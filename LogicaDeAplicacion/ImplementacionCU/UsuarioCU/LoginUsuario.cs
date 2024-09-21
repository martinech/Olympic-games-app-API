using Dto;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;

namespace LogicaDeAplicacion.ImplementacionCU.UsuarioCU
{
    public class LoginUsuario : ILoginUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public LoginUsuario(IRepositorioUsuario repositorio)
        {
            _repositorioUsuario = repositorio;
        }
        public UsuarioDto Ejecutar(string email, string password)
        {
            Usuario usuarioLogueado = _repositorioUsuario.Login(email, password);

            if (usuarioLogueado is not null)
            {
                UsuarioDto usuarioDto = new UsuarioDto(usuarioLogueado);
                return usuarioDto;
            }
            else
                throw new UsuarioInvalidoException("Datos incorrectos");
        }
    }
}
