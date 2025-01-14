using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;
using Dto;

namespace LogicaDeAplicacion.ImplementacionCU.UsuarioCU
{
    public class GetUsuarioPorId : IGetUsuarioPorId
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public GetUsuarioPorId(IRepositorioUsuario repositorio)
        {
            _repositorioUsuario = repositorio;
        }
        public UsuarioDto Ejecutar(int id)
        {
            Usuario usuario = _repositorioUsuario.GetUsuarioPorId(id);
            if (usuario is not null)
            {
                UsuarioDto usuarioDto = new UsuarioDto(usuario);
                return usuarioDto;
            }
            return null;
        }
    }
}
