using LogicaDeNegocio.Exceptions;

namespace LogicaDeNegocio.Entidades
{
    public class Atleta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string Pais { get; set; }
        public List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new DatoInvalidoException("El nombre no puede ser vacio");
            if (string.IsNullOrEmpty(Sexo))
                throw new DatoInvalidoException("La sexo no puede ser vacia");
            if (string.IsNullOrEmpty(Pais))
                throw new DatoInvalidoException("El pais no puede estar vacio");
        }

        public void Copiar(Atleta atleta)
        {
            Nombre = atleta.Nombre;
            Apellido = atleta.Apellido;
            Sexo = atleta.Sexo;
            Pais = atleta.Pais;
            Disciplinas = atleta.Disciplinas;
        }

        public List<Disciplina> GetDesciplinasDelAtleta()
        {
            return Disciplinas;
        }

        public override string ToString()
        {
            return Nombre + " " + Apellido;
        }
    }
}
