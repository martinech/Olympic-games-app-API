namespace LogicaDeNegocio.Exceptions
{
    public class EventoInvalidoException : Exception
    {
        public EventoInvalidoException() { }
        public EventoInvalidoException(string message) : base(message) { }
    }
}
