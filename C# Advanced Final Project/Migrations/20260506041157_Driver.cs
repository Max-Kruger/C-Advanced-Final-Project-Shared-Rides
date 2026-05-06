using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C__Advanced_Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class Driver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_AspNetUsers_DriverUserId",
                table: "Drivers");

            migrationBuilder.AlterColumn<string>(
                name: "DriverUserId",
                table: "Drivers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverID", "AttendingEventId", "DriverUserId", "MaxCapacity", "remainingPassengers" },
                values: new object[] { 1, 1, "static-user-id-1", 4, 4 });

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_AspNetUsers_DriverUserId",
                table: "Drivers",
                column: "DriverUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_AspNetUsers_DriverUserId",
                table: "Drivers");

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverID",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "DriverUserId",
                table: "Drivers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_AspNetUsers_DriverUserId",
                table: "Drivers",
                column: "DriverUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
