using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GL.GestionVentas.Repositories.Migrations
{
    public partial class TABLE_estado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Ventas",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "CarritoProducto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstadoId);
                });

            migrationBuilder.UpdateData(
                table: "CarritoProducto",
                keyColumn: "CarritoProductoId",
                keyValue: 1,
                column: "Cantidad",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CarritoProducto",
                keyColumn: "CarritoProductoId",
                keyValue: 2,
                column: "Cantidad",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CarritoProducto",
                keyColumn: "CarritoProductoId",
                keyValue: 3,
                column: "Cantidad",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CarritoProducto",
                keyColumn: "CarritoProductoId",
                keyValue: 4,
                column: "Cantidad",
                value: 1);

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "EstadoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Cancelado" }
                });

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentasId",
                keyValue: 1,
                columns: new[] { "EstadoId", "Fecha" },
                values: new object[] { 1, new DateTime(2020, 7, 30, 20, 8, 28, 960, DateTimeKind.Local).AddTicks(3850) });

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentasId",
                keyValue: 2,
                columns: new[] { "EstadoId", "Fecha" },
                values: new object[] { 1, new DateTime(2020, 7, 30, 20, 8, 28, 962, DateTimeKind.Local).AddTicks(2144) });

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentasId",
                keyValue: 3,
                columns: new[] { "EstadoId", "Fecha" },
                values: new object[] { 1, new DateTime(2020, 7, 30, 20, 8, 28, 962, DateTimeKind.Local).AddTicks(2223) });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_EstadoId",
                table: "Ventas",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Estado_EstadoId",
                table: "Ventas",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "EstadoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Estado_EstadoId",
                table: "Ventas");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_EstadoId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "CarritoProducto");

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentasId",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2020, 6, 12, 23, 26, 58, 438, DateTimeKind.Local).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentasId",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2020, 6, 12, 23, 26, 58, 441, DateTimeKind.Local).AddTicks(479));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentasId",
                keyValue: 3,
                column: "Fecha",
                value: new DateTime(2020, 6, 12, 23, 26, 58, 441, DateTimeKind.Local).AddTicks(606));
        }
    }
}
