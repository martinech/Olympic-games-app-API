using LogicaDeNegocio.Entidades;

namespace Dto
{
    public class EventoAtletaDto
    {
        public int idEvento;
        public Evento Evento { get; set; }

        public int idAtleta;
        public Atleta Atleta { get; set; }
        public int Puntaje { get; set; }

        public EventoAtletaDto() { }

        public EventoAtletaDto(EventoAtleta eventoAtleta)
        {
            idEvento = eventoAtleta.idEvento;
            Evento = eventoAtleta.Evento;
            idAtleta = eventoAtleta.idAtleta;
            Atleta = eventoAtleta.Atleta;
            Puntaje = eventoAtleta.Puntaje;
        }

        //public Evento ToEvento()
        //{
        //    Evento evento = new Evento()
        //    {
        //        Nombre = evento.Nombre,
        //        Disciplina.Nombre = evento.Disciplina
        //    }
        //}

        public EventoAtleta ToEventoAtleta()
        {
            EventoAtleta eventoAtleta = new EventoAtleta()
            {
                idEvento = idEvento,
                Evento = Evento,
                idAtleta = idAtleta,
                Atleta = Atleta,
                Puntaje = Puntaje
            };
            return eventoAtleta;
        }
    }
}
