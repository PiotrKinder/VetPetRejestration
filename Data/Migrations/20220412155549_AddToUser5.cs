using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetPetRejestration.Data.Migrations
{
    public partial class AddToUser5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_UserId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_UserId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Pets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserId",
                table: "Pets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_UserId",
                table: "Pets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
