using LogicaDeNegocio.Entidades;

namespace Dto
{
    public class PaisDto
    {
        public int Id { get; set; }
        public string Delegado { get; set; }
        public int CantHabitantes { get; set; }
        public string TelDelegado { get; set; }

        public PaisDto() { }

        public PaisDto(Pais pais)
        {
            Id = pais.Id;
            Delegado = pais.Delegado;
            CantHabitantes = pais.CantHabitantes;
            TelDelegado = pais.TelDelegado;
        }

        public Pais ToPais()
        {
            Pais pais = new Pais()
            {
                Id = Id,
                Delegado = Delegado,
                CantHabitantes = CantHabitantes,
                TelDelegado = TelDelegado,
            };
            return pais;
        }
    }
}
