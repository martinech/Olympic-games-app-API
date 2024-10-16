using LogicaDeNegocio.Entidades;

namespace Dto
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string Pais { get; set; }
        public List<DisciplinaDto> DisciplinasDto { get; set; } = new List<DisciplinaDto>();

        public EventoDto() { }

        public EventoDto(Evento evento)
        {
            Id = evento.Id;
            Nombre = evento.Nombre;
            Apellido = evento.Apellido;
            Sexo = evento.Sexo;
            Pais = evento.Pais;
            DisciplinasDto = DisciplinasADisciplinasDto(evento.Disciplinas);
        }

        public List<DisciplinaDto> DisciplinasADisciplinasDto(List<Disciplina> disciplinas)
        {
            List<DisciplinaDto> disciplinasDto = new List<DisciplinaDto>();

            foreach (Disciplina disciplina in disciplinas)
                disciplinasDto.Add(new DisciplinaDto(disciplina));

            return disciplinasDto;
        }

        public List<Disciplina> DisciplinasDtoADisciplinas()
        {
            List<Disciplina> disciplinas = new List<Disciplina>();

            foreach (DisciplinaDto disciplinaDto in DisciplinasDto)
                disciplinas.Add(new Disciplina()
                {
                    Id = disciplinaDto.Id,
                    Nombre = new Nombre(Nombre),
                    AnioDeIntegracion = disciplinaDto.AnioDeIntegracion,
                    Eventos = disciplinaDto.EventosDtoToEventos()
                });

            return disciplinas;
        }

        public Evento ToEvento()
        {
            Evento evento = new Evento()
            {
                Id = Id,
                Nombre = Nombre,
                Apellido = Apellido,
                Sexo = Sexo,
                Pais = Pais,
                Disciplinas = DisciplinasDtoADisciplinas()
            };
            return evento;
        }
    }
}
