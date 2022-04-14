using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetPetRejestration.Data.Migrations
{
    public partial class DatabaseCorrection2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Pets",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Pets");
        }
    }
}
