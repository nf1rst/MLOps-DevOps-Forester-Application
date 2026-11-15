using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forester.DAL.Migrations
{
    /// <inheritdoc />
    public partial class LogUserUsernameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Log");

            migrationBuilder.AddColumn<string>(
                name: "UserUsername",
                table: "Log",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserUsername",
                table: "Log");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Log",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
