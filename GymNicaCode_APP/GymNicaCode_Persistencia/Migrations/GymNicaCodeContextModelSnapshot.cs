﻿// <auto-generated />
using System;
using GymNicaCode_Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GymNicaCode_Persistencia.Migrations
{
    [DbContext(typeof(GymNicaCodeContext))]
    partial class GymNicaCodeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GymNicaCode_Dominio.Almacen", b =>
                {
                    b.Property<Guid>("IdAlmacen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Estatus")
                        .HasColumnType("bit");

                    b.Property<string>("NombreAlmacen")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdAlmacen")
                        .HasName("PK__Almacen__7339837B2A4B4B5E");

                    b.ToTable("Almacen", "PV");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.Cliente", b =>
                {
                    b.Property<Guid>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApellidosCliente")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Cedula")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ClaveDeAcceso")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Correo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("Estatus")
                        .HasColumnType("bit");

                    b.Property<byte[]>("FotoCliente")
                        .HasColumnType("image");

                    b.Property<string>("NombreCliente")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("IdCliente")
                        .HasName("PK__Cliente__D594664207F6335A");

                    b.ToTable("Cliente", "MEMBRESIA");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.Compra", b =>
                {
                    b.Property<Guid>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Estatus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaCompra")
                        .HasColumnType("date");

                    b.Property<Guid>("IdAlmacen")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdEmpleado")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NoFactura")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdCompra")
                        .HasName("PK__Compra__0A5CDB5C31EC6D26");

                    b.HasIndex("IdAlmacen");

                    b.HasIndex("IdEmpleado");

                    b.ToTable("Compra", "PV");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.DetalleCompra", b =>
                {
                    b.Property<Guid>("IdDetalleCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Cantidad")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal?>("Costo")
                        .HasColumnType("decimal(18,4)");

                    b.Property<bool?>("Estatus")
                        .HasColumnType("bit");

                    b.Property<Guid>("IdCompra")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProducto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("MargenDeGanancia")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("IdDetalleCompra")
                        .HasName("PK__DetalleC__E046CCBB440B1D61");

                    b.HasIndex("IdCompra");

                    b.HasIndex("IdProducto");

                    b.ToTable("DetalleCompra", "PV");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.DetalleFactura", b =>
                {
                    b.Property<Guid>("IdDetalleFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Cantidad")
                        .HasColumnType("decimal(18,4)");

                    b.Property<bool?>("Estatus")
                        .HasColumnType("bit");

                    b.Property<Guid>("IdFactura")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProducto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("IdDetalleFactura")
                        .HasName("PK__DetalleF__DB5F46315070F446");

                    b.HasIndex("IdFactura");

                    b.HasIndex("IdProducto");

                    b.ToTable("DetalleFactura", "PV");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.DetalleMiembroGym", b =>
                {
                    b.Property<Guid>("IdDetalleMiembroGym")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Estatus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaVencimiento")
                        .HasColumnType("date");

                    b.Property<Guid>("IdMembresia")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdMiembroGym")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdDetalleMiembroGym")
                        .HasName("PK__DetalleM__C4E74AAA1FCDBCEB");

                    b.HasIndex("IdMembresia");

                    b.HasIndex("IdMiembroGym");

                    b.ToTable("DetalleMiembroGym", "MEMBRESIA");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.Empleado", b =>
                {
                    b.Property<Guid>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellidos")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Cedula")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("Estatus")
                        .HasColumnType("bit");

                    b.Property<string>("Nombres")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("IdEmpleado")
                        .HasName("PK__Empleado__CE6D8B9E7F60ED59");

                    b.ToTable("Empleado", "USUARIO");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.Factura", b =>
                {
                    b.Property<Guid>("IdFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Estatus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaFactura")
                        .HasColumnType("date");

                    b.Property<Guid>("IdAlmacen")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdCliente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdEmpleado")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NoFactura")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdFactura")
                        .HasName("PK__Factura__50E7BAF149C3F6B7");

                    b.HasIndex("IdAlmacen");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEmpleado");

                    b.ToTable("Factura", "PV");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.Membresium", b =>
                {
                    b.Property<Guid>("IdMembresia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Dias")
                        .HasColumnType("int");

                    b.Property<bool?>("Estats")
                        .HasColumnType("bit");

                    b.Property<string>("HoraFinal")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("HoraInicio")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("Meses")
                        .HasColumnType("int");

                    b.Property<string>("NombreMembresia")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int?>("Semana")
                        .HasColumnType("int");

                    b.Property<string>("TipoMembresia")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdMembresia")
                        .HasName("PK__Membresi__A76E8B160BC6C43E");

                    b.ToTable("Membresia", "MEMBRESIA");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.MiembroGym", b =>
                {
                    b.Property<Guid>("IdMiembroGym")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Estatus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaComienzo")
                        .HasColumnType("date");

                    b.Property<Guid>("IdCliente")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdMiembroGym")
                        .HasName("PK__MiembroG__30C564200F975522");

                    b.HasIndex("IdCliente");

                    b.ToTable("MiembroGym", "MEMBRESIA");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.Producto", b =>
                {
                    b.Property<Guid>("IdProdcuto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("Estatus")
                        .HasColumnType("bit");

                    b.Property<string>("NombreProducto")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdProdcuto")
                        .HasName("PK__Producto__1CFBE03A2E1BDC42");

                    b.ToTable("Producto", "PV");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.RegistroEntradaCliente", b =>
                {
                    b.Property<Guid>("IdRegistroEntradaCliente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Estatus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaIngreso")
                        .HasColumnType("date");

                    b.Property<Guid>("IdCliente")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdRegistroEntradaCliente")
                        .HasName("PK__Registro__7CE3167225869641");

                    b.HasIndex("IdCliente");

                    b.ToTable("RegistroEntradaCliente", "MEMBRESIA");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<Guid>("IdEmpleado")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("IdEmpleado");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.Compra", b =>
                {
                    b.HasOne("GymNicaCode_Dominio.Almacen", "IdAlmacenNavigation")
                        .WithMany("Compras")
                        .HasForeignKey("IdAlmacen")
                        .HasConstraintName("FK__Compra__IdAlmace__33D4B598")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymNicaCode_Dominio.Empleado", "IdEmpleadoNavigation")
                        .WithMany("Compras")
                        .HasForeignKey("IdEmpleado")
                        .HasConstraintName("FK__Compra__IdEmplea__34C8D9D1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdAlmacenNavigation");

                    b.Navigation("IdEmpleadoNavigation");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.DetalleCompra", b =>
                {
                    b.HasOne("GymNicaCode_Dominio.Compra", "IdCompraNavigation")
                        .WithMany("DetalleCompras")
                        .HasForeignKey("IdCompra")
                        .HasConstraintName("FK__DetalleCo__IdCom__45F365D3")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymNicaCode_Dominio.Producto", "IdProductoNavigation")
                        .WithMany("DetalleCompras")
                        .HasForeignKey("IdProducto")
                        .HasConstraintName("FK__DetalleCo__IdPro__46E78A0C")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCompraNavigation");

                    b.Navigation("IdProductoNavigation");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.DetalleFactura", b =>
                {
                    b.HasOne("GymNicaCode_Dominio.Factura", "IdFacturaNavigation")
                        .WithMany("DetalleFacturas")
                        .HasForeignKey("IdFactura")
                        .HasConstraintName("FK__DetalleFa__IdFac__52593CB8")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymNicaCode_Dominio.Producto", "IdProductoNavigation")
                        .WithMany("DetalleFacturas")
                        .HasForeignKey("IdProducto")
                        .HasConstraintName("FK__DetalleFa__IdPro__534D60F1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdFacturaNavigation");

                    b.Navigation("IdProductoNavigation");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.DetalleMiembroGym", b =>
                {
                    b.HasOne("GymNicaCode_Dominio.Membresium", "IdMembresiaNavigation")
                        .WithMany("DetalleMiembroGyms")
                        .HasForeignKey("IdMembresia")
                        .HasConstraintName("FK__DetalleMi__IdMem__22AA2996")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymNicaCode_Dominio.MiembroGym", "IdMiembroGymNavigation")
                        .WithMany("DetalleMiembroGyms")
                        .HasForeignKey("IdMiembroGym")
                        .HasConstraintName("FK__DetalleMi__IdMie__21B6055D")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdMembresiaNavigation");

                    b.Navigation("IdMiembroGymNavigation");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.Factura", b =>
                {
                    b.HasOne("GymNicaCode_Dominio.Almacen", "IdAlmacenNavigation")
                        .WithMany("Facturas")
                        .HasForeignKey("IdAlmacen")
                        .HasConstraintName("FK__Factura__IdAlmac__4CA06362")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymNicaCode_Dominio.Cliente", "IdClienteNavigation")
                        .WithMany("Facturas")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__Factura__IdClien__4BAC3F29")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymNicaCode_Dominio.Empleado", "IdEmpleadoNavigation")
                        .WithMany("Facturas")
                        .HasForeignKey("IdEmpleado")
                        .HasConstraintName("FK__Factura__IdEmple__4D94879B")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdAlmacenNavigation");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdEmpleadoNavigation");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.MiembroGym", b =>
                {
                    b.HasOne("GymNicaCode_Dominio.Cliente", "IdClienteNavigation")
                        .WithMany("MiembroGyms")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__MiembroGy__IdCli__117F9D94")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdClienteNavigation");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.RegistroEntradaCliente", b =>
                {
                    b.HasOne("GymNicaCode_Dominio.Cliente", "IdClienteNavigation")
                        .WithMany("RegistroEntradaClientes")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__RegistroE__IdCli__276EDEB3")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdClienteNavigation");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.Usuario", b =>
                {
                    b.HasOne("GymNicaCode_Dominio.Empleado", "IdEmpleadoNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdEmpleado")
                        .HasConstraintName("FK__Usuarios__IdEmpl__0519C6AF")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdEmpleadoNavigation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GymNicaCode_Dominio.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GymNicaCode_Dominio.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymNicaCode_Dominio.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GymNicaCode_Dominio.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GymNicaCode_Dominio.Almacen", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.Cliente", b =>
                {
                    b.Navigation("Facturas");

                    b.Navigation("MiembroGyms");

                    b.Navigation("RegistroEntradaClientes");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.Compra", b =>
                {
                    b.Navigation("DetalleCompras");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.Empleado", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("Facturas");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.Factura", b =>
                {
                    b.Navigation("DetalleFacturas");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.Membresium", b =>
                {
                    b.Navigation("DetalleMiembroGyms");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.MiembroGym", b =>
                {
                    b.Navigation("DetalleMiembroGyms");
                });

            modelBuilder.Entity("GymNicaCode_Dominio.Producto", b =>
                {
                    b.Navigation("DetalleCompras");

                    b.Navigation("DetalleFacturas");
                });
#pragma warning restore 612, 618
        }
    }
}
