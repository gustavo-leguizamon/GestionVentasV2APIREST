using Microsoft.EntityFrameworkCore.Migrations;

namespace GL.GestionVentas.Repositories.Migrations
{
    public partial class PRODUCTO_add_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 1,
                column: "Precio",
                value: 199.99m);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 2,
                column: "Precio",
                value: 1500.00m);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 3,
                column: "Precio",
                value: 2060m);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 4,
                column: "Precio",
                value: 4650.50m);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 5,
                column: "Precio",
                value: 6900m);

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "ProductoId", "Codigo", "Imagen", "Marca", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 6, "AUR", "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQxHQK6bexxEunRDrGWtf-baJVbaFKOeX2cxA&usqp=CAU", "WorldTech", "Auricular", 1299m },
                    { 7, "SIL", "https://images.bidcom.com.ar/resize?src=https://www.bidcom.com.ar/publicacionesML/productos/SILLA14X/1000x1000-SILLA14X.jpg&w=500&q=100", "WorldTech", "Silla gamer", 30999.99m },
                    { 8, "PAR", "https://lh3.googleusercontent.com/proxy/_w0DznoyQ7Bn93pz8t3fY4zETeUWGQYH3ZWeiQkMCCdK7lnkuMuDH093tTDbaOdY1Ozi-hWD7oCRm0u31UBhbeZ2bucbfZGNlgy4", "Kolke", "Parlantes", 299.99m },
                    { 9, "NOT", "https://http2.mlstatic.com/notebook-hp-250-g7-core-i3-7020u-8gb-1tb-156-win10-cta-off-D_NQ_NP_692739-MLA31428906360_072019-O.webp", "Intel", "Notebook", 20099.00m },
                    { 10, "JOY", "https://http2.mlstatic.com/D_NQ_NP_702700-MLA32150735923_092019-O.webp", "Sony", "Joystick", 13999m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 1,
                column: "Precio",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 2,
                column: "Precio",
                value: 15m);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 3,
                column: "Precio",
                value: 20m);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 4,
                column: "Precio",
                value: 38m);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 5,
                column: "Precio",
                value: 250m);
        }
    }
}
