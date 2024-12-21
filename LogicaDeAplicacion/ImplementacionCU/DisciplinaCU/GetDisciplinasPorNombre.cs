using LogicaDeNegocio.InterfacesRepositorios;
using Dto;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using LogicaAplicacion.InterfacesCU;

namespace LogicaAplicacion.ImplementacionCU
{
    public class GetDisciplinasPorNombre: IGetDisciplinasPorNombre
    {
        private IRepositorioDisciplina _repositorioDisciplina;
        public GetDisciplinasPorNombre(IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorioDisciplina = repositorioDisciplina;
        }

        public IEnumerable<DisciplinaDto> Ejecutar(string nombre) 
        {
            List<DisciplinaDto> disciplinasDto = new List<DisciplinaDto>();
            IEnumerable<Disciplina> disciplinas = _repositorioDisciplina.GetDisciplinasPorNombre(nombre);
            foreach (Disciplina disciplina in disciplinas)
            {
                disciplinasDto.Add(new DisciplinaDto(disciplina));
            }
            return disciplinasDto;
        }

    }
}
