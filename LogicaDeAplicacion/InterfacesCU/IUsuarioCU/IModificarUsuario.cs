using LogicaDeNegocio.Entidades;
using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IUsuarioCU
{
    public interface IModificarUsuario
    {
        public OperacionCRUD Ejecutar(int id, UsuarioDto usuarioDto);
    }
}
