using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorios;
using Dto;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.ImplementacionCU.EventoCU
{
    public class AsignarPuntaje : IAsignarPuntaje
    {
        private readonly IRepositorioEvento _repositorioEvento;

        public AsignarPuntaje (IRepositorioEvento repositorioEvento)
        {
            _repositorioEvento = repositorioEvento;
        }

        public void Ejecutar(int idEvento, int idAtleta, EventoAtletaDto eventoAtletaDto)
        {
            EventoAtleta eventoAtleta = eventoAtletaDto.ToEventoAtleta();

            _repositorioEvento.ModificarEventoAtleta(idEvento, idAtleta, eventoAtleta);
        }
    }
}
