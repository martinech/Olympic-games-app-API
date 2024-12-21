using LogicaDeNegocio.Entidades;

namespace LogicaDeNegocio.InterfacesRepositorios
{
    public interface IRepositorioDisciplina
    {
        void Crear(Disciplina disciplina, string emailUsuario);
        public IEnumerable<Disciplina> GetDisciplinas();
        public Disciplina GetDisciplinaPorId(int id);
        public IEnumerable<Disciplina> GetDisciplinasPorNombre(string nombre);
        void Modificar(int id, Disciplina disciplina, string emailUsuario);
        void Eliminar(int id, string emailUsuario);
    }
}
