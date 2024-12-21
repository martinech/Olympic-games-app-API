using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class AuditoriaDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Operacion { get; set; }
        public string Entidad { get; set; }
        public int IdEntidad { get; set; }
        public string EmailUsuario { get; set; }


        public AuditoriaDto() { }

        public AuditoriaDto(Auditoria auditoria)
        {
            Id = auditoria.Id;
            Fecha = auditoria.Fecha;
            Operacion = auditoria.Operacion;
            Entidad = auditoria.Entidad;
            IdEntidad = auditoria.IdEntidad;
            EmailUsuario = auditoria.EmailUsuario;
        }

        public Auditoria ToAuditoria()
        {
            Auditoria auditoria = new Auditoria()
            {
                Id = Id,
                Fecha = Fecha,
                Operacion = Operacion,
                Entidad = Entidad,
                IdEntidad = IdEntidad,
                EmailUsuario = EmailUsuario
            };
            return auditoria;
        }
    }
}
