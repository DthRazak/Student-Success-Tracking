using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Persistence.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lectors",
                columns: new[] { "Id", "AcademicStatus", "FirstName", "LastName", "UserRef" },
                values: new object[,]
                {
                    { 1, "Доцент", "Анатолій", "Музичук", null },
                    { 2, "Асистент", "Андрій", "Глова", null },
                    { 3, "Професор", "Юрій", "Щербина", null },
                    { 4, "Доцент", "Віталій", "Горлач", null },
                    { 5, "Асистент", "Любомир", "Галамага", null }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "Group", "LastName", "UserRef" },
                values: new object[,]
                {
                    { 1, "Володимир", "ПМІ-32", "Мільчановський", null },
                    { 2, "Марта", "ПМІ-32", "Шуяк", null },
                    { 3, "Оксана", "ПМІ-32", "Пилипович", null },
                    { 4, "Доскач", "ПМІ-31", "Денис", null },
                    { 5, "Левкович", "ПМІ-33", "Роман", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "IsAdmin", "PasswordHash" },
                values: new object[] { "admin@email.com", true, "Yh+CEuxWzPTw0y2M9zgFEw1stxAwoa1mvyaoI2157nY=" });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "CreationDate", "IsApproved", "UserRef" },
                values: new object[] { 1, new DateTime(2020, 3, 20, 10, 53, 37, 855, DateTimeKind.Local).AddTicks(4391), true, "admin@email.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lectors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lectors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lectors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lectors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lectors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "admin@email.com");
        }
    }
}
