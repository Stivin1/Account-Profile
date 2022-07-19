using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenSourceEntitys.Migrations
{
    public partial class Migrations_18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoggingInformations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoggingInformations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Loggings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateCreate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LoggingInformationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loggings", x => x.id);
                    table.ForeignKey(
                        name: "FK_Loggings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loggings_LoggingInformations_LoggingInformationId",
                        column: x => x.LoggingInformationId,
                        principalTable: "LoggingInformations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loggings_LoggingInformationId",
                table: "Loggings",
                column: "LoggingInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loggings_UserId",
                table: "Loggings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loggings");

            migrationBuilder.DropTable(
                name: "LoggingInformations");
        }
    }
}
