using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C__Advanced_Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class UserDriver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                    name: "DriverUser",
                    table: "Drivers",
                    type: "User",
                    nullable: true,
                    defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
