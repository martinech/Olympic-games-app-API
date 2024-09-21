using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace AccesoADatos
{
    public class RepositorioPais : IRepositorioPais
    {
        private DbContext _contexto;

        public RepositorioPais(DbContext contexto)
        {
            _contexto = contexto;
        }
        public void Crear(Pais pais)
        {
            _contexto.Set<Pais>().Add(pais);
            _contexto.SaveChanges();
        }

        public Pais GetPaisPorId(int id)
        {
            return _contexto.Set<Pais>().FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Pais> GetPais()
        {
            return _contexto.Set<Pais>().ToList();
        }
    }
}
