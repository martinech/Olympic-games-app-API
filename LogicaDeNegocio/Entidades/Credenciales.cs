namespace LogicaDeNegocio.Entidades
{
    public class Credenciales
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public Credenciales() { }

        public bool SonValidas()
        {
            if (Email != "" && Email is not null && Password != "" && Password is not null)
                return true;

            return false;
        }
    }
}
