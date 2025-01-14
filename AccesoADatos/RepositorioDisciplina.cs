using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using Microsoft.EntityFrameworkCore;
using LogicaDeNegocio.InterfacesRepositorios;

namespace AccesoADatos
{
    public class RepositorioDisciplina : IRepositorioDisciplina
    {
        private DbContext _contexto;
        public RepositorioDisciplina(DbContext contexto)
        {
            _contexto = contexto;
        }
        public void Crear(Disciplina disciplina, string emailUsuario)
        {
            _contexto.Set<Disciplina>().Add(disciplina);
            _contexto.SaveChanges();
            Auditoria registro = new Auditoria()
            {
                Fecha = DateTime.Now,
                Operacion = "Crear",
                Entidad = "Disciplina",
                IdEntidad = disciplina.Id,
                EmailUsuario = "user1@example.com"
            };
            _contexto.Set<Auditoria>().Add(registro);
            _contexto.SaveChanges();
        }
        public IEnumerable<Disciplina> GetDisciplinas()
        {
            return _contexto.Set<Disciplina>().ToList();
        }

        public Disciplina GetDisciplinaPorId(int id)
        {
            return _contexto.Set<Disciplina>().FirstOrDefault(disciplina => disciplina.Id == id);
        }
        public void Eliminar(int id, string emailUsuario)
        {
            Disciplina disciplinaAEliminar = _contexto.Set<Disciplina>().FirstOrDefault(d => d.Id == id);

            if (disciplinaAEliminar is not null)
            {
                _contexto.Set<Disciplina>().Remove(disciplinaAEliminar);
                _contexto.SaveChanges();
                Auditoria registro = new Auditoria()
                {
                    Fecha = DateTime.Now,
                    Operacion = "Eliminar",
                    Entidad = "Disciplina",
                    IdEntidad = disciplinaAEliminar.Id,
                    EmailUsuario = "user1@example.com"
                };
                _contexto.Set<Auditoria>().Add(registro);
                _contexto.SaveChanges();
            }
            else
            {
                throw new NotFoundException("La disciplina que desea eliminar no se ha encontrado");
            }
        }

        public void Modificar(int id, Disciplina disciplina, string emailUsuario)
        {
            Disciplina DisciplinaAModificar = _contexto.Set<Disciplina>().FirstOrDefault(d => d.Id == id);
            DisciplinaAModificar.Copiar(disciplina);
            _contexto.Entry(DisciplinaAModificar).State = EntityState.Modified;
            _contexto.SaveChanges();
            Auditoria registro = new Auditoria()
            {
                Fecha = DateTime.Now,
                Operacion = "Modificar",
                Entidad = "Disciplina",
                IdEntidad = DisciplinaAModificar.Id,
                EmailUsuario = "user1@example.com"
            };
            _contexto.Set<Auditoria>().Add(registro);
            _contexto.SaveChanges();
        }

        public IEnumerable<Disciplina> GetDisciplinasPorNombre(string nombre)
        {
            return _contexto.Set<Disciplina>()
                        .Where(d => d.Nombre.Disciplina.Contains(nombre)).ToList();
        }

        public void AgregarRegistro(Auditoria auditoria)
        {
            _contexto.Set<Auditoria>().Add(auditoria);
            _contexto.SaveChanges();
        }

        public bool YaExisteDisciplinaConEseNombre(string nombre)
        {
            return _contexto.Set<Disciplina>().Any(d => d.Nombre.Disciplina == nombre);
        }
    }
}
