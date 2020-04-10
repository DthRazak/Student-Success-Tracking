using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Persistence.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudentRef",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Subjects_SubjectRef",
                table: "StudentSubjects");

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 4, 10, 16, 7, 50, 827, DateTimeKind.Local).AddTicks(1710));

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "LectorRef", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Програмна інженерія" },
                    { 2, 3, "Дискретна математика" },
                    { 3, 5, "Програмування" },
                    { 4, 3, "Статистика" }
                });

            migrationBuilder.InsertData(
                table: "StudentSubjects",
                columns: new[] { "Id", "StudentRef", "SubjectRef" },
                values: new object[] { 3, 3, 1 });

            migrationBuilder.InsertData(
                table: "StudentSubjects",
                columns: new[] { "Id", "StudentRef", "SubjectRef" },
                values: new object[] { 1, 2, 2 });

            migrationBuilder.InsertData(
                table: "StudentSubjects",
                columns: new[] { "Id", "StudentRef", "SubjectRef" },
                values: new object[] { 2, 1, 3 });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Mark", "StudentSubjectRef" },
                values: new object[,]
                {
                    { 3, 18, 3 },
                    { 5, 20, 3 },
                    { 1, 20, 1 },
                    { 2, 15, 2 },
                    { 4, 14, 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudentRef",
                table: "StudentSubjects",
                column: "StudentRef",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Subjects_SubjectRef",
                table: "StudentSubjects",
                column: "SubjectRef",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudentRef",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Subjects_SubjectRef",
                table: "StudentSubjects");

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
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudentSubjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentSubjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentSubjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2020, 4, 3, 10, 38, 39, 129, DateTimeKind.Local).AddTicks(4168));

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudentRef",
                table: "StudentSubjects",
                column: "StudentRef",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Subjects_SubjectRef",
                table: "StudentSubjects",
                column: "SubjectRef",
                principalTable: "Subjects",
                principalColumn: "Id");
        }
    }
}
