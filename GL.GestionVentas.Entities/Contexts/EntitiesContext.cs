using GL.GestionVentas.Entities.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Entities.Contexts
{
    public class EntitiesContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Producto> Producto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=GL.GestionVentas;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.ClienteId);
                entity.Property(e => e.ClienteId).UseIdentityColumn();
                entity.Property(e => e.DNI).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Nombre).HasMaxLength(45).IsRequired();
                entity.Property(e => e.Apellido).HasMaxLength(45).IsRequired();
                entity.Property(e => e.Direccion).HasMaxLength(45).IsRequired();
                entity.Property(e => e.Telefono).HasMaxLength(45);

                entity.HasData(
                    new Cliente() { ClienteId = 1, DNI = "30000001", Nombre = "Roberto", Apellido = "Perez", Direccion = "Calle falsa 123", Telefono = "12345678" },
                    new Cliente() { ClienteId = 2, DNI = "40000001", Nombre = "Cosme", Apellido = "Fulanito", Direccion = "Av. Mitre 123", Telefono = "12345555" },
                    new Cliente() { ClienteId = 3, DNI = "50000001", Nombre = "Patricia", Apellido = "Rodriguez", Direccion = "Calchaqui 3000", Telefono = "11111111" }
                );
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.ProductoId);
                entity.Property(e => e.ProductoId).UseIdentityColumn();
                entity.Property(e => e.Codigo).HasMaxLength(45).IsRequired();
                entity.HasIndex(e => e.Codigo).IsUnique();
                entity.Property(e => e.Marca).HasMaxLength(45);
                entity.Property(e => e.Nombre).HasMaxLength(45).IsRequired();
                entity.Property(e => e.Precio).HasPrecision(15, 2).IsRequired();

                entity.HasData(
                    new Producto() { ProductoId = 1, Codigo = "MOU", Nombre = "Mouse", Marca = "Noganet", Precio = 10 },
                    new Producto() { ProductoId = 2, Codigo = "CAM", Nombre = "Camara", Marca = null, Precio = 15 },
                    new Producto() { ProductoId = 3, Codigo = "TEC", Nombre = "Teclado", Marca = "Noganet", Precio = 20 },
                    new Producto() { ProductoId = 4, Codigo = "MON", Nombre = "Monitor", Marca = "Samsung", Precio = 38 },
                    new Producto() { ProductoId = 5, Codigo = "CPU", Nombre = "CPU", Marca = "Gigabit", Precio = 250 }
                );
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.HasKey(e => e.VentasId);
                entity.Property(e => e.VentasId).UseIdentityColumn();
                entity.Property(e => e.Fecha).HasColumnType("datetime").IsRequired();
                entity.HasOne(e => e.Cliente).WithMany(c => c.Ventas).HasForeignKey(e => e.ClienteId).IsRequired();
                entity.HasOne(e => e.Producto).WithMany(p => p.Ventas).HasForeignKey(e => e.ProductoId).IsRequired();

                entity.HasData(
                    new Ventas() { VentasId = 1, Fecha = DateTime.Now, ClienteId = 1, ProductoId = 1 },
                    new Ventas() { VentasId = 2, Fecha = DateTime.Now, ClienteId = 1, ProductoId = 2 }
                );
            });
        }
    }
}
