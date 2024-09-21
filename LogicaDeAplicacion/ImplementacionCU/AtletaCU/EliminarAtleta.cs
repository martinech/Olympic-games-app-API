using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;

namespace LogicaDeAplicacion.ImplementacionCU
{
    public class EliminarAtleta : IEliminarAtleta
    {
        private readonly IRepositorioAtleta _repositorioAtleta;

        public EliminarAtleta (IRepositorioAtleta repositorio)
        {
            _repositorioAtleta = repositorio;
        }

        public void Ejecutar(int id)
        {
            try
            {
                _repositorioAtleta.Eliminar(id);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
