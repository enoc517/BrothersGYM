using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrothersGYM.Data.Migrations
{
    /// <inheritdoc />
    public partial class gym : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividad",
                columns: table => new
                {
                    IDActividad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividad", x => x.IDActividad);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaMembresia",
                columns: table => new
                {
                    IDCategoriaMembresia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaMembresia", x => x.IDCategoriaMembresia);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaProducto",
                columns: table => new
                {
                    IDCategoriaProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProducto", x => x.IDCategoriaProducto);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IDCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IDCliente);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    IDDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.IDDepartamento);
                });

            migrationBuilder.CreateTable(
                name: "PaquteSesiones",
                columns: table => new
                {
                    PaqueteSesioensId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaquteSesiones", x => x.PaqueteSesioensId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    IDProveedores = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.IDProveedores);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    IDSala = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cupo = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.IDSala);
                });

            migrationBuilder.CreateTable(
                name: "ClienteMembresia",
                columns: table => new
                {
                    IDClienteMembresia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    IDCategoriaMembresia = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    FechaRenovacion = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteMembresia", x => x.IDClienteMembresia);
                    table.ForeignKey(
                        name: "FK_ClienteMembresia_CategoriaMembresia",
                        column: x => x.IDCategoriaMembresia,
                        principalTable: "CategoriaMembresia",
                        principalColumn: "IDCategoriaMembresia");
                    table.ForeignKey(
                        name: "FK_ClienteMembresia_Cliente",
                        column: x => x.IDCliente,
                        principalTable: "Cliente",
                        principalColumn: "IDCliente");
                });

            migrationBuilder.CreateTable(
                name: "Puesto",
                columns: table => new
                {
                    IDPuesto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PagHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IDDepartamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puesto", x => x.IDPuesto);
                    table.ForeignKey(
                        name: "FK_Puesto_Departamento",
                        column: x => x.IDDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "IDDepartamento");
                });

            migrationBuilder.CreateTable(
                name: "SesionesRayosUv",
                columns: table => new
                {
                    IDSesiones = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IDCliente = table.Column<int>(type: "int", nullable: true),
                    PaqueteSesionesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SesionesRayosUv", x => x.IDSesiones);
                    table.ForeignKey(
                        name: "FK_SesionesRayosUv_Cliente",
                        column: x => x.IDCliente,
                        principalTable: "Cliente",
                        principalColumn: "IDCliente");
                    table.ForeignKey(
                        name: "FK_SesionesRayosUv_PaquteSesiones",
                        column: x => x.PaqueteSesionesID,
                        principalTable: "PaquteSesiones",
                        principalColumn: "PaqueteSesioensId");
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IDProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCategoriaProducto = table.Column<int>(type: "int", nullable: false),
                    IDProveedores = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CantidadUnidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Existentes = table.Column<int>(type: "int", nullable: false),
                    Espera = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IDProducto);
                    table.ForeignKey(
                        name: "FK_Producto_CategoriaProducto",
                        column: x => x.IDCategoriaProducto,
                        principalTable: "CategoriaProducto",
                        principalColumn: "IDCategoriaProducto");
                    table.ForeignKey(
                        name: "FK_Producto_Proveedor",
                        column: x => x.IDProveedores,
                        principalTable: "Proveedor",
                        principalColumn: "IDProveedores");
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    IDEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDPuesto = table.Column<int>(type: "int", nullable: false),
                    CuentaBancaria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroSeguroSocial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RetencionCCSS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaContratacion = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.IDEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleado_Puesto",
                        column: x => x.IDPuesto,
                        principalTable: "Puesto",
                        principalColumn: "IDPuesto");
                });

            migrationBuilder.CreateTable(
                name: "ClienteSesiones",
                columns: table => new
                {
                    IDClienteSesiones = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSesiones = table.Column<int>(type: "int", nullable: false),
                    FechaCita = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteSesiones", x => x.IDClienteSesiones);
                    table.ForeignKey(
                        name: "FK_ClienteSesiones_SesionesRayosUv",
                        column: x => x.IDSesiones,
                        principalTable: "SesionesRayosUv",
                        principalColumn: "IDSesiones");
                });

            migrationBuilder.CreateTable(
                name: "Clase",
                columns: table => new
                {
                    IDClase = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEmpleado = table.Column<int>(type: "int", nullable: false),
                    IDActividad = table.Column<int>(type: "int", nullable: false),
                    IDSala = table.Column<int>(type: "int", nullable: false),
                    DiayHora = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    HoraFin = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clase", x => x.IDClase);
                    table.ForeignKey(
                        name: "FK_Clase_Actividad",
                        column: x => x.IDActividad,
                        principalTable: "Actividad",
                        principalColumn: "IDActividad");
                    table.ForeignKey(
                        name: "FK_Clase_Empleado",
                        column: x => x.IDEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "IDEmpleado");
                    table.ForeignKey(
                        name: "FK_Clase_Sala",
                        column: x => x.IDSala,
                        principalTable: "Sala",
                        principalColumn: "IDSala");
                });

            migrationBuilder.CreateTable(
                name: "Jornada",
                columns: table => new
                {
                    IDJornada = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEmpleado = table.Column<int>(type: "int", nullable: false),
                    DiaHoraEntrada = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    DiaHoraSalida = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    HorasTrabajadas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalarioBruto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jornada", x => x.IDJornada);
                    table.ForeignKey(
                        name: "FK_Jornada_Empleado",
                        column: x => x.IDEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "IDEmpleado");
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    IDPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEmpleado = table.Column<int>(type: "int", nullable: false),
                    FechaPedido = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaEntregaAprox = table.Column<DateOnly>(type: "date", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.IDPedido);
                    table.ForeignKey(
                        name: "FK_Pedido_Empleado",
                        column: x => x.IDEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "IDEmpleado");
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    IDVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEmpleado = table.Column<int>(type: "int", nullable: false),
                    IDProducto = table.Column<int>(type: "int", nullable: false),
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Pago = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.IDVenta);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente",
                        column: x => x.IDCliente,
                        principalTable: "Cliente",
                        principalColumn: "IDCliente");
                    table.ForeignKey(
                        name: "FK_Venta_Empleado",
                        column: x => x.IDEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "IDEmpleado");
                    table.ForeignKey(
                        name: "FK_Venta_Producto",
                        column: x => x.IDProducto,
                        principalTable: "Producto",
                        principalColumn: "IDProducto");
                });

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    IDMartricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    IDClase = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.IDMartricula);
                    table.ForeignKey(
                        name: "FK_Matricula_Clase",
                        column: x => x.IDClase,
                        principalTable: "Clase",
                        principalColumn: "IDClase");
                    table.ForeignKey(
                        name: "FK_Matricula_Cliente",
                        column: x => x.IDCliente,
                        principalTable: "Cliente",
                        principalColumn: "IDCliente");
                });

            migrationBuilder.CreateTable(
                name: "HistorialPago",
                columns: table => new
                {
                    IDHistorialPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IDJornada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialPago", x => x.IDHistorialPago);
                    table.ForeignKey(
                        name: "FK_HistorialPago_Jornada",
                        column: x => x.IDJornada,
                        principalTable: "Jornada",
                        principalColumn: "IDJornada");
                });

            migrationBuilder.CreateTable(
                name: "DetallePedido",
                columns: table => new
                {
                    IDDetalleProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPedido = table.Column<int>(type: "int", nullable: false),
                    IDProducto = table.Column<int>(type: "int", nullable: false),
                    PrecioUnidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleProducto", x => x.IDDetalleProducto);
                    table.ForeignKey(
                        name: "FK_DetalleProducto_Pedido",
                        column: x => x.IDPedido,
                        principalTable: "Pedido",
                        principalColumn: "IDPedido");
                    table.ForeignKey(
                        name: "FK_DetalleProducto_Producto",
                        column: x => x.IDProducto,
                        principalTable: "Producto",
                        principalColumn: "IDProducto");
                });

            migrationBuilder.CreateTable(
                name: "FacturaPedido",
                columns: table => new
                {
                    IDFacturaPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDProveedor = table.Column<int>(type: "int", nullable: false),
                    IDProducto = table.Column<int>(type: "int", nullable: false),
                    IDPedido = table.Column<int>(type: "int", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime", nullable: false),
                    IVA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaPedido", x => x.IDFacturaPedido);
                    table.ForeignKey(
                        name: "FK_FacturaPedido_Pedido",
                        column: x => x.IDPedido,
                        principalTable: "Pedido",
                        principalColumn: "IDPedido");
                    table.ForeignKey(
                        name: "FK_FacturaPedido_Producto",
                        column: x => x.IDProducto,
                        principalTable: "Producto",
                        principalColumn: "IDProducto");
                    table.ForeignKey(
                        name: "FK_FacturaPedido_Proveedor",
                        column: x => x.IDProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "IDProveedores");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clase_IDActividad",
                table: "Clase",
                column: "IDActividad");

            migrationBuilder.CreateIndex(
                name: "IX_Clase_IDEmpleado",
                table: "Clase",
                column: "IDEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Clase_IDSala",
                table: "Clase",
                column: "IDSala");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteMembresia_IDCategoriaMembresia",
                table: "ClienteMembresia",
                column: "IDCategoriaMembresia");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteMembresia_IDCliente",
                table: "ClienteMembresia",
                column: "IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteSesiones_IDSesiones",
                table: "ClienteSesiones",
                column: "IDSesiones");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_IDPedido",
                table: "DetallePedido",
                column: "IDPedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_IDProducto",
                table: "DetallePedido",
                column: "IDProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IDPuesto",
                table: "Empleado",
                column: "IDPuesto");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaPedido_IDPedido",
                table: "FacturaPedido",
                column: "IDPedido");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaPedido_IDProducto",
                table: "FacturaPedido",
                column: "IDProducto");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaPedido_IDProveedor",
                table: "FacturaPedido",
                column: "IDProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialPago_IDJornada",
                table: "HistorialPago",
                column: "IDJornada");

            migrationBuilder.CreateIndex(
                name: "IX_Jornada_IDEmpleado",
                table: "Jornada",
                column: "IDEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_IDClase",
                table: "Matricula",
                column: "IDClase");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_IDCliente",
                table: "Matricula",
                column: "IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IDEmpleado",
                table: "Pedido",
                column: "IDEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IDCategoriaProducto",
                table: "Producto",
                column: "IDCategoriaProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IDProveedores",
                table: "Producto",
                column: "IDProveedores");

            migrationBuilder.CreateIndex(
                name: "IX_Puesto_IDDepartamento",
                table: "Puesto",
                column: "IDDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_SesionesRayosUv_IDCliente",
                table: "SesionesRayosUv",
                column: "IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_SesionesRayosUv_PaqueteSesionesID",
                table: "SesionesRayosUv",
                column: "PaqueteSesionesID");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IDCliente",
                table: "Venta",
                column: "IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IDEmpleado",
                table: "Venta",
                column: "IDEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IDProducto",
                table: "Venta",
                column: "IDProducto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteMembresia");

            migrationBuilder.DropTable(
                name: "ClienteSesiones");

            migrationBuilder.DropTable(
                name: "DetallePedido");

            migrationBuilder.DropTable(
                name: "FacturaPedido");

            migrationBuilder.DropTable(
                name: "HistorialPago");

            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "CategoriaMembresia");

            migrationBuilder.DropTable(
                name: "SesionesRayosUv");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Jornada");

            migrationBuilder.DropTable(
                name: "Clase");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "PaquteSesiones");

            migrationBuilder.DropTable(
                name: "Actividad");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "CategoriaProducto");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Puesto");

            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}
