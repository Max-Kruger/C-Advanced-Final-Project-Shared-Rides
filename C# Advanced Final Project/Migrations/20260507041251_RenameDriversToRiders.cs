using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C__Advanced_Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class RenameDriversToRiders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Drivers",
                table: "Events",
                newName: "Riders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Riders",
                table: "Events",
                newName: "Drivers");
        }
    }
}
