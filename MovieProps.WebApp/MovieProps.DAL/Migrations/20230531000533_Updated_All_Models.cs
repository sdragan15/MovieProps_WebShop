using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieProps.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Updated_All_Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerItems_Items_ItemId",
                table: "BuyerItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BuyerItems_Users_UserId",
                table: "BuyerItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerItems_Items_ItemId",
                table: "SellerItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerItems_Users_UserId",
                table: "SellerItems");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_SellerItems_ItemId",
                table: "SellerItems");

            migrationBuilder.DropIndex(
                name: "IX_SellerItems_UserId",
                table: "SellerItems");

            migrationBuilder.DropIndex(
                name: "IX_BuyerItems_ItemId",
                table: "BuyerItems");

            migrationBuilder.DropIndex(
                name: "IX_BuyerItems_UserId",
                table: "BuyerItems");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SellerItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "SellerItems",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "SellerItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BuyerItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "BuyerItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId",
                unique: true,
                filter: "[RoleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SellerItems_ItemId",
                table: "SellerItems",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SellerItems_UserId",
                table: "SellerItems",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuyerItems_ItemId",
                table: "BuyerItems",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuyerItems_UserId",
                table: "BuyerItems",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerItems_Items_ItemId",
                table: "BuyerItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerItems_Users_UserId",
                table: "BuyerItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellerItems_Items_ItemId",
                table: "SellerItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellerItems_Users_UserId",
                table: "SellerItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerItems_Items_ItemId",
                table: "BuyerItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BuyerItems_Users_UserId",
                table: "BuyerItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerItems_Items_ItemId",
                table: "SellerItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerItems_Users_UserId",
                table: "SellerItems");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_SellerItems_ItemId",
                table: "SellerItems");

            migrationBuilder.DropIndex(
                name: "IX_SellerItems_UserId",
                table: "SellerItems");

            migrationBuilder.DropIndex(
                name: "IX_BuyerItems_ItemId",
                table: "BuyerItems");

            migrationBuilder.DropIndex(
                name: "IX_BuyerItems_UserId",
                table: "BuyerItems");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SellerItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "SellerItems",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "SellerItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BuyerItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "BuyerItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerItems_ItemId",
                table: "SellerItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerItems_UserId",
                table: "SellerItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerItems_ItemId",
                table: "BuyerItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerItems_UserId",
                table: "BuyerItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerItems_Items_ItemId",
                table: "BuyerItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerItems_Users_UserId",
                table: "BuyerItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SellerItems_Items_ItemId",
                table: "SellerItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SellerItems_Users_UserId",
                table: "SellerItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
