using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forester.DAL.Migrations
{
    /// <inheritdoc />
    public partial class LogTypeRelationToLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LogType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "User Activity" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LogType",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
