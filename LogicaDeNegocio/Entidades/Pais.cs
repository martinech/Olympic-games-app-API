using LogicaDeNegocio.Exceptions;
using LogicaDeNegocio.InterfacesEntidades;

namespace LogicaDeNegocio.Entidades
{
    public class Pais : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Delegado { get; set; }
        public string TelDelegado { get; set; }
        public int CantHabitantes { get; set; }

        public Pais() { }

        public void Validar()
        {
            if(string.IsNullOrEmpty(Nombre))
                throw new DatoInvalidoException("El nombre no puede ser vacio");
            if (string.IsNullOrEmpty(Delegado))
                throw new DatoInvalidoException("El delegado no puede ser vacio");
            if (CantHabitantes <= 0)
                throw new DatoInvalidoException("La contraseña no puede ser vacia");
            if (string.IsNullOrEmpty(TelDelegado))
                throw new DatoInvalidoException("El rol no puede estar vacio");
        }

        public void Copiar(Pais pais)
        {
            Nombre = pais.Nombre;
            Delegado = pais.Delegado;
            CantHabitantes = pais.CantHabitantes;
            TelDelegado = pais.TelDelegado ;
        }
    }
}
