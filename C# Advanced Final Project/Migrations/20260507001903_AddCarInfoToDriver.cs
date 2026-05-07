using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C__Advanced_Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddCarInfoToDriver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarColor",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CarMake",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CarModel",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverID",
                keyValue: 1,
                columns: new[] { "CarColor", "CarMake", "CarModel" },
                values: new object[] { "", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarColor",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CarMake",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CarModel",
                table: "Drivers");
        }
    }
}
