using LogicaDeNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using LogicaDeAplicacion.InterfacesCU.IAuditoriaCU;
using LogicaDeNegocio.Entidades;


namespace LogicaDeAplicacion.ImplementacionCU.AuditoriaCU
{
    public class AgregarRegistro : IAgregarRegistro
    {
        private readonly IRepositorioDisciplina _repositorioDisciplina;

        public AgregarRegistro(IRepositorioDisciplina repositorioDisciplina)
        {
            this._repositorioDisciplina = repositorioDisciplina;
        }

        public void Ejecutar(AuditoriaDto auditoriaDto)
        {
            Auditoria auditoria = auditoriaDto.ToAuditoria();
            //_repositorioDisciplina.AgregarRegistro(auditoria);
        }
    }
}
