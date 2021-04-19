using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.DataContext
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<CompraProducto> CompraProductos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_TipoDocumento");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compra_Cliente");
            });

            modelBuilder.Entity<CompraProducto>(entity =>
            {
                entity.HasKey(e => new { e.IdCompra, e.IdProducto });

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.CompraProductos)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compra_Producto_Compra");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.CompraProductos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compra_Producto_Producto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.EstaActivo).HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
