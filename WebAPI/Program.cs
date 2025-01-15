using AccesoADatos;
using LogicaAplicacion.ImplementacionCU;
using LogicaAplicacion.InterfacesCU;
using LogicaDeAplicacion.ImplementacionCU;
using LogicaDeAplicacion.ImplementacionCU.AtletaCU;
using LogicaDeAplicacion.ImplementacionCU.DisciplinaCU;
using LogicaDeAplicacion.ImplementacionCU.EventoCU;
using LogicaDeAplicacion.ImplementacionCU.UsuarioCU;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using LogicaDeAplicacion.InterfacesCU.IDisciplinaCU;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;
using LogicaDeNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Text;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //Configura la autenticacion JWT.
            var claveSecreta = "claveSuperSecretaCon32CaracteresMin";
            var claveBytes = Encoding.ASCII.GetBytes(claveSecreta);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(claveBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //Configura la autorizacion
            builder.Services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });

            //Inyeccion del contexto.
            builder.Services.AddDbContext<DbContext, Contexto>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("StringDeConexionALaBD")));

            //Inyeccion del repositorio a usar.
            builder.Services.AddScoped(typeof(IRepositorioEvento), typeof(RepositorioEvento));
            builder.Services.AddScoped(typeof(IRepositorioDisciplina), typeof(RepositorioDisciplina));
            builder.Services.AddScoped(typeof(IRepositorioUsuario), typeof(RepositorioUsuario));
            builder.Services.AddScoped(typeof(IRepositorioAtleta), typeof(RepositorioAtleta));

            //Inyeccion del caso de uso.
            builder.Services.AddScoped(typeof(IGetEventosPorIdAtleta), typeof(GetEventosPorIdAtleta));
            builder.Services.AddScoped(typeof(IGetEventosPorDisciplina), typeof(GetEventosPorDisciplina));
            builder.Services.AddScoped(typeof(IGetEventosPorNombre), typeof(GetEventosPorNombre));
            builder.Services.AddScoped(typeof(IGetEventosPorFechas), typeof(GetEventosPorFechas));
            builder.Services.AddScoped(typeof(IGetEventosPorPuntajes), typeof(GetEventosPorPuntajes));
            builder.Services.AddScoped(typeof(ICrearDisciplina), typeof(CrearDisciplina));
            builder.Services.AddScoped(typeof(IEliminarDisciplina), typeof(EliminarDisciplina));
            builder.Services.AddScoped(typeof(IModificarDisciplina), typeof(ModificarDisciplina));
            builder.Services.AddScoped(typeof(IGetDisciplinasPorNombre), typeof(GetDisciplinasPorNombre));
            builder.Services.AddScoped(typeof(IGetDisciplinaPorId), typeof(GetDisciplinaPorId));
            builder.Services.AddScoped(typeof(IGetDisciplinas), typeof(GetDisciplinas));
            builder.Services.AddScoped(typeof(ILoginUsuario), typeof(LoginUsuario));
            builder.Services.AddScoped(typeof(IGetAtletasPorDisciplina), typeof(GetAtletasPorDisciplina));
            builder.Services.AddScoped(typeof(IGetAtletas), typeof(GetAtletas));


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
