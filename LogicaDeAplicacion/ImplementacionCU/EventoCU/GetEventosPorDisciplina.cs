using Dto;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using LogicaDeNegocio.InterfacesRepositorios;

namespace LogicaDeAplicacion.ImplementacionCU.EventoCU
{
    public class GetEventosPorDisciplina : IGetEventosPorDisciplina
    {
        private readonly IRepositorioEvento _repositorioEvento;
        private readonly IRepositorioDisciplina _repositorioDisciplina;

        public GetEventosPorDisciplina(IRepositorioEvento repositorioEvento,
                                       IRepositorioDisciplina repositorioDisciplina)
        {
            _repositorioEvento = repositorioEvento;
            _repositorioDisciplina = repositorioDisciplina;
        }
        public List<EventoDto> Ejecutar(int id)
        { 
            Disciplina disciplina = _repositorioDisciplina.GetDisciplinaPorId(id);
            if (disciplina == null)
            {
                throw new NotFoundException("Disciplina invalida");
            }
                DisciplinaDto disciplinaDto = new DisciplinaDto(disciplina);
            string nombreDisciplina = disciplinaDto.Nombre;

            List<EventoDto> eventosDto = new List<EventoDto>();

            foreach (var evento in _repositorioEvento.GetEventosPorDisciplina(nombreDisciplina))
                eventosDto.Add(new EventoDto(evento));

            return eventosDto;
        }
    }
}
