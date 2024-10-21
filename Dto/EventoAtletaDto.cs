using LogicaDeNegocio.Entidades;

namespace Dto
{
    public class EventoAtletaDto
    {
        public int idEvento;
        public EventoDto evento { get; set; }

        public int idAtleta;
        public AtletaDto atleta { get; set; }
        public int puntaje { get; set; }

        public EventoAtletaDto() { }

        public EventoAtletaDto(EventoAtleta eventoAtleta)
        {
            idEvento = eventoAtleta.idEvento;
            evento = eventoAtleta.evento;
            idAtleta = eventoAtleta.idAtleta;
            atleta = eventoAtleta.atleta;
            puntaje = eventoAtleta.puntaje;
        }

        public Evento ToEvento()
        {
            Evento evento = new Evento()
            {
                Nombre = evento.Nombre,
                Disciplina.Nombre = evento.Disciplina
            }
        }

        public EventoAtleta ToEventoAtleta()
        {
            EventoAtleta eventoAtleta = new EventoAtleta()
            {
                idEvento = idEvento,
                evento = evento,
                idAtleta = idAtleta,
                atleta = atleta,
                puntaje = puntaje
            };
            return eventoAtleta;
        }
    }
}
