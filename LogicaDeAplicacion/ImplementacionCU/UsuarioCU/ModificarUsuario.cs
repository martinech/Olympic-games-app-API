using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Exceptions;
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

        public OperacionConUsuario Ejecutar(int id, UsuarioDto usuarioDto)
        {
            OperacionConUsuario operacion = new OperacionConUsuario();
            if (!_repositorioUsuario.YaExisteUsuarioConEmail(usuarioDto.Email))
            {
                Usuario usuario = usuarioDto.ToUsuario();
                _repositorioUsuario.Modificar(id, usuario);
                operacion.Exitosa = true;
                return operacion;
            }
            operacion.Exitosa = false;
            operacion.Mensaje = "El mail que intenta guardar ya existe";
            return operacion;
        }
    }
}
