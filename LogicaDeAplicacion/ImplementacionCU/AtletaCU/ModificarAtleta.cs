using LogicaDeNegocio.InterfacesRepositorios;
using Dto;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;

namespace LogicaDeAplicacion.ImplementacionCU
{
    public class ModificarAtleta : IModificarAtleta
    {
        private readonly IRepositorioAtleta _repositorioAtleta;

        public ModificarAtleta (IRepositorioAtleta repositorio)
        {
            _repositorioAtleta = repositorio;
        }

        public void Ejecutar(int id, AtletaDto atletaDto)
        {
            Atleta atleta = atletaDto.ToAtleta();

            try
            {
                atleta.Validar();
                _repositorioAtleta.Modificar(id, atleta);
            }
            catch (DatoInvalidoException e)
            {
                throw;
            }
        }
    }
}
