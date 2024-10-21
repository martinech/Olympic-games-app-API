using Dto;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using LogicaDeNegocio.InterfacesRepositorios;

namespace LogicaDeAplicacion.ImplementacionCU.EventoCU
{
    public class AsignarAtletaAEvento : IAsignarAtletaAEvento
    {
        private readonly IRepositorioEvento _repositorioEvento;

        private readonly IRepositorioAtleta _repositorioAtleta;

        public AsignarAtletaAEvento(IRepositorioEvento repositorioEvento, IRepositorioAtleta repositorioAtleta)
        {
            _repositorioEvento = repositorioEvento;
            _repositorioAtleta = repositorioAtleta;
        }

            public void Ejecutar(EventoAtletaDto eventoAtletaDto)
            {
                Evento evento = _repositorioEvento.GetEventoPorId(eventoAtletaDto.idEvento);
                Atleta atleta = _repositorioAtleta.GetAtletaPorId(eventoAtletaDto.idAtleta);
                if (atleta == null)
                {
                    throw new DatoInvalidoException("El atleta no existe.");
                }
                if (evento.EventoAtletas.Any(ea => ea.idAtleta == eventoAtletaDto.idAtleta))
                {
                    throw new DatoInvalidoException("El atleta ya está asignado a este evento.");
                }
                EventoAtleta eventoAtleta = new EventoAtleta
                {
                    idEvento = eventoAtletaDto.idEvento,
                    idAtleta = eventoAtletaDto.idAtleta,
                };
                evento.EventoAtletas.Add(eventoAtleta);
                _repositorioEvento.Modificar(eventoAtletaDto.idEvento, evento);
        }
        }
    }
