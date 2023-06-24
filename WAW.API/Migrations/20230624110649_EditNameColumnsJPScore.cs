using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAW.API.Migrations
{
    public partial class EditNameColumnsJPScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

          

            

            migrationBuilder.RenameColumn(
                name: "it_professional_id",
                table: "job_post_scores",
                newName: "user_id");

            
            migrationBuilder.CreateIndex(
                name: "i_x_job_post_scores_user_id",
                table: "job_post_scores",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "f_k_job_post_scores_users_user_id",
                table: "job_post_scores",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_job_post_scores_users_user_id",
                table: "job_post_scores");

            migrationBuilder.DropIndex(
                name: "i_x_job_post_scores_job_offer_id",
                table: "job_post_scores");

            migrationBuilder.DropIndex(
                name: "i_x_job_post_scores_user_id",
                table: "job_post_scores");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "job_post_scores",
                newName: "it_professional_id");

            
        }
    }
}
