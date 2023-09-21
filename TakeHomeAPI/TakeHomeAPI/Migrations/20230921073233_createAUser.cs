using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeHomeAPI.Migrations
{
    public partial class createAUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Role", "Token", "UserName" },
                values: new object[] { 1, "janith0000@gmail.com", "Janith", "Udayanga", "123", "user", "1", "janith" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
