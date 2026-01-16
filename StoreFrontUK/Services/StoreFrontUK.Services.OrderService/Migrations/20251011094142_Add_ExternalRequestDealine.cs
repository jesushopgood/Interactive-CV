using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreFrontUK.Migrations
{
    /// <inheritdoc />
    public partial class Add_ExternalRequestDealine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExternalRequestDeadline",
                table: "Orders",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalRequestDeadline",
                table: "Orders");
        }
    }
}
