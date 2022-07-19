using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenSourceEntitys.Migrations
{
    public partial class Migrations_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Domain_DomainId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Domain");

            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Domains_DomainId",
                table: "AspNetUsers",
                column: "DomainId",
                principalTable: "Domains",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Domains_DomainId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Domains");

            migrationBuilder.CreateTable(
                name: "Domain",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domain", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Domain_DomainId",
                table: "AspNetUsers",
                column: "DomainId",
                principalTable: "Domain",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
