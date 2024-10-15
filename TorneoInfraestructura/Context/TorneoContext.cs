using Microsoft.EntityFrameworkCore;
using TorneoEntidades;

namespace TorneoEntidades
{
    public class TorneoContext : DbContext
    {
        public DbSet<Torneo> Torneos { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<JugadorFemenino> JugadoresFemeninos { get; set; }
        public DbSet<JugadorMasculino> JugadoresMasculinos { get; set; }

        public TorneoContext(DbContextOptions<TorneoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jugador>()
                .HasDiscriminator<string>("TipoJugador")
                .HasValue<JugadorFemenino>("Femenino")
                .HasValue<JugadorMasculino>("Masculino");

            modelBuilder.Entity<Torneo>()
                .HasMany(t => t.Jugadores)
                .WithOne() 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Torneo>()
                .Property(t => t.GanadorId);

            modelBuilder.Entity<JugadorFemenino>()
                .Property(j => j.TiempoReaccion)
                .HasColumnType("decimal(5, 2)"); 

            modelBuilder.Entity<JugadorMasculino>()
                .Property(j => j.Fuerza)
                .HasColumnType("decimal(5, 2)"); 

            modelBuilder.Entity<JugadorMasculino>()
                .Property(j => j.Velocidad)
                .HasColumnType("decimal(5, 2)"); 
        

        }
    }
}
