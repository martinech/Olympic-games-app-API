using LogicaDeNegocio.Entidades;

namespace LogicaDeNegocio.InterfacesRepositorios
{
    public interface IRepositorioPais
    {
        void Crear(Pais pais);
        IEnumerable<Pais> GetPais();
        Pais GetPaisPorId(int id);
    }
}
