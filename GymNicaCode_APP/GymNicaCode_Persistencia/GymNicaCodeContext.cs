using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GymNicaCode_Dominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
#nullable disable

namespace GymNicaCode_Persistencia
{
    public partial class GymNicaCodeContext : IdentityDbContext<Usuario>
    {
        public GymNicaCodeContext()
        {
        }

        public GymNicaCodeContext(DbContextOptions<GymNicaCodeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Almacen> Almacens { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public virtual DbSet<DetalleMiembroGym> DetalleMiembroGyms { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Membresium> Membresia { get; set; }
        public virtual DbSet<MiembroGym> MiembroGyms { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<RegistroEntradaCliente> RegistroEntradaClientes { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.;Database=GymNicaCode;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Almacen>(entity =>
            {
                entity.HasKey(e => e.IdAlmacen)
                    .HasName("PK__Almacen__7339837B2A4B4B5E");

                entity.ToTable("Almacen", "PV");

                entity.Property(e => e.NombreAlmacen).HasMaxLength(100);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__D594664207F6335A");

                entity.ToTable("Cliente", "MEMBRESIA");

                entity.Property(e => e.ApellidosCliente).HasMaxLength(100);

                entity.Property(e => e.Cedula).HasMaxLength(100);

                entity.Property(e => e.ClaveDeAcceso).HasMaxLength(100);

                entity.Property(e => e.Correo).HasMaxLength(100);

                entity.Property(e => e.FotoCliente).HasColumnType("image");

                entity.Property(e => e.NombreCliente).HasMaxLength(100);
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK__Compra__0A5CDB5C31EC6D26");

                entity.ToTable("Compra", "PV");

                entity.Property(e => e.FechaCompra).HasColumnType("date");

                entity.Property(e => e.NoFactura).HasMaxLength(100);

                entity.HasOne(d => d.IdAlmacenNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdAlmacen)
                    .HasConstraintName("FK__Compra__IdAlmace__33D4B598");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK__Compra__IdEmplea__34C8D9D1");
            });

            modelBuilder.Entity<DetalleCompra>(entity =>
            {
                entity.HasKey(e => e.IdDetalleCompra)
                    .HasName("PK__DetalleC__E046CCBB440B1D61");

                entity.ToTable("DetalleCompra", "PV");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Costo).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MargenDeGanancia).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.IdCompra)
                    .HasConstraintName("FK__DetalleCo__IdCom__45F365D3");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__DetalleCo__IdPro__46E78A0C");
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.IdDetalleFactura)
                    .HasName("PK__DetalleF__DB5F46315070F446");

                entity.ToTable("DetalleFactura", "PV");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.IdFactura)
                    .HasConstraintName("FK__DetalleFa__IdFac__52593CB8");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__DetalleFa__IdPro__534D60F1");
            });

            modelBuilder.Entity<DetalleMiembroGym>(entity =>
            {
                entity.HasKey(e => e.IdDetalleMiembroGym)
                    .HasName("PK__DetalleM__C4E74AAA1FCDBCEB");

                entity.ToTable("DetalleMiembroGym", "MEMBRESIA");

                entity.Property(e => e.FechaVencimiento).HasColumnType("date");

                entity.HasOne(d => d.IdMembresiaNavigation)
                    .WithMany(p => p.DetalleMiembroGyms)
                    .HasForeignKey(d => d.IdMembresia)
                    .HasConstraintName("FK__DetalleMi__IdMem__22AA2996");

                entity.HasOne(d => d.IdMiembroGymNavigation)
                    .WithMany(p => p.DetalleMiembroGyms)
                    .HasForeignKey(d => d.IdMiembroGym)
                    .HasConstraintName("FK__DetalleMi__IdMie__21B6055D");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__Empleado__CE6D8B9E7F60ED59");

                entity.ToTable("Empleado", "USUARIO");

                entity.Property(e => e.Apellidos).HasMaxLength(100);

                entity.Property(e => e.Cedula).HasMaxLength(100);

                entity.Property(e => e.Nombres).HasMaxLength(100);
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__Factura__50E7BAF149C3F6B7");

                entity.ToTable("Factura", "PV");

                entity.Property(e => e.FechaFactura).HasColumnType("date");

                entity.Property(e => e.NoFactura).HasMaxLength(100);

                entity.HasOne(d => d.IdAlmacenNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdAlmacen)
                    .HasConstraintName("FK__Factura__IdAlmac__4CA06362");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Factura__IdClien__4BAC3F29");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK__Factura__IdEmple__4D94879B");
            });

            modelBuilder.Entity<Membresium>(entity =>
            {
                entity.HasKey(e => e.IdMembresia)
                    .HasName("PK__Membresi__A76E8B160BC6C43E");

                entity.ToTable("Membresia", "MEMBRESIA");

                entity.Property(e => e.HoraFinal).HasMaxLength(30);

                entity.Property(e => e.HoraInicio).HasMaxLength(30);

                entity.Property(e => e.NombreMembresia).HasMaxLength(100);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TipoMembresia).HasMaxLength(30);
            });

            modelBuilder.Entity<MiembroGym>(entity =>
            {
                entity.HasKey(e => e.IdMiembroGym)
                    .HasName("PK__MiembroG__30C564200F975522");

                entity.ToTable("MiembroGym", "MEMBRESIA");

                entity.Property(e => e.FechaComienzo).HasColumnType("date");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.MiembroGyms)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__MiembroGy__IdCli__117F9D94");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProdcuto)
                    .HasName("PK__Producto__1CFBE03A2E1BDC42");

                entity.ToTable("Producto", "PV");

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.NombreProducto).HasMaxLength(100);
            });

            modelBuilder.Entity<RegistroEntradaCliente>(entity =>
            {
                entity.HasKey(e => e.IdRegistroEntradaCliente)
                    .HasName("PK__Registro__7CE3167225869641");

                entity.ToTable("RegistroEntradaCliente", "MEMBRESIA");

                entity.Property(e => e.IdRegistroEntradaCliente).ValueGeneratedNever();

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.RegistroEntradaClientes)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__RegistroE__IdCli__276EDEB3");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                //entity.HasKey(e => e.IdUsuario)
                //    .HasName("PK__Usuarios__5B65BF9703317E3D");

                //entity.ToTable("Usuarios", "USUARIO");

                //entity.Property(e => e.Contraseña).HasMaxLength(100);

                //entity.Property(e => e.Usuarios)
                //    .HasMaxLength(100)
                //    .HasColumnName("Usuario");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK__Usuarios__IdEmpl__0519C6AF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
