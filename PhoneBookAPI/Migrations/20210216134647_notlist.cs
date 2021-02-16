using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBookAPI.Migrations
{
    public partial class notlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactTypes_UserID",
                table: "ContactTypes");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypes_UserID",
                table: "ContactTypes",
                column: "UserID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactTypes_UserID",
                table: "ContactTypes");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypes_UserID",
                table: "ContactTypes",
                column: "UserID");
        }
    }
}
