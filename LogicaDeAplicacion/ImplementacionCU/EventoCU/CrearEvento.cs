using Dto;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeNegocio.Entidades;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeNegocio.Exceptions;

namespace LogicaDeAplicacion.ImplementacionCU.EventoCU
{
    public class CrearEvento : ICrearEvento
    {
        private readonly IRepositorioEvento _repositorioEvento;

        public CrearEvento(IRepositorioEvento repositorio)
        {
            _repositorioEvento = repositorio;
        }
        public void Ejecutar(EventoDto eventoDto)
        {
            try
            {
                Evento eventoNuevo = eventoDto.ToEvento();
                eventoNuevo.Validar();
                _repositorioEvento.Crear(eventoNuevo);
            }
            catch(DatoInvalidoException)
            {
                throw new DatoInvalidoException("Nombre ya existente");
            }
        }
    }
}
