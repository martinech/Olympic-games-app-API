using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
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
        public void Crear(Disciplina disciplina)
        {
            if (_contexto.Set<Disciplina>().Any(d => d.Nombre.Disciplina == disciplina.Nombre.Disciplina))
                throw new DatoInvalidoException("Ya existe una disciplina no este nombre");
            else
            {
                _contexto.Set<Disciplina>().Add(disciplina);
                _contexto.SaveChanges();
            }
            
        }
        public IEnumerable<Disciplina> GetDisciplinas()
        {
            return _contexto.Set<Disciplina>().ToList();
        }

        public Disciplina GetDisciplinaPorId(int id)
        {
            return _contexto.Set<Disciplina>().FirstOrDefault(disciplina => disciplina.Id == id);
        }
        public void Eliminar(int id)
        {
            Disciplina disciplinaAEliminar = _contexto.Set<Disciplina>().FirstOrDefault(t => t.Id == id);

            if (disciplinaAEliminar is not null)
            {
                _contexto.Set<Disciplina>().Remove(disciplinaAEliminar);
                _contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioInvalidoException("La disciplina que desea eliminar no se ha encontrado");
            }
        }

        public void Modificar(int id, Disciplina disciplina)
        {
            Disciplina DisciplinaAModificar = _contexto.Set<Disciplina>().FirstOrDefault(t => t.Id == id);
            DisciplinaAModificar.Copiar(disciplina);
            _contexto.Entry(DisciplinaAModificar).State = EntityState.Modified;
            _contexto.SaveChanges();
        }
    }
}
