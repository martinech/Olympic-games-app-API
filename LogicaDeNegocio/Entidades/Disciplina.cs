using LogicaDeNegocio.Exceptions;

namespace LogicaDeNegocio.Entidades
{
    public class Disciplina
    {
        public int Id { get; set; }
        public Nombre Nombre { get; set; }
        public int AnioDeIntegracion { get; set; }
        public List<Atleta> Atletas { get; set; } = new List<Atleta>();

        public Disciplina() { }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre.Disciplina))
                throw new DatoInvalidoException("El nombre no puede ser vacio");
            if(Nombre.Disciplina.Length > 50)
            {
                throw new DatoInvalidoException("El nombre no puede tener mas de 50 caracteres");
            }
        }

        public void Copiar(Disciplina disciplina)
        {
            Nombre = new Nombre(disciplina.Nombre.Disciplina);
            AnioDeIntegracion = disciplina.AnioDeIntegracion;
            Atletas = disciplina.Atletas;
        }
    }
}
