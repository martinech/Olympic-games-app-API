using Dto;
using LogicaDeNegocio.Entidades;

namespace LogicaDeAplicacion.InterfacesCU.IUsuarioCU
{
    public interface ICrearUsuario
    {
        public OperacionCRUD Ejecutar(UsuarioDto usuarioDto);
    }
}
