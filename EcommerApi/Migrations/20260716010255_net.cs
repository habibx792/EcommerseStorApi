using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerApi.Migrations
{
    /// <inheritdoc />
    public partial class net : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderShipRider",
                columns: table => new
                {
                    ShipmentRiderId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderShipRider", x => new { x.ShipmentRiderId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderShipRider_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderShipRider_Users_ShipmentRiderId",
                        column: x => x.ShipmentRiderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderShipRider_OrderId",
                table: "OrderShipRider",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderShipRider");
        }
    }
}
