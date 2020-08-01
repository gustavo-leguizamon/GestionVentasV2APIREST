using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Repositories.Contexts
{
    public class GestionVentasContext : DbContext
    {
        public GestionVentasContext()
        {
        }

        public GestionVentasContext(DbContextOptions<GestionVentasContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<CarritoProducto> CarritoProducto { get; set; }
        public DbSet<Carrito> Carrito { get; set; }

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

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => e.CarritoId);
                entity.Property(e => e.CarritoId).ValueGeneratedOnAdd();

                entity.HasOne(e => e.Cliente).WithMany(c => c.Carritos).HasForeignKey(e => e.ClienteId).IsRequired();

                entity.HasData(
                    new Carrito() { CarritoId = 1, ClienteId = 1 },
                    new Carrito() { CarritoId = 2, ClienteId = 2 },
                    new Carrito() { CarritoId = 3, ClienteId = 2 }
                );

            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.EstadoId);
                entity.Property(e => e.EstadoId).UseIdentityColumn();
                entity.Property(e => e.Nombre).HasMaxLength(30).IsRequired();

                entity.HasData(
                    new Estado { EstadoId = 1, Nombre = "Activo" },
                    new Estado { EstadoId = 2, Nombre = "Cancelado" }
                );
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.HasKey(e => e.VentasId);
                entity.Property(e => e.VentasId).UseIdentityColumn();
                entity.Property(e => e.Fecha).HasColumnType("datetime").IsRequired();
                entity.Property(e => e.PrecioTotal).HasPrecision(15, 2).IsRequired();
                entity.Property(e => e.EstadoId).HasDefaultValue(1).IsRequired();

                entity.HasIndex(e => e.CarritoId).IsUnique();

                entity.HasOne(e => e.Carrito).WithMany(c => c.Ventas).HasForeignKey(e => e.CarritoId).IsRequired();
                entity.HasOne(e => e.Estado).WithMany(e => e.Ventas).HasForeignKey(e => e.EstadoId).IsRequired();
            });

            modelBuilder.Entity<CarritoProducto>(entity =>
            {
                entity.HasKey(e => e.CarritoProductoId);
                entity.Property(e => e.CarritoProductoId).UseIdentityColumn();
                entity.Property(e => e.Cantidad).IsRequired();

                entity.HasOne(e => e.Carrito).WithMany(c => c.CarritoProducto).HasForeignKey(e => e.CarritoId).IsRequired();
                entity.HasOne(e => e.Producto).WithMany(p => p.CarritoProductos).HasForeignKey(e => e.ProductoId).IsRequired();

                entity.HasData(
                    new CarritoProducto() { CarritoProductoId = 1, CarritoId = 1, ProductoId = 3, Cantidad = 1 },
                    new CarritoProducto() { CarritoProductoId = 2, CarritoId = 1, ProductoId = 4, Cantidad = 1 },
                    new CarritoProducto() { CarritoProductoId = 3, CarritoId = 2, ProductoId = 3, Cantidad = 1 },
                    new CarritoProducto() { CarritoProductoId = 4, CarritoId = 3, ProductoId = 5, Cantidad = 1 }
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
                entity.Property(e => e.Imagen).HasMaxLength(1000);
                entity.Property(e => e.Precio).HasPrecision(15, 2).IsRequired();

                entity.HasData(
                    new Producto() { ProductoId = 1, Codigo = "MOU", Nombre = "Mouse", Marca = "Noganet", Imagen = "https://www.xt-pc.com.ar/img/productos/Pics_Prod/MOU606.jpg", Precio = 199.99M },
                    new Producto() { ProductoId = 2, Codigo = "CAM", Nombre = "Camara", Marca = null, Imagen = "https://arsonyb2c.vteximg.com.br/arquivos/ids/292526-1000-1000/ILCE-7K_Black-0.jpg?v=637124363789970000", Precio = 1500.00M },
                    new Producto() { ProductoId = 3, Codigo = "TEC", Nombre = "Teclado", Marca = "Noganet", Imagen = "https://http2.mlstatic.com/teclado-usb-ergonomico-pc-notebook-oficina-qwerty-espanol-garantia-oficial-D_NQ_NP_626103-MLA31936565669_082019-F.jpg", Precio = 2060M },
                    new Producto() { ProductoId = 4, Codigo = "MON", Nombre = "Monitor", Marca = "Samsung", Imagen = "https://images.samsung.com/is/image/samsung/uk-led-sf350-ls24f350fhuxen-001-front-black?$PD_GALLERY_L_JPG$", Precio = 4650.50M },
                    new Producto() { ProductoId = 5, Codigo = "CPU", Nombre = "CPU", Marca = "Gigabit", Imagen = "https://vignette2.wikia.nocookie.net/applezone/images/6/67/CPU.jpg/revision/latest?cb=20120318030604&path-prefix=es", Precio = 6900M },
                    new Producto() { ProductoId = 6, Codigo = "AUR", Nombre = "Auricular", Marca = "WorldTech", Imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQxHQK6bexxEunRDrGWtf-baJVbaFKOeX2cxA&usqp=CAU", Precio = 1299M },
                    new Producto() { ProductoId = 7, Codigo = "SIL", Nombre = "Silla gamer", Marca = "WorldTech", Imagen = "https://images.bidcom.com.ar/resize?src=https://www.bidcom.com.ar/publicacionesML/productos/SILLA14X/1000x1000-SILLA14X.jpg&w=500&q=100", Precio = 30999.99M },
                    new Producto() { ProductoId = 8, Codigo = "PAR", Nombre = "Parlantes", Marca = "Kolke", Imagen = "https://lh3.googleusercontent.com/proxy/_w0DznoyQ7Bn93pz8t3fY4zETeUWGQYH3ZWeiQkMCCdK7lnkuMuDH093tTDbaOdY1Ozi-hWD7oCRm0u31UBhbeZ2bucbfZGNlgy4", Precio = 299.99M },
                    new Producto() { ProductoId = 9, Codigo = "NOT", Nombre = "Notebook", Marca = "Intel", Imagen = "https://http2.mlstatic.com/notebook-hp-250-g7-core-i3-7020u-8gb-1tb-156-win10-cta-off-D_NQ_NP_692739-MLA31428906360_072019-O.webp", Precio = 20099.00M },
                    new Producto() { ProductoId = 10, Codigo = "JOY", Nombre = "Joystick", Marca = "Sony", Imagen = "https://http2.mlstatic.com/D_NQ_NP_702700-MLA32150735923_092019-O.webp", Precio = 13999M }
                );
            });
        }
    }
}
