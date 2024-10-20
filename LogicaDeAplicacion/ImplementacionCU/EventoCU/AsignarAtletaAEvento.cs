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
                // Obtener el evento por ID
                Evento evento = _repositorioEvento.GetEventoPorId(eventoAtletaDto.idEvento);

                // Obtener el atleta por ID
                Atleta atleta = _repositorioAtleta.GetAtletaPorId(eventoAtletaDto.idAtleta);
                if (atleta == null)
                {
                    throw new DatoInvalidoException("El atleta no existe.");
                }

                // Verificar si el atleta ya está asignado al evento
                if (evento.EventoAtletas.Any(ea => ea.idAtleta == eventoAtletaDto.idAtleta))
                {
                    throw new DatoInvalidoException("El atleta ya está asignado a este evento.");
                }

                // Crear la asociación entre el atleta y el evento
                EventoAtleta eventoAtleta = new EventoAtleta
                {
                    idEvento = eventoAtletaDto.idEvento,
                    idAtleta = eventoAtletaDto.idAtleta,
                    //puntaje = eventoAtletaDto.Puntaje  // Si necesitas un puntaje inicial Aca no se si es necesario agregar puntaje, capaz puede ser 0
                };

                // Agregar la asociación al evento
                evento.EventoAtletas.Add(eventoAtleta);
                
                // Guardar cambios en el repositorio
                _repositorioEvento.Modificar(eventoAtletaDto.idEvento, evento);
        }
        }
    }
