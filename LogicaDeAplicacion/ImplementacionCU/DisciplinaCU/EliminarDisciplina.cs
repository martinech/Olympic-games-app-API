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

        public void Ejecutar(int id, string emailUsuario)
        {
            try
            {
                _repositorioDisciplina.Eliminar(id, emailUsuario);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
