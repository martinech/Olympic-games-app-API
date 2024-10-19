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
        public Evento evento { get; set; }

        public int idAtleta;
        public Atleta atleta { get; set; }

        public int puntaje { get; set; }
    }
}
