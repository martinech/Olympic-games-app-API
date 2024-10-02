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
            try
            {
                Usuario usuarioNuevo = usuarioDto.ToUsuario();
                usuarioNuevo.Validar();
                _repositorioUsuario.Crear(usuarioNuevo);
            }
            catch(DatoInvalidoException)
            {
                throw new DatoInvalidoException("Email ya existente");
            }
        }
    }
}
