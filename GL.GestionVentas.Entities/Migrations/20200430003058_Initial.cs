using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GL.GestionVentas.Entities.Migrations
{
    public partial class Initial : Migration
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
                name: "Ventas",
                columns: table => new
                {
                    VentasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentasId);
                    table.ForeignKey(
                        name: "FK_Ventas_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
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
                table: "Ventas",
                columns: new[] { "VentasId", "ClienteId", "Fecha", "ProductoId" },
                values: new object[] { 1, 1, new DateTime(2020, 4, 29, 21, 30, 57, 272, DateTimeKind.Local).AddTicks(250), 1 });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "VentasId", "ClienteId", "Fecha", "ProductoId" },
                values: new object[] { 2, 1, new DateTime(2020, 4, 29, 21, 30, 57, 273, DateTimeKind.Local).AddTicks(7009), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Codigo",
                table: "Producto",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ProductoId",
                table: "Ventas",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
