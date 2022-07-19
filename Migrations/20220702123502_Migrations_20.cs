using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenSourceEntitys.Migrations
{
    public partial class Migrations_20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "LoggingInformations",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LoggingInformations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LoggingInformations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "LoggingInformations",
                columns: new[] { "id", "Name" },
                values: new object[,]
                {
                    { 1, "Попытка входа пользователя" },
                    { 29, "Отправка сообщения" },
                    { 28, "Добавление документа " },
                    { 27, "Удаление роли пользователем " },
                    { 26, "Добавление роли пользователю " },
                    { 25, "Добавление роли пользователем " },
                    { 24, "Удаление группы пользователя" },
                    { 23, "Добавление группы пользователю" },
                    { 22, "Добавление группы пользователем" },
                    { 21, "Изменение данных пароля" },
                    { 20, "Изменение данных пользователя" },
                    { 19, "Изменение данных профиля" },
                    { 18, "Получение данных страницы активности аккаунта" },
                    { 17, "Получение данных страницы удаленных сообщений" },
                    { 30, "Получение данных формы просмотра сообщений" },
                    { 16, "Получение данных страницы отправки" },
                    { 14, "Получение данных страницы корзины документов" },
                    { 13, "Получение данных страницы мои документы" },
                    { 12, "Получение данных страницы добавления роли пользователю" },
                    { 11, "Получение данных страницы добавления роли" },
                    { 10, "Получение данных страницы добавления группы пользователю" },
                    { 9, "Получение данных страницы добавления группы" },
                    { 8, "Получение данных страницы списка групп" },
                    { 7, "Получение данных страницы изменить пароль" },
                    { 6, "Получение данных страницы изменения пользователя" },
                    { 5, "Получение данных страницы изменения профиля" },
                    { 4, "Получение данных страницы пользователей" },
                    { 3, "Получение данных страницы профиля" },
                    { 2, "Выход пользователя" },
                    { 15, "Получение данных страницы почты" },
                    { 31, "Получение данных формы чтения сообщения" }
                });
        }
    }
}
