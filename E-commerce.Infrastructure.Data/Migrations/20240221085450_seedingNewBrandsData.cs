using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerce.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedingNewBrandsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "productBrands",
                columns: new[] { "ProductBrandId", "ProductBrandName" },
                values: new object[,]
                {
                    { 1, "Zara" },
                    { 2, "Gucci" },
                    { 3, "Nike" },
                    { 4, "H&M" },
                    { 5, "Forever21" },
                    { 6, "Adidas" },
                    { 7, "Chanel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "productBrands",
                keyColumn: "ProductBrandId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "productBrands",
                keyColumn: "ProductBrandId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "productBrands",
                keyColumn: "ProductBrandId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "productBrands",
                keyColumn: "ProductBrandId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "productBrands",
                keyColumn: "ProductBrandId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "productBrands",
                keyColumn: "ProductBrandId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "productBrands",
                keyColumn: "ProductBrandId",
                keyValue: 7);
        }
    }
}
