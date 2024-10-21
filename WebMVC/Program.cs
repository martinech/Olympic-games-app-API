using Microsoft.EntityFrameworkCore;
using AccesoADatos;
using LogicaDeNegocio.InterfacesRepositorios;
using LogicaDeAplicacion.InterfacesCU.IUsuarioCU;
using LogicaDeAplicacion.InterfacesCU.IAtletaCU;
using LogicaDeAplicacion.InterfacesCU.IDisciplinaCU;
using LogicaDeAplicacion.InterfacesCU.IEventoCU;
using LogicaDeAplicacion.ImplementacionCU;
using LogicaDeAplicacion.ImplementacionCU.UsuarioCU;
using LogicaDeAplicacion.ImplementacionCU.AtletaCU;
using LogicaDeAplicacion.ImplementacionCU.DisciplinaCU;
using LogicaDeAplicacion.ImplementacionCU.EventoCU;
//Pablo 02/10/24 - 06:25
namespace WebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Inyeccion del contexto.
            builder.Services.AddDbContext<DbContext, Contexto>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("StringDeConexionALaBD")));
            
            //Inyeccion de un repositorio cada vez que se llama a una interface.
            builder.Services.AddScoped(typeof(IRepositorioUsuario), typeof(RepositorioUsuario));
            builder.Services.AddScoped(typeof(IRepositorioPais), typeof(RepositorioPais));
            builder.Services.AddScoped(typeof(IRepositorioAtleta), typeof(RepositorioAtleta));
            builder.Services.AddScoped(typeof(IRepositorioDisciplina), typeof(RepositorioDisciplina));
            builder.Services.AddScoped(typeof(IRepositorioEvento), typeof(RepositorioEvento));

            //Inyeccion de un caso de uso cada vez que se llama a la interface correspondiente.
            builder.Services.AddScoped(typeof(ICrearUsuario), typeof(CrearUsuario));
            builder.Services.AddScoped(typeof(IEliminarUsuario), typeof(EliminarUsuario));
            builder.Services.AddScoped(typeof(IGetUsuarioPorId), typeof(GetUsuarioPorId));
            builder.Services.AddScoped(typeof(IGetUsuarios), typeof(GetUsuarios));
            builder.Services.AddScoped(typeof(ILoginUsuario), typeof(LoginUsuario));
            builder.Services.AddScoped(typeof(IModificarUsuario), typeof(ModificarUsuario));

            //Inyeccion de dependencia para los CU atleta
            builder.Services.AddScoped(typeof(ICrearAtleta), typeof(CrearAtleta));
            builder.Services.AddScoped(typeof(IEliminarAtleta), typeof(EliminarAtleta));
            builder.Services.AddScoped(typeof(IGetAtletaPorId), typeof(GetAtletaPorId));
            builder.Services.AddScoped(typeof(IGetAtletas), typeof(GetAtletas));
            builder.Services.AddScoped(typeof(IModificarAtleta), typeof(ModificarAtleta));
            builder.Services.AddScoped(typeof(IAgregarDisciplinaAAtleta), typeof(AgregarDisciplinaAAtleta));
            builder.Services.AddScoped(typeof(IGetAtletasPorDisciplina), typeof(GetAtletasPorDisciplina));

            //Inyeccion de dependencia para los CU disciplina
            builder.Services.AddScoped(typeof(IGetDisciplinas), typeof(GetDisciplinas));
            builder.Services.AddScoped(typeof(IGetDisciplinaPorId), typeof(GetDisciplinaPorId));
            builder.Services.AddScoped(typeof(ICrearDisciplina), typeof(CrearDisciplina));
            builder.Services.AddScoped(typeof(IEliminarDisciplina), typeof(EliminarDisciplina));
            builder.Services.AddScoped(typeof(IModificarDisciplina), typeof(ModificarDisciplina));

            //Inyeccion de dependencia para los CU evento
            builder.Services.AddScoped(typeof(IGetEventos), typeof(GetEventos));
            builder.Services.AddScoped(typeof(IGetEventoPorId), typeof(GetEventoPorId));
            builder.Services.AddScoped(typeof(ICrearEvento), typeof(CrearEvento));
            builder.Services.AddScoped(typeof(IEliminarEvento), typeof(EliminarEvento));
            builder.Services.AddScoped(typeof(IModificarEvento), typeof(ModificarEvento));
            builder.Services.AddScoped(typeof(IAsignarAtletaAEvento), typeof(AsignarAtletaAEvento));
            builder.Services.AddScoped(typeof(IGetEventosPorFecha), typeof(GetEventosPorFecha));
            builder.Services.AddScoped(typeof(IGetEventoAtletaPorIdEvento), typeof(GetEventoAtletaPorIdEvento));
            builder.Services.AddScoped(typeof(IAsignarPuntaje), typeof(AsignarPuntaje));


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=AmbosUsuarios}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
