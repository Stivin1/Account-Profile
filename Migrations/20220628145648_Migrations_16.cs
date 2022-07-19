using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenSourceEntitys.Migrations
{
    public partial class Migrations_16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageSettings_Messages_Messageid",
                table: "MessageSettings");

            migrationBuilder.DropIndex(
                name: "IX_MessageSettings_Messageid",
                table: "MessageSettings");

            migrationBuilder.RenameColumn(
                name: "Messageid",
                table: "MessageSettings",
                newName: "MessageId");

            migrationBuilder.AlterColumn<int>(
                name: "MessageId",
                table: "MessageSettings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageSettings_MessageId",
                table: "MessageSettings",
                column: "MessageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageSettings_Messages_MessageId",
                table: "MessageSettings",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageSettings_Messages_MessageId",
                table: "MessageSettings");

            migrationBuilder.DropIndex(
                name: "IX_MessageSettings_MessageId",
                table: "MessageSettings");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "MessageSettings",
                newName: "Messageid");

            migrationBuilder.AlterColumn<int>(
                name: "Messageid",
                table: "MessageSettings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_MessageSettings_Messageid",
                table: "MessageSettings",
                column: "Messageid");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageSettings_Messages_Messageid",
                table: "MessageSettings",
                column: "Messageid",
                principalTable: "Messages",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
