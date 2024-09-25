using Microsoft.EntityFrameworkCore;
using LogicaDeNegocio.Entidades;

namespace AccesoADatos
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Atleta> Atletas { get; set; }

        public Contexto(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(usuario => usuario.HasKey(u => u.Id));
            modelBuilder.Entity<Pais>(pais => pais.HasKey(p => p.Id));
            modelBuilder.Entity<Atleta>(atleta => atleta.HasKey(a => a.Id));
            modelBuilder.Entity<Disciplina>().OwnsOne(disciplina => disciplina.Nombre);
            base.OnModelCreating(modelBuilder);
        }
    }
}
