using Microsoft.EntityFrameworkCore.Migrations;

namespace CCA.Data.Migrations
{
    public partial class removedSomeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Steps",
                table: "Enrollments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Steps",
                table: "Enrollments",
                nullable: false,
                defaultValue: 0);
        }
    }
}
