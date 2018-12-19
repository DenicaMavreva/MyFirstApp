using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CCA.Data.Migrations
{
    public partial class modelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Professors_ProfessorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_UserId1",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Professors_Students_StudentId",
                table: "Professors");

            migrationBuilder.DropIndex(
                name: "IX_Professors_StudentId",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "Cabinet",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "ProfessionalBachelor",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "Reception",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Courses",
                newName: "CCAUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_UserId1",
                table: "Courses",
                newName: "IX_Courses_CCAUserId");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorId",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_CCAUserId",
                table: "Courses",
                column: "CCAUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Professors_ProfessorId",
                table: "Courses",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_CCAUserId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Professors_ProfessorId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CCAUserId",
                table: "Courses",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CCAUserId",
                table: "Courses",
                newName: "IX_Courses_UserId1");

            migrationBuilder.AddColumn<string>(
                name: "Cabinet",
                table: "Professors",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Professors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProfessionalBachelor",
                table: "Enrollments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Reception",
                table: "Enrollments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorId",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Professors_StudentId",
                table: "Professors",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Professors_ProfessorId",
                table: "Courses",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_UserId1",
                table: "Courses",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_Students_StudentId",
                table: "Professors",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
