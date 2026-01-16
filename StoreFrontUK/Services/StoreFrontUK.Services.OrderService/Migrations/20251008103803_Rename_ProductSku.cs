using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreFrontUK.Migrations
{
    /// <inheritdoc />
    public partial class Rename_ProductSku : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductSku",
                table: "OrderItems",
                newName: "Sku");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sku",
                table: "OrderItems",
                newName: "ProductSku");
        }
    }
}
