using Dto;
using LogicaDeAplicacion.InterfacesCU.IDisciplinaCU;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;

namespace LogicaDeAplicacion.ImplementacionCU.DisciplinaCU
{
    public class GetDisciplinaPorId : IGetDisciplinaPorId
    {
        private readonly IRepositorioDisciplina _repositorioDisciplina;

        public GetDisciplinaPorId(IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorioDisciplina = repositorioDisciplina;
        }
        public DisciplinaDto Ejecutar(int id)
        {
            Disciplina disciplina = _repositorioDisciplina.GetDisciplinaPorId(id);
            if (disciplina == null)
            {
                throw new NotFoundException("No se encontró la disciplina");
            }
            DisciplinaDto disciplinaDto = new DisciplinaDto(disciplina);
            return disciplinaDto;
        }
    }
}
