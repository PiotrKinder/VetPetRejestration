using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetPetRejestration.Data.Migrations
{
    public partial class databaseChanges9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Pets_PetId",
                table: "MedicalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_UserId1",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_UserId1",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Pets");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Pets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "MedicalHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserId",
                table: "Pets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Pets_PetId",
                table: "MedicalHistories",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_UserId",
                table: "Pets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Pets_PetId",
                table: "MedicalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_UserId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_UserId",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Pets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "MedicalHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserId1",
                table: "Pets",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Pets_PetId",
                table: "MedicalHistories",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_UserId1",
                table: "Pets",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
