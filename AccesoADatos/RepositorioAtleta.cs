using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using LogicaDeNegocio.Exceptions;

namespace AccesoADatos
{
    public class RepositorioAtleta : IRepositorioAtleta
    {
        private DbContext _contexto;

        public RepositorioAtleta(DbContext contexto)
        {
            _contexto = contexto;
        }
        public void Crear(Atleta atleta)
        {
            _contexto.Set<Atleta>().Add(atleta);
            _contexto.SaveChanges();
        }

        public void Eliminar(int id)
        {
            Atleta atletaAEliminar = _contexto.Set<Atleta>().FirstOrDefault(t => t.Id == id);

            if (atletaAEliminar is not null)
            {
                _contexto.Set<Atleta>().Remove(atletaAEliminar);
                _contexto.SaveChanges();
            }
            else
            {
                throw new AtletaInvalidoException("El atleta que desea eliminar no se ha encontrado");
            }
        }

        public Atleta GetAtletaPorId(int id)
        {
            return _contexto.Set<Atleta>()
                .Include(a => a.Disciplinas)
                .FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Atleta> GetAtletas()
        {
            return _contexto.Set<Atleta>()
                .OrderBy(a=> a.Pais)
                .ThenBy(a => a.Nombre)
                .ThenBy(a => a.Apellido)
                .ToList();
        }

        public void Modificar(int id, Atleta atleta)
        {
            Atleta AtletaAModificar = _contexto.Set<Atleta>().FirstOrDefault(t => t.Id == id);
            AtletaAModificar.Copiar(atleta);
            _contexto.Entry(AtletaAModificar).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public IEnumerable<Atleta> GetAtletasPorDisciplina(int idDisciplina)
        {
            return _contexto.Set<Atleta>()
                .Include(atleta => atleta.Disciplinas)
                .Where(atleta => atleta.Disciplinas
                .Any(disciplina => disciplina.Id == idDisciplina))
                .OrderBy(a => a.Nombre)
                .ThenBy(a => a.Apellido)
                .ToList();
        }

    }
}
