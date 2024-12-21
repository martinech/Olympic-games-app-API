using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Auditoria
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Operacion { get; set; }
        public string Entidad { get; set; }
        public int IdEntidad { get; set; }
        public string EmailUsuario { get; set; }

        public Auditoria() { }
    }
}
