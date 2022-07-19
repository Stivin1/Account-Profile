using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenSourceEntitys.Migrations
{
    public partial class Migrations_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "addresSents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_addresSents_UserId",
                table: "addresSents",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_addresSents_AspNetUsers_UserId",
                table: "addresSents",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_addresSents_AspNetUsers_UserId",
                table: "addresSents");

            migrationBuilder.DropIndex(
                name: "IX_addresSents_UserId",
                table: "addresSents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "addresSents");
        }
    }
}
