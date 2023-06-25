using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAW.API.Migrations
{
    public partial class job_salary_range : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salary_range",
                table: "offers");

            migrationBuilder.AddColumn<decimal>(
                name: "max_salary",
                table: "offers",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "min_salary",
                table: "offers",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "max_salary",
                table: "offers");

            migrationBuilder.DropColumn(
                name: "min_salary",
                table: "offers");

            migrationBuilder.AddColumn<string>(
                name: "salary_range",
                table: "offers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
