using Dto;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;
using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;

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
            Usuario usuarioNuevo = usuarioDto.ToUsuario();
            usuarioNuevo.Validar();
            _repositorioUsuario.Crear(usuarioNuevo);
        }
    }
}
