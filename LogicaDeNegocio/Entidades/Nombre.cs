using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Nombre
    {
        public string Disciplina { get; protected set; }

        public Nombre()
        {

        }

        public Nombre(string disciplina)
        {
            Disciplina = disciplina;
        }
    }
}
