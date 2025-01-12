using LogicaDeNegocio.Entidades;
using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IUsuarioCU
{
    public interface IModificarUsuario
    {
        public OperacionConUsuario Ejecutar(int id, UsuarioDto usuarioDto);
    }
}
