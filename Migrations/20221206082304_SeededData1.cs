using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBulletin.Migrations
{
    /// <inheritdoc />
    public partial class SeededData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Name" },
                values: new object[] { 1, "General" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "IsAdmin", "Name" },
                values: new object[] { 1, true, "Micke" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
