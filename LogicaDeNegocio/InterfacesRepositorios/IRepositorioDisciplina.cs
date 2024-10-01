using LogicaDeNegocio.Entidades;

namespace LogicaDeNegocio.InterfacesRepositorios
{
    public interface IRepositorioDisciplina
    {
        void Crear(Disciplina disciplina);
        public IEnumerable<Disciplina> GetDisciplinas();
        public Disciplina GetDisciplinaPorId(int id);
        void Modificar(int id, Disciplina disciplina);
        void Eliminar(int id);
    }
}
