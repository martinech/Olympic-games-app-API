using Dto;
using LogicaDeAplicacion.InterfacesCU.IDisciplinaCU;
using LogicaDeNegocio.InterfacesRepositorios;

namespace LogicaDeAplicacion.ImplementacionCU.DisciplinaCU
{
    public class GetDisciplinas : IGetDisciplinas
    {
        private readonly IRepositorioDisciplina _repositorioDisciplina;

        public GetDisciplinas(IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorioDisciplina = repositorioDisciplina;
        }
        public IEnumerable<DisciplinaDto> Ejecutar()
        {
            return _repositorioDisciplina.GetDisciplinas().Select(disciplina => new DisciplinaDto(disciplina));
        }
    }
}
