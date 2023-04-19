using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Models;

public partial class PubAspContext : DbContext
{
    public PubAspContext()
    {
    }

    public PubAspContext(DbContextOptions<PubAspContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beer> Beers { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=CATALINAHP\\SERVER_DEV;\nDatabase=PubASP;\nTrusted_Connection=True;\nTrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_id_beer");

            entity.ToTable("BEER");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Estilo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ESTILO");
            entity.Property(e => e.Marca)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MARCA");
            entity.Property(e => e.Origen)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ORIGEN");
            entity.Property(e => e.Precio).HasColumnName("PRECIO");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_id_client");

            entity.ToTable("CLIENT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VENTAS");

            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.IdBeer).HasColumnName("ID_BEER");
            entity.Property(e => e.IdClient).HasColumnName("ID_CLIENT");

            entity.HasOne(d => d.IdBeerNavigation).WithMany()
                .HasForeignKey(d => d.IdBeer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_beer");

            entity.HasOne(d => d.IdClientNavigation).WithMany()
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_client");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
