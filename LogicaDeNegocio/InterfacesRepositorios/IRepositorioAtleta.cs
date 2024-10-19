using LogicaDeNegocio.Entidades;

namespace LogicaDeNegocio.InterfacesRepositorios
{
    public interface IRepositorioAtleta
    {
        void Crear(Atleta atleta);
        IEnumerable<Atleta> GetAtletas();
        Atleta GetAtletaPorId(int id);
        void Modificar(int id, Atleta atleta);
        void Eliminar(int id);
        public IEnumerable<Atleta> GetAtletasPorDisciplina(int idDisciplina);
    }
}
