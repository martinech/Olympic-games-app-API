using LogicaDeNegocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class EventoAtleta
    {
        public int idEvento;
        public Evento Evento { get; set; }

        public int idAtleta;
        public Atleta Atleta { get; set; }

        public int Puntaje { get; set; }

        public void Validar()
        {
            if (Puntaje < 0)
                throw new DatoInvalidoException("El puntaje no puede ser menor que 0");
        }

        public void Copiar(EventoAtleta eventoAtleta)
        {
            idEvento = eventoAtleta.idEvento;
            Evento = eventoAtleta.Evento;
            idAtleta = eventoAtleta.idAtleta;
            Atleta = eventoAtleta.Atleta;
            Puntaje = eventoAtleta.Puntaje;
        }
    }
}
