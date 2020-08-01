using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GL.GestionVentas.Repositories.Migrations
{
    public partial class VENTAS_preciototal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ventas",
                keyColumn: "VentasId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ventas",
                keyColumn: "VentasId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ventas",
                keyColumn: "VentasId",
                keyValue: 3);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioTotal",
                table: "Ventas",
                type: "decimal(15,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioTotal",
                table: "Ventas");

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "VentasId", "CarritoId", "EstadoId", "Fecha" },
                values: new object[] { 1, 1, 1, new DateTime(2020, 7, 30, 20, 8, 28, 960, DateTimeKind.Local).AddTicks(3850) });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "VentasId", "CarritoId", "EstadoId", "Fecha" },
                values: new object[] { 2, 2, 1, new DateTime(2020, 7, 30, 20, 8, 28, 962, DateTimeKind.Local).AddTicks(2144) });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "VentasId", "CarritoId", "EstadoId", "Fecha" },
                values: new object[] { 3, 3, 1, new DateTime(2020, 7, 30, 20, 8, 28, 962, DateTimeKind.Local).AddTicks(2223) });
        }
    }
}
