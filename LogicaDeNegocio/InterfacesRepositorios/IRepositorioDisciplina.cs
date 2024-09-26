using LogicaDeNegocio.Entidades;

namespace LogicaDeNegocio.InterfacesRepositorios
{
    public interface IRepositorioDisciplina
    {
        public IEnumerable<Disciplina> GetDisciplinas();
    }
}
