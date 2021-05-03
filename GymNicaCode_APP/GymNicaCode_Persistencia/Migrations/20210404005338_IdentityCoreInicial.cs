using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymNicaCode_Persistencia.Migrations
{
    public partial class IdentityCoreInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PV");

            migrationBuilder.EnsureSchema(
                name: "MEMBRESIA");

            migrationBuilder.EnsureSchema(
                name: "USUARIO");

            migrationBuilder.CreateTable(
                name: "Almacen",
                schema: "PV",
                columns: table => new
                {
                    IdAlmacen = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreAlmacen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Estatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Almacen__7339837B2A4B4B5E", x => x.IdAlmacen);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "MEMBRESIA",
                columns: table => new
                {
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ApellidosCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FotoCliente = table.Column<byte[]>(type: "image", nullable: true),
                    ClaveDeAcceso = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Estatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cliente__D594664207F6335A", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                schema: "USUARIO",
                columns: table => new
                {
                    IdEmpleado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Estatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empleado__CE6D8B9E7F60ED59", x => x.IdEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "Membresia",
                schema: "MEMBRESIA",
                columns: table => new
                {
                    IdMembresia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreMembresia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    TipoMembresia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Dias = table.Column<int>(type: "int", nullable: true),
                    Semana = table.Column<int>(type: "int", nullable: true),
                    Meses = table.Column<int>(type: "int", nullable: true),
                    HoraInicio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    HoraFinal = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Estats = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Membresi__A76E8B160BC6C43E", x => x.IdMembresia);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                schema: "PV",
                columns: table => new
                {
                    IdProdcuto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreProducto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Estatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__1CFBE03A2E1BDC42", x => x.IdProdcuto);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MiembroGym",
                schema: "MEMBRESIA",
                columns: table => new
                {
                    IdMiembroGym = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaComienzo = table.Column<DateTime>(type: "date", nullable: true),
                    Estatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MiembroG__30C564200F975522", x => x.IdMiembroGym);
                    table.ForeignKey(
                        name: "FK__MiembroGy__IdCli__117F9D94",
                        column: x => x.IdCliente,
                        principalSchema: "MEMBRESIA",
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistroEntradaCliente",
                schema: "MEMBRESIA",
                columns: table => new
                {
                    IdRegistroEntradaCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "date", nullable: true),
                    Estatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Registro__7CE3167225869641", x => x.IdRegistroEntradaCliente);
                    table.ForeignKey(
                        name: "FK__RegistroE__IdCli__276EDEB3",
                        column: x => x.IdCliente,
                        principalSchema: "MEMBRESIA",
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdEmpleado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Usuarios__IdEmpl__0519C6AF",
                        column: x => x.IdEmpleado,
                        principalSchema: "USUARIO",
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                schema: "PV",
                columns: table => new
                {
                    IdCompra = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdAlmacen = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoFactura = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaCompra = table.Column<DateTime>(type: "date", nullable: true),
                    IdEmpleado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Compra__0A5CDB5C31EC6D26", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK__Compra__IdAlmace__33D4B598",
                        column: x => x.IdAlmacen,
                        principalSchema: "PV",
                        principalTable: "Almacen",
                        principalColumn: "IdAlmacen",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Compra__IdEmplea__34C8D9D1",
                        column: x => x.IdEmpleado,
                        principalSchema: "USUARIO",
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                schema: "PV",
                columns: table => new
                {
                    IdFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdAlmacen = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEmpleado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoFactura = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaFactura = table.Column<DateTime>(type: "date", nullable: true),
                    Estatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Factura__50E7BAF149C3F6B7", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK__Factura__IdAlmac__4CA06362",
                        column: x => x.IdAlmacen,
                        principalSchema: "PV",
                        principalTable: "Almacen",
                        principalColumn: "IdAlmacen",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Factura__IdClien__4BAC3F29",
                        column: x => x.IdCliente,
                        principalSchema: "MEMBRESIA",
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Factura__IdEmple__4D94879B",
                        column: x => x.IdEmpleado,
                        principalSchema: "USUARIO",
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleMiembroGym",
                schema: "MEMBRESIA",
                columns: table => new
                {
                    IdDetalleMiembroGym = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMiembroGym = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMembresia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "date", nullable: true),
                    Estatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleM__C4E74AAA1FCDBCEB", x => x.IdDetalleMiembroGym);
                    table.ForeignKey(
                        name: "FK__DetalleMi__IdMem__22AA2996",
                        column: x => x.IdMembresia,
                        principalSchema: "MEMBRESIA",
                        principalTable: "Membresia",
                        principalColumn: "IdMembresia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__DetalleMi__IdMie__21B6055D",
                        column: x => x.IdMiembroGym,
                        principalSchema: "MEMBRESIA",
                        principalTable: "MiembroGym",
                        principalColumn: "IdMiembroGym",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCompra",
                schema: "PV",
                columns: table => new
                {
                    IdDetalleCompra = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCompra = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Costo = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    MargenDeGanancia = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Estatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleC__E046CCBB440B1D61", x => x.IdDetalleCompra);
                    table.ForeignKey(
                        name: "FK__DetalleCo__IdCom__45F365D3",
                        column: x => x.IdCompra,
                        principalSchema: "PV",
                        principalTable: "Compra",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__DetalleCo__IdPro__46E78A0C",
                        column: x => x.IdProducto,
                        principalSchema: "PV",
                        principalTable: "Producto",
                        principalColumn: "IdProdcuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFactura",
                schema: "PV",
                columns: table => new
                {
                    IdDetalleFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdFactura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Estatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetalleF__DB5F46315070F446", x => x.IdDetalleFactura);
                    table.ForeignKey(
                        name: "FK__DetalleFa__IdFac__52593CB8",
                        column: x => x.IdFactura,
                        principalSchema: "PV",
                        principalTable: "Factura",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__DetalleFa__IdPro__534D60F1",
                        column: x => x.IdProducto,
                        principalSchema: "PV",
                        principalTable: "Producto",
                        principalColumn: "IdProdcuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdEmpleado",
                table: "AspNetUsers",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_IdAlmacen",
                schema: "PV",
                table: "Compra",
                column: "IdAlmacen");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_IdEmpleado",
                schema: "PV",
                table: "Compra",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_IdCompra",
                schema: "PV",
                table: "DetalleCompra",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_IdProducto",
                schema: "PV",
                table: "DetalleCompra",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_IdFactura",
                schema: "PV",
                table: "DetalleFactura",
                column: "IdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_IdProducto",
                schema: "PV",
                table: "DetalleFactura",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMiembroGym_IdMembresia",
                schema: "MEMBRESIA",
                table: "DetalleMiembroGym",
                column: "IdMembresia");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMiembroGym_IdMiembroGym",
                schema: "MEMBRESIA",
                table: "DetalleMiembroGym",
                column: "IdMiembroGym");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IdAlmacen",
                schema: "PV",
                table: "Factura",
                column: "IdAlmacen");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IdCliente",
                schema: "PV",
                table: "Factura",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IdEmpleado",
                schema: "PV",
                table: "Factura",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_MiembroGym_IdCliente",
                schema: "MEMBRESIA",
                table: "MiembroGym",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroEntradaCliente_IdCliente",
                schema: "MEMBRESIA",
                table: "RegistroEntradaCliente",
                column: "IdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DetalleCompra",
                schema: "PV");

            migrationBuilder.DropTable(
                name: "DetalleFactura",
                schema: "PV");

            migrationBuilder.DropTable(
                name: "DetalleMiembroGym",
                schema: "MEMBRESIA");

            migrationBuilder.DropTable(
                name: "RegistroEntradaCliente",
                schema: "MEMBRESIA");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Compra",
                schema: "PV");

            migrationBuilder.DropTable(
                name: "Factura",
                schema: "PV");

            migrationBuilder.DropTable(
                name: "Producto",
                schema: "PV");

            migrationBuilder.DropTable(
                name: "Membresia",
                schema: "MEMBRESIA");

            migrationBuilder.DropTable(
                name: "MiembroGym",
                schema: "MEMBRESIA");

            migrationBuilder.DropTable(
                name: "Almacen",
                schema: "PV");

            migrationBuilder.DropTable(
                name: "Empleado",
                schema: "USUARIO");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "MEMBRESIA");
        }
    }
}
