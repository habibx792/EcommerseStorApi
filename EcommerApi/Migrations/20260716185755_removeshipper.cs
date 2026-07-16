using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerApi.Migrations
{
    /// <inheritdoc />
    public partial class removeshipper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_ShipmentRiderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShipmentRiderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipmentRiderId",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShipmentRiderId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipmentRiderId",
                table: "Orders",
                column: "ShipmentRiderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_ShipmentRiderId",
                table: "Orders",
                column: "ShipmentRiderId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
