namespace Mundial.DAL.Entities
{
    using Microsoft.EntityFrameworkCore;
    
    public partial class MundialContext : DbContext
    {
        public MundialContext()
        { }

        public MundialContext(DbContextOptions<MundialContext> options)
            : base(options)
        { }

        #region entitiesContext
        public virtual DbSet<Asistencia> Asistencia { get; set; }
        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<Goleador> Goleador { get; set; }
        public virtual DbSet<Jugador> Jugador { get; set; }
        public virtual DbSet<Posicion> Posicion { get; set; }
        public virtual DbSet<Resultado> Resultado { get; set; }
        public virtual DbSet<TablaPosiciones> TablaPosiciones { get; set; }
        public virtual DbSet<TarjetaRoja> TarjetaRoja { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        #endregion


        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asistencia>(entity =>
            {
                entity.HasOne(d => d.Jugador)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.JugadorId)
                    .HasConstraintName("FK_Asistencia_Jugador");
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasIndex(e => e.Nombre)
                    .HasName("UQ__Equipo__75E3EFCF59F0F5DE")
                    .IsUnique();

                entity.Property(e => e.Grupo)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Goleador>(entity =>
            {
                entity.HasOne(d => d.Jugador)
                    .WithMany(p => p.Goleador)
                    .HasForeignKey(d => d.JugadorId)
                    .HasConstraintName("FK_Goleador_Jugador");
            });

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Estatura).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.Jugador)
                    .HasForeignKey(d => d.EquipoId)
                    .HasConstraintName("FK_Jugador_Equipo");

                entity.HasOne(d => d.Posicion)
                    .WithMany(p => p.Jugador)
                    .HasForeignKey(d => d.PosicionId)
                    .HasConstraintName("FK_Jugador_Posicion");
            });

            modelBuilder.Entity<Posicion>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Resultado>(entity =>
            {
                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.Resultado)
                    .HasForeignKey(d => d.EquipoId)
                    .HasConstraintName("FK_Resultado_Equipo");
            });

            modelBuilder.Entity<TablaPosiciones>(entity =>
            {
                entity.Property(e => e.Pg).HasColumnName("pg");

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.TablaPosiciones)
                    .HasForeignKey(d => d.EquipoId)
                    .HasConstraintName("FK_TablaPosciones_Equipo");
            });

            modelBuilder.Entity<TarjetaRoja>(entity =>
            {
                entity.HasOne(d => d.Jugador)
                    .WithMany(p => p.TarjetaRoja)
                    .HasForeignKey(d => d.JugadorId)
                    .HasConstraintName("FK_Tarjeta_Jugador");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        #endregion

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
