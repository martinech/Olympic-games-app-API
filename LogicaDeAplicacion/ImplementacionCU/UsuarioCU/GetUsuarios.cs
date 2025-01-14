using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;
using LogicaDeNegocio.InterfacesRepositorios;
using Dto;

namespace LogicaDeAplicacion.ImplementacionCU.UsuarioCU
{
    public class GetUsuarios : IGetUsuarios
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        public GetUsuarios(IRepositorioUsuario repositorio)
        {
            _repositorioUsuario = repositorio;
        }
        public IEnumerable<UsuarioDto> Ejecutar()
        {
            return _repositorioUsuario.GetUsuarios().Select(usuario => new UsuarioDto(usuario));
        }
    }
}
