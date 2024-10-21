using LogicaDeNegocio.Entidades;
using Dto;

namespace LogicaDeAplicacion.InterfacesCU.IEventoCU
{
    public interface IAsignarPuntaje
    {
        public void Ejecutar(int idEvento, int idAtleta, EventoAtletaDto eventoAtletaDto);
    }
}
