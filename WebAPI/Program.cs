using AccesoADatos;
using LogicaDeAplicacion.ImplementacionCU.EventoCU;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Inyeccion del contexto.
            builder.Services.AddDbContext<DbContext, Contexto>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("StringDeConexionALaBD")));

            //Inyeccion del repositorio a usar.
            builder.Services.AddScoped(typeof(IRepositorioEvento), typeof(RepositorioEvento));

            //Inyeccion del caso de uso.
            builder.Services.AddScoped(typeof(IGetEventosPorIdAtleta), typeof(GetEventosPorIdAtleta));

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
