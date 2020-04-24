using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Persistence.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Faculty", "IsMain", "Name", "Year" },
                values: new object[,]
                {
                    { 1, "Факультет прикладної математики та інформатики", true, "ПМІ-31", 0 },
                    { 2, "Факультет прикладної математики та інформатики", true, "ПМІ-32", 0 },
                    { 3, "Факультет прикладної математики та інформатики", true, "ПМІ-33", 0 },
                    { 4, "Факультет журналістики", true, "ЖРН-11с", 0 },
                    { 5, "Філософський факультет", true, "ФФП-42с", 0 }
                });

            migrationBuilder.InsertData(
                table: "Lectors",
                columns: new[] { "Id", "AcademicStatus", "FirstName", "LastName", "UserRef" },
                values: new object[,]
                {
                    { 1, "Доцент", "Анатолій", "Музичук", null },
                    { 2, "Асистент", "Андрій", "Глова", null },
                    { 3, "Професор", "Юрій", "Щербина", null },
                    { 4, "Доцент", "Віталій", "Горлач", null },
                    { 5, "Асистент", "Любомир", "Галамага", null },
                    { 6, "Професор", "Софія", "Грабовська", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "IsAdmin", "PasswordHash" },
                values: new object[,]
                {
                    { "admin@email.com", true, "Yh+CEuxWzPTw0y2M9zgFEw1stxAwoa1mvyaoI2157nY=" },
                    { "martashuyak@gmail.com", false, "X1ReXJ0j6yv7TfPCmfQ/pTeniB/AnjIif5c03K1QNEU=" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "CreationDate", "IsApproved", "UserRef" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 4, 24, 9, 12, 17, 572, DateTimeKind.Local).AddTicks(843), true, "admin@email.com" },
                    { 2, new DateTime(2020, 4, 24, 9, 12, 17, 579, DateTimeKind.Local).AddTicks(5952), true, "martashuyak@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "GroupRef", "LastName", "UserRef" },
                values: new object[,]
                {
                    { 4, "Денис", 1, "Доскач", null },
                    { 1, "Володимир", 2, "Мільчановський", null },
                    { 3, "Оксана", 2, "Пилипович", null },
                    { 5, "Роман", 3, "Левкович", null },
                    { 2, "Марта", 2, "Шуяк", "martashuyak@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "LectorRef", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Програмна інженерія" },
                    { 2, 3, "Дискретна математика" },
                    { 4, 3, "Теорія ймовірності та математична статистика" },
                    { 3, 5, "Програмування" },
                    { 5, 6, "Психологія примирення" }
                });

            migrationBuilder.InsertData(
                table: "GroupSubjects",
                columns: new[] { "Id", "GroupRef", "SubjectRef" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 3, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "JournalColumns",
                columns: new[] { "Id", "Date", "GroupSubjectRef", "Note" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 2, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 3, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 4, new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 5, new DateTime(2020, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "JournalColumnRef", "Mark", "StudentRef" },
                values: new object[,]
                {
                    { 4, 1, 14, 2 },
                    { 3, 2, 18, 3 },
                    { 2, 3, 15, 2 },
                    { 1, 4, 20, 1 },
                    { 5, 5, 20, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GroupSubjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GroupSubjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GroupSubjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GroupSubjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lectors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lectors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "JournalColumns",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JournalColumns",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JournalColumns",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JournalColumns",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JournalColumns",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lectors",
                keyColumn: "Id",
                keyValue: 5);

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
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "admin@email.com");

            migrationBuilder.DeleteData(
                table: "GroupSubjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lectors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lectors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "martashuyak@gmail.com");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lectors",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
