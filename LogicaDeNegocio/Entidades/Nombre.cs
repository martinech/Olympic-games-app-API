namespace LogicaDeNegocio.Entidades
{
    public class Nombre
    {
        public string Disciplina { get; protected set; }

        public Nombre()
        {

        }

        public Nombre(string disciplina)
        {
            Disciplina = disciplina;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
