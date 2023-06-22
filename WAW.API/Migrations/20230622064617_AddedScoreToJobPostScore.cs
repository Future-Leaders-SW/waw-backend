using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAW.API.Migrations
{
    public partial class AddedScoreToJobPostScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "score",
                table: "job_post_scores",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "score",
                table: "job_post_scores");
        }
    }
}
