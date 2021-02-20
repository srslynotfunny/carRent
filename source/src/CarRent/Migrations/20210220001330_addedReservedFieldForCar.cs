using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent.Migrations
{
    public partial class addedReservedFieldForCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarClass",
                table: "Reservations",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<bool>(
                name: "Reserved",
                table: "Cars",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarClass",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Reserved",
                table: "Cars");
        }
    }
}
