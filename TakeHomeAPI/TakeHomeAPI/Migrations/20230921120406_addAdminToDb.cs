using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeHomeAPI.Migrations
{
    public partial class addAdminToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Role", "Token", "UserName" },
                values: new object[] { 2, "admin@gmail.com", "Admin", "Something", "123", "admin", "1", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
