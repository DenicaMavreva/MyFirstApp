using Microsoft.EntityFrameworkCore.Migrations;

namespace CCA.Data.Migrations
{
    public partial class modelsdeletedAndUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FacultyNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Bachelor",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "Doctor",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "Master",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "QualificationDegrees",
                table: "Students",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "Steps",
                table: "Enrollments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Steps",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Students",
                newName: "QualificationDegrees");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FacultyNumber",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Bachelor",
                table: "Enrollments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doctor",
                table: "Enrollments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Master",
                table: "Enrollments",
                nullable: true);
        }
    }
}
