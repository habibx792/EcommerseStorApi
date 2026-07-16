using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerApi.Migrations
{
    /// <inheritdoc />
    public partial class addRemoveorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_ShipmentRiderId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShipmentRiderId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShipmentRiderId1",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShipmentRiderId1",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipmentRiderId1",
                table: "Orders",
                column: "ShipmentRiderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_ShipmentRiderId1",
                table: "Orders",
                column: "ShipmentRiderId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
