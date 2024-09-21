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

        public void Ejecutar(int id, AtletaDto usuarioDto)
        {
            Atleta usuario = usuarioDto.ToAtleta();

            try
            {
                usuario.Validar();
                _repositorioAtleta.Modificar(id, usuario);
            }
            catch (DatoInvalidoException e)
            {
                throw;
            }
        }
    }
}
