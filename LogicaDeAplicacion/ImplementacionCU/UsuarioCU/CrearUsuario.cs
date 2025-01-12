using Dto;
using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorios;

namespace LogicaDeAplicacion.ImplementacionCU.UsuarioCU
{
    public class CrearUsuario : ICrearUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public CrearUsuario(IRepositorioUsuario repositorio)
        {
            _repositorioUsuario = repositorio;
        }
        public OperacionConUsuario Ejecutar(UsuarioDto usuarioDto)
        {
            OperacionConUsuario resultado = new OperacionConUsuario();
            if (!_repositorioUsuario.YaExisteUsuarioConEmail(usuarioDto.Email))
            {
                Usuario usuario = usuarioDto.ToUsuario();
                _repositorioUsuario.Crear(usuario);
                resultado.Exitosa = true;
                return resultado;
            }
            resultado.Exitosa = false;
            resultado.Mensaje = "Ya existe un usuario con ese email";
            return resultado;
        }
    }
}
