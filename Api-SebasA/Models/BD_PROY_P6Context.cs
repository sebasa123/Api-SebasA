using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api_SebasA.Models
{
    public partial class BD_PROY_P6Context : DbContext
    {
        public BD_PROY_P6Context()
        {
        }

        public BD_PROY_P6Context(DbContextOptions<BD_PROY_P6Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<Artista> Artista { get; set; } = null!;
        public virtual DbSet<Banda> Banda { get; set; } = null!;
        public virtual DbSet<Cancion> Cancions { get; set; } = null!;
        public virtual DbSet<CodigoRecuperacion> CodigoRecuperacions { get; set; } = null!;
        public virtual DbSet<Genero> Generos { get; set; } = null!;
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("SERVER=LAPTOP-0OCE7TFC\\SQLEXPRESS;DATABASE=BD_PROY_P6;INTEGRATED SECURITY=TRUE;User Id=;Password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.Idalb)
                    .HasName("PK__Album__9321EF229762C46C");

                entity.ToTable("Album");

                entity.Property(e => e.Idalb).HasColumnName("IDAlb");

                entity.Property(e => e.AlbXartFk).HasColumnName("AlbXArtFK");

                entity.Property(e => e.AlbXbanFk).HasColumnName("AlbXBanFK");

                entity.Property(e => e.AlbXgenFk).HasColumnName("AlbXGenFK");

                entity.Property(e => e.FechaAlb).HasColumnType("date");

                entity.Property(e => e.NombreAlb).HasMaxLength(40);

                entity.HasOne(d => d.AlbXartFkNavigation)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.AlbXartFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Album__AlbXArtFK__1A14E395");

                entity.HasOne(d => d.AlbXbanFkNavigation)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.AlbXbanFk)
                    .HasConstraintName("FK__Album__AlbXBanFK__1B0907CE");

                entity.HasOne(d => d.AlbXgenFkNavigation)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.AlbXgenFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Album__AlbXGenFK__1920BF5C");
            });

            modelBuilder.Entity<Artista>(entity =>
            {
                entity.HasKey(e => e.Idart)
                    .HasName("PK__Artista__9321BE18FE9C6C34");

                entity.Property(e => e.Idart).HasColumnName("IDArt");

                entity.Property(e => e.DescripcionArt).HasMaxLength(180);

                entity.Property(e => e.NombreArt).HasMaxLength(40);
            });

            modelBuilder.Entity<Banda>(entity =>
            {
                entity.HasKey(e => e.Idban)
                    .HasName("PK__Banda__93603FF622CE6540");

                entity.Property(e => e.Idban).HasColumnName("IDBan");

                entity.Property(e => e.BanXartFk).HasColumnName("BanXArtFK");

                entity.Property(e => e.DescripcionBan).HasMaxLength(180);

                entity.Property(e => e.NombreBan).HasMaxLength(40);

                entity.HasOne(d => d.BanXartFkNavigation)
                    .WithMany(p => p.Banda)
                    .HasForeignKey(d => d.BanXartFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Banda__BanXArtFK__145C0A3F");
            });

            modelBuilder.Entity<Cancion>(entity =>
            {
                entity.HasKey(e => e.Idcan)
                    .HasName("PK__Cancion__91AEF82E558AE53E");

                entity.ToTable("Cancion");

                entity.Property(e => e.Idcan).HasColumnName("IDCan");

                entity.Property(e => e.CanXalbFk).HasColumnName("CanXAlbFK");

                entity.Property(e => e.CanXartFk).HasColumnName("CanXArtFK");

                entity.Property(e => e.CanXbanFk).HasColumnName("CanXBanFK");

                entity.Property(e => e.CanXgenFk).HasColumnName("CanXGenFK");

                entity.Property(e => e.NombreCan).HasMaxLength(40);

                entity.HasOne(d => d.CanXalbFkNavigation)
                    .WithMany(p => p.Cancions)
                    .HasForeignKey(d => d.CanXalbFk)
                    .HasConstraintName("FK__Cancion__CanXAlb__1DE57479");

                entity.HasOne(d => d.CanXartFkNavigation)
                    .WithMany(p => p.Cancions)
                    .HasForeignKey(d => d.CanXartFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cancion__CanXArt__1FCDBCEB");

                entity.HasOne(d => d.CanXbanFkNavigation)
                    .WithMany(p => p.Cancions)
                    .HasForeignKey(d => d.CanXbanFk)
                    .HasConstraintName("FK__Cancion__CanXBan__20C1E124");

                entity.HasOne(d => d.CanXgenFkNavigation)
                    .WithMany(p => p.Cancions)
                    .HasForeignKey(d => d.CanXgenFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cancion__CanXGen__1ED998B2");
            });

            modelBuilder.Entity<CodigoRecuperacion>(entity =>
            {
                entity.HasKey(e => e.Idcod);

                entity.ToTable("CodigoRecuperacion");

                entity.Property(e => e.Idcod)
                    .ValueGeneratedNever()
                    .HasColumnName("IDCod");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.CorreoElec)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.FechaCod).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.Idgen)
                    .HasName("PK__Genero__94963B6AAF9B9DB9");

                entity.ToTable("Genero");

                entity.Property(e => e.Idgen).HasColumnName("IDGen");

                entity.Property(e => e.DescripcionGen).HasMaxLength(180);

                entity.Property(e => e.NombreGen).HasMaxLength(40);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdtipoUs);

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.IdtipoUs)
                    .ValueGeneratedNever()
                    .HasColumnName("IDTipoUs");

                entity.Property(e => e.DescTipoUs)
                    .HasMaxLength(255)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idus)
                    .HasName("PK__Usuario__B87C12B890ED8B9E");

                entity.ToTable("Usuario");

                entity.Property(e => e.Idus).HasColumnName("IDUs");

                entity.Property(e => e.ContraUs).HasMaxLength(40);

                entity.Property(e => e.NombreUs).HasMaxLength(40);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
