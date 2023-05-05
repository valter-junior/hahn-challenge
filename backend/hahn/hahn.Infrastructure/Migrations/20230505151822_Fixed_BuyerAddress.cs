using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hahn.Infrastructure.Migrations
{
    public partial class Fixed_BuyerAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerAddress_AspNetUsers_BuyerId",
                table: "BuyerAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BuyerAddress_BuyerAddressId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuyerAddress",
                table: "BuyerAddress");

            migrationBuilder.RenameTable(
                name: "BuyerAddress",
                newName: "BuyerAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_BuyerAddress_BuyerId",
                table: "BuyerAddresses",
                newName: "IX_BuyerAddresses_BuyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuyerAddresses",
                table: "BuyerAddresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerAddresses_AspNetUsers_BuyerId",
                table: "BuyerAddresses",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BuyerAddresses_BuyerAddressId",
                table: "Orders",
                column: "BuyerAddressId",
                principalTable: "BuyerAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerAddresses_AspNetUsers_BuyerId",
                table: "BuyerAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BuyerAddresses_BuyerAddressId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuyerAddresses",
                table: "BuyerAddresses");

            migrationBuilder.RenameTable(
                name: "BuyerAddresses",
                newName: "BuyerAddress");

            migrationBuilder.RenameIndex(
                name: "IX_BuyerAddresses_BuyerId",
                table: "BuyerAddress",
                newName: "IX_BuyerAddress_BuyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuyerAddress",
                table: "BuyerAddress",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerAddress_AspNetUsers_BuyerId",
                table: "BuyerAddress",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BuyerAddress_BuyerAddressId",
                table: "Orders",
                column: "BuyerAddressId",
                principalTable: "BuyerAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
