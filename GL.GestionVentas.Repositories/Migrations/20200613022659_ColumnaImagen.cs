using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GL.GestionVentas.Repositories.Migrations
{
    public partial class ColumnaImagen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Producto",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 1,
                column: "Imagen",
                value: "https://www.xt-pc.com.ar/img/productos/Pics_Prod/MOU606.jpg");

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 2,
                column: "Imagen",
                value: "https://arsonyb2c.vteximg.com.br/arquivos/ids/292526-1000-1000/ILCE-7K_Black-0.jpg?v=637124363789970000");

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 3,
                column: "Imagen",
                value: "https://http2.mlstatic.com/teclado-usb-ergonomico-pc-notebook-oficina-qwerty-espanol-garantia-oficial-D_NQ_NP_626103-MLA31936565669_082019-F.jpg");

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 4,
                column: "Imagen",
                value: "https://images.samsung.com/is/image/samsung/uk-led-sf350-ls24f350fhuxen-001-front-black?$PD_GALLERY_L_JPG$");

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 5,
                column: "Imagen",
                value: "https://vignette2.wikia.nocookie.net/applezone/images/6/67/CPU.jpg/revision/latest?cb=20120318030604&path-prefix=es");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Producto");

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentasId",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2020, 5, 13, 19, 44, 2, 909, DateTimeKind.Local).AddTicks(5061));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentasId",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2020, 5, 13, 19, 44, 2, 912, DateTimeKind.Local).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentasId",
                keyValue: 3,
                column: "Fecha",
                value: new DateTime(2020, 5, 13, 19, 44, 2, 912, DateTimeKind.Local).AddTicks(6174));
        }
    }
}
