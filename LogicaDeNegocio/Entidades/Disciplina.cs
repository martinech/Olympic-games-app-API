using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Disciplina
    {
        public int Id { get; set; }
        public Nombre Nombre { get; set; }
        public List<Atleta> Atletas { get; set; }
    }
}
