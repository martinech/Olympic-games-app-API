using LogicaDeNegocio.InterfacesRepositorios;
using Dto;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;

namespace LogicaDeAplicacion.ImplementacionCU.EventoCU
{
    public class ModificarEvento : IModificarEvento
    {
        private readonly IRepositorioEvento _repositorioEvento;

        public ModificarEvento(IRepositorioEvento repositorio)
        {
            _repositorioEvento = repositorio;
        }

        public void Ejecutar(int id, EventoDto eventoDto)
        {
            Evento evento = eventoDto.ToEvento();

            try
            {
                evento.Validar();
                _repositorioEvento.Modificar(id, evento);
            }
            catch (DatoInvalidoException e)
            {
                throw;
            }
        }
    }
}
