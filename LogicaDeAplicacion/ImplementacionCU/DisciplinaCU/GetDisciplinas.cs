using Dto;
using LogicaDeAplicacion.InterfacesCU.IDisciplinaCU;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;

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
            List<DisciplinaDto> disciplinasDto = new List<DisciplinaDto>();
            IEnumerable<Disciplina> disciplinas = _repositorioDisciplina.GetDisciplinas();

            foreach (Disciplina d in disciplinas)
                disciplinasDto.Add(new DisciplinaDto(d));

            return disciplinasDto;
        }
    }
}
