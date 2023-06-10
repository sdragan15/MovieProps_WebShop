using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieProps.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Update_OrderShipping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingTime",
                table: "Orders",
                newName: "Ordered");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Orders",
                newName: "Delivered");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ordered",
                table: "Orders",
                newName: "ShippingTime");

            migrationBuilder.RenameColumn(
                name: "Delivered",
                table: "Orders",
                newName: "Created");
        }
    }
}
