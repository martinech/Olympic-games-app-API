using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;

namespace LogicaDeAplicacion.ImplementacionCU
{
    public class EliminarDisciplina : IEliminarDisciplina
    {
        private readonly IRepositorioDisciplina _repositorioDisciplina;

        public EliminarDisciplina (IRepositorioDisciplina repositorio)
        {
            _repositorioDisciplina = repositorio;
        }

        public void Ejecutar(int id)
        {
            try
            {
                _repositorioDisciplina.Eliminar(id);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
