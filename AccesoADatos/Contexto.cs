using Microsoft.EntityFrameworkCore;
using LogicaDeNegocio.Entidades;

namespace AccesoADatos
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Atleta> Atletas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        public Contexto(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(usuario => usuario.HasKey(u => u.Id));
            modelBuilder.Entity<Pais>(pais => pais.HasKey(p => p.Id));
            modelBuilder.Entity<Atleta>(atleta => atleta.HasKey(a => a.Id));
            modelBuilder.Entity<Disciplina>().OwnsOne(disciplina => disciplina.Nombre);
            modelBuilder.Entity<Evento>(evento => evento.HasKey(e => e.Id));
            modelBuilder.Entity<EventoAtleta>(eventoatleta => eventoatleta.HasKey(ea => new {ea.idEvento, ea.idAtleta}));

            modelBuilder.Entity<EventoAtleta>()
                .HasOne(ea => ea.evento)
                .WithMany(evento => evento.EventoAtletas)
                .HasForeignKey(ea => ea.idEvento);

            modelBuilder.Entity<EventoAtleta>()
                .HasOne(ea => ea.atleta)
                .WithMany(atleta => atleta.EventoAtletas)
                .HasForeignKey(ea => ea.idAtleta);

            base.OnModelCreating(modelBuilder);
        }
    }
}
