using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;
using Dto;

namespace LogicaDeAplicacion.ImplementacionCU.UsuarioCU
{
    public class CrearUsuario : ICrearUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public CrearUsuario(IRepositorioUsuario repositorio)
        {
            _repositorioUsuario = repositorio;
        }
        public OperacionCRUD Ejecutar(UsuarioDto usuarioDto)
        {
            OperacionCRUD resultado = new OperacionCRUD();
            if (!_repositorioUsuario.YaExisteUsuarioConEmail(usuarioDto.Email))
            {
                Usuario usuario = usuarioDto.ToUsuario();
                _repositorioUsuario.Crear(usuario);
                resultado.FueExitosa = true;
                return resultado;
            }
            resultado.FueExitosa = false;
            resultado.Mensaje = "Ya existe un usuario con ese email";
            return resultado;
        }
    }
}
