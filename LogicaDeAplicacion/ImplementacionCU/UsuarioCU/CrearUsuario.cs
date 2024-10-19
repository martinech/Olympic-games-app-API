using Dto;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;
using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;
using LogicaDeNegocio.Exceptions;

namespace LogicaDeAplicacion.ImplementacionCU.UsuarioCU
{
    public class CrearUsuario : ICrearUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public CrearUsuario(IRepositorioUsuario repositorio)
        {
            _repositorioUsuario = repositorio;
        }
        public void Ejecutar(UsuarioDto usuarioDto)
        {
            IEnumerable<Usuario> usuariosExistentes = _repositorioUsuario.GetUsuarios();
            if (usuariosExistentes.Any(u => u.Email.Equals(usuarioDto.Email)))
            {
                throw new DatoInvalidoException("Ya existe un usuario con ese nombre.");
            }
            Usuario usuarioNuevo = usuarioDto.ToUsuario();
                usuarioNuevo.Validar();
                _repositorioUsuario.Crear(usuarioNuevo);
            }
        }
    }
