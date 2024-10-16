using LogicaDeNegocio.Entidades;

namespace Dto
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Disciplina Disciplina { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public EventoDto() { }

        public EventoDto(Evento evento)
        {
            Id = evento.Id;
            Nombre = evento.Nombre;
            Disciplina = evento.Disciplina;
            FechaInicio = evento.FechaInicio;
            FechaFin = evento.FechaFin;
        }


        public Evento ToEvento()
        {
            Evento evento = new Evento()
            {
                Id = Id,
                Nombre = Nombre,
                Disciplina = Disciplina,
                FechaFin = FechaFin,
                FechaInicio = FechaInicio
            };
            return evento;
        }
    }
}
