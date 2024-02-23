using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerce.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedingNewTypesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "productTypes",
                columns: new[] { "ProductTypeId", "ProductTypeName" },
                values: new object[,]
                {
                    { 1, "Coats" },
                    { 2, "Hats" },
                    { 3, "Boots" },
                    { 4, "Gloves" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "productTypes",
                keyColumn: "ProductTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "productTypes",
                keyColumn: "ProductTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "productTypes",
                keyColumn: "ProductTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "productTypes",
                keyColumn: "ProductTypeId",
                keyValue: 4);
        }
    }
}
