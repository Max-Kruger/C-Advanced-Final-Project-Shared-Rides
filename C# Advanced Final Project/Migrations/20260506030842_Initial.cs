using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C__Advanced_Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Events_AttendingEventEventID",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_AttendingEventEventID",
                table: "Guests");

            migrationBuilder.RenameColumn(
                name: "AttendingEventEventID",
                table: "Guests",
                newName: "AttendingEventId");

            migrationBuilder.RenameColumn(
                name: "CurrentPassengers",
                table: "Drivers",
                newName: "remainingPassengers");

            migrationBuilder.AddColumn<int>(
                name: "AttendingEventId",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttendingEventId",
                table: "Drivers");

            migrationBuilder.RenameColumn(
                name: "AttendingEventId",
                table: "Guests",
                newName: "AttendingEventEventID");

            migrationBuilder.RenameColumn(
                name: "remainingPassengers",
                table: "Drivers",
                newName: "CurrentPassengers");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_AttendingEventEventID",
                table: "Guests",
                column: "AttendingEventEventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Events_AttendingEventEventID",
                table: "Guests",
                column: "AttendingEventEventID",
                principalTable: "Events",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
