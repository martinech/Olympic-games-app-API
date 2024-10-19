using LogicaDeNegocio.Exceptions;

namespace LogicaDeNegocio.Entidades
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Disciplina { get; set; }
        //public List<Atleta> Atletas { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }

        public Evento() {
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new DatoInvalidoException("El nombre no puede ser vacio");
            if (string.IsNullOrEmpty(Disciplina))
                throw new DatoInvalidoException("La disciplina no puede ser vacia");
            if (FechaInicio == DateTime.MinValue)
                throw new DatoInvalidoException("La fecha de inicio no puede ser vacia");
        }

        public void Copiar(Evento evento)
        {
            Id = evento.Id;
            Nombre = evento.Nombre;
            Disciplina = evento.Disciplina;
            FechaInicio = evento.FechaInicio;
            FechaFin = evento.FechaFin;
        }
    }
}
