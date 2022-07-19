using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenSourceEntitys.Migrations
{
    public partial class Migrations_11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ConsentProvisionPersonalData",
                table: "AspNetUsers",
                type: "bit",
                maxLength: 1,
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsentProvisionPersonalData",
                table: "AspNetUsers");
        }
    }
}
