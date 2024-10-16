using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeNegocio.InterfacesRepositorios;

namespace LogicaDeAplicacion.ImplementacionCU.EventoCU
{
    public class EliminarEvento : IEliminarEvento
    {
        private readonly IRepositorioEvento _repositorioEvento;

        public EliminarEvento(IRepositorioEvento repositorio)
        {
            _repositorioEvento = repositorio;
        }

        public void Ejecutar(int id)
        {
            _repositorioEvento.Eliminar(id);
        }
    }
}
