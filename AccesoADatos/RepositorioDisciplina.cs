using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace AccesoADatos
{
    public class RepositorioDisciplina : IRepositorioDisciplina
    {
        private DbContext _contexto;
        public RepositorioDisciplina(DbContext contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Disciplina> GetDisciplinas()
        {
            return _contexto.Set<Disciplina>().ToList();
        }
    }
}
