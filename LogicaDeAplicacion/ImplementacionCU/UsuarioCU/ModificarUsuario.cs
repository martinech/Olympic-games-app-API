using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;
using Dto;

namespace LogicaDeAplicacion.ImplementacionCU.UsuarioCU
{
    public class ModificarUsuario : IModificarUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public ModificarUsuario(IRepositorioUsuario repositorio)
        {
            _repositorioUsuario = repositorio;
        }

        public OperacionCRUD Ejecutar(int id, UsuarioDto usuarioDto)
        {
            OperacionCRUD operacion = new OperacionCRUD();
            if (!_repositorioUsuario.YaExisteUsuarioConEmail(usuarioDto.Email))
            {
                Usuario usuario = usuarioDto.ToUsuario();
                _repositorioUsuario.Modificar(id, usuario);
                operacion.FueExitosa = true;
                return operacion;
            }
            operacion.FueExitosa = false;
            operacion.Mensaje = "El mail que intenta guardar ya existe";
            return operacion;
        }
    }
}
