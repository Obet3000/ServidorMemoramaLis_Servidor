using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AccesoADatos
{
    public partial class MemoramaLis_Model : DbContext
    {
        public MemoramaLis_Model()
            : base("name=MemoramaLis_Model")
        {
        }

        public virtual DbSet<Amigos> Amigos { get; set; }
        public virtual DbSet<Cartas> Cartas { get; set; }
        public virtual DbSet<Jugadores> Jugadores { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Partidas> Partidas { get; set; }
        public virtual DbSet<Partidas_Cartas> Partidas_Cartas { get; set; }
        public virtual DbSet<Partidas_Jugadores> Partidas_Jugadores { get; set; }
        public virtual DbSet<Puntuaciones> Puntuaciones { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jugadores>()
                .HasMany(e => e.Amigos)
                .WithOptional(e => e.Jugadores)
                .HasForeignKey(e => e.IdAmigo);

            modelBuilder.Entity<Jugadores>()
                .HasMany(e => e.Amigos1)
                .WithOptional(e => e.Jugadores1)
                .HasForeignKey(e => e.IdJugador);
        }
    }
}
