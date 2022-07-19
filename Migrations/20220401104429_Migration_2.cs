using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenSourceEntitys.Migrations
{
    public partial class Migration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DomainId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DomainId",
                table: "AspNetUsers",
                column: "DomainId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Domain_DomainId",
                table: "AspNetUsers",
                column: "DomainId",
                principalTable: "Domain",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Domain_DomainId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Domain");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DomainId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DomainId",
                table: "AspNetUsers");
        }
    }
}
