using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GL.GestionVentas.Repositories.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(maxLength: 45, nullable: false),
                    Apellido = table.Column<string>(maxLength: 45, nullable: false),
                    Direccion = table.Column<string>(maxLength: 45, nullable: false),
                    Telefono = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 45, nullable: false),
                    Marca = table.Column<string>(maxLength: 45, nullable: true),
                    Nombre = table.Column<string>(maxLength: 45, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(15,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    CarritoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.CarritoId);
                    table.ForeignKey(
                        name: "FK_Carrito_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarritoProducto",
                columns: table => new
                {
                    CarritoProductoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarritoId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoProducto", x => x.CarritoProductoId);
                    table.ForeignKey(
                        name: "FK_CarritoProducto_Carrito_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carrito",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoProducto_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    CarritoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentasId);
                    table.ForeignKey(
                        name: "FK_Ventas_Carrito_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carrito",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "Apellido", "DNI", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Perez", "30000001", "Calle falsa 123", "Roberto", "12345678" },
                    { 2, "Fulanito", "40000001", "Av. Mitre 123", "Cosme", "12345555" },
                    { 3, "Rodriguez", "50000001", "Calchaqui 3000", "Patricia", "11111111" }
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "ProductoId", "Codigo", "Marca", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "MOU", "Noganet", "Mouse", 10m },
                    { 2, "CAM", null, "Camara", 15m },
                    { 3, "TEC", "Noganet", "Teclado", 20m },
                    { 4, "MON", "Samsung", "Monitor", 38m },
                    { 5, "CPU", "Gigabit", "CPU", 250m }
                });

            migrationBuilder.InsertData(
                table: "Carrito",
                columns: new[] { "CarritoId", "ClienteId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Carrito",
                columns: new[] { "CarritoId", "ClienteId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "Carrito",
                columns: new[] { "CarritoId", "ClienteId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "CarritoProducto",
                columns: new[] { "CarritoProductoId", "CarritoId", "ProductoId" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 1, 4 },
                    { 3, 2, 3 },
                    { 4, 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "VentasId", "CarritoId", "Fecha" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 5, 13, 19, 44, 2, 909, DateTimeKind.Local).AddTicks(5061) },
                    { 2, 2, new DateTime(2020, 5, 13, 19, 44, 2, 912, DateTimeKind.Local).AddTicks(6018) },
                    { 3, 3, new DateTime(2020, 5, 13, 19, 44, 2, 912, DateTimeKind.Local).AddTicks(6174) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_ClienteId",
                table: "Carrito",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProducto_CarritoId",
                table: "CarritoProducto",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProducto_ProductoId",
                table: "CarritoProducto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Codigo",
                table: "Producto",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_CarritoId",
                table: "Ventas",
                column: "CarritoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoProducto");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
