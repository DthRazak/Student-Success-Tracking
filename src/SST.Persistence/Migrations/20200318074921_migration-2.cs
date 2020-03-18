using Microsoft.EntityFrameworkCore.Migrations;

namespace SST.Persistence.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectors_Users_UserRef",
                table: "Lectors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserRef",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectors_Users_UserRef",
                table: "Lectors",
                column: "UserRef",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserRef",
                table: "Students",
                column: "UserRef",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectors_Users_UserRef",
                table: "Lectors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserRef",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectors_Users_UserRef",
                table: "Lectors",
                column: "UserRef",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserRef",
                table: "Students",
                column: "UserRef",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
