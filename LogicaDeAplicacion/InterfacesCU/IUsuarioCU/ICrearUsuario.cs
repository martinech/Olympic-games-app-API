using Dto;
using LogicaDeNegocio.Entidades;

namespace LogicaDeAplicacion.InterfacesCU.IUsuarioCU
{
    public interface ICrearUsuario
    {
        public OperacionConUsuario Ejecutar(UsuarioDto usuarioDto);
    }
}
