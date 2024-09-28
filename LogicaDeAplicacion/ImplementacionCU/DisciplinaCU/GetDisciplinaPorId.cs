using Dto;
using LogicaDeAplicacion.InterfacesCU.IDisciplinaCU;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;

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
            DisciplinaDto disciplinaDto = new DisciplinaDto(disciplina);
            return disciplinaDto;
        }
    }
}
