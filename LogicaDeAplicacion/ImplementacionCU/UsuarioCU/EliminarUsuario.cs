using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;
using LogicaDeNegocio.InterfacesRepositorios;

namespace LogicaDeAplicacion.ImplementacionCU.UsuarioCU
{
    public class EliminarUsuario : IEliminarUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public EliminarUsuario(IRepositorioUsuario repositorio)
        {
            _repositorioUsuario = repositorio;
        }

        public void Ejecutar(int id)
        {
            try
            {
                _repositorioUsuario.Eliminar(id);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
