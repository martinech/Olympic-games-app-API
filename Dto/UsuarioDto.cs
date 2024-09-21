using LogicaDeNegocio.Entidades;

namespace Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public DateTime FechaAlta { get; set; }
        public string EmailAdministrador { get; set; }

        public UsuarioDto() { }

        public UsuarioDto(Usuario usuario)
        {
            Id = usuario.Id;
            Email = usuario.Email;
            Password = usuario.Password;
            Rol = usuario.Rol;
            FechaAlta = usuario.FechaAlta;
            EmailAdministrador = usuario.EmailAdministrador;
        }

        public Usuario ToUsuario()
        {
            Usuario usuario = new Usuario()
            {
                Id = Id,
                Email = Email,
                Password = Password,
                Rol = Rol,
                FechaAlta = FechaAlta,
                EmailAdministrador = EmailAdministrador
            };
            return usuario;
        }
    }
}
