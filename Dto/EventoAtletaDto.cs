using LogicaDeNegocio.Entidades;

namespace Dto
{
    public class EventoAtletaDto
    {
        public int idEvento;
        public Evento evento { get; set; }

        public int idAtleta;
        public Atleta atleta { get; set; }
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
