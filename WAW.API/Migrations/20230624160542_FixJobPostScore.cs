using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAW.API.Migrations
{
    public partial class FixJobPostScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_job_post_scores_it_professionals_it_professional_id",
                table: "job_post_scores");

            migrationBuilder.DropForeignKey(
                name: "f_k_job_post_scores_offers_job_offer_id",
                table: "job_post_scores");

            migrationBuilder.DropIndex(
                name: "i_x_job_post_scores_it_professional_id",
                table: "job_post_scores");

            migrationBuilder.DropIndex(
                name: "i_x_job_post_scores_job_offer_id",
                table: "job_post_scores");

            migrationBuilder.RenameColumn(
                name: "job_offer_id",
                table: "job_post_scores",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "it_professional_id",
                table: "job_post_scores",
                newName: "offer_id");

            migrationBuilder.CreateIndex(
                name: "i_x_job_post_scores_offer_id",
                table: "job_post_scores",
                column: "offer_id");

            migrationBuilder.CreateIndex(
                name: "i_x_job_post_scores_user_id",
                table: "job_post_scores",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "f_k_job_post_scores_offers_offer_id",
                table: "job_post_scores",
                column: "offer_id",
                principalTable: "offers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "f_k_job_post_scores_offers_offer_id",
                table: "job_post_scores");

            migrationBuilder.DropForeignKey(
                name: "f_k_job_post_scores_users_user_id",
                table: "job_post_scores");

            migrationBuilder.DropIndex(
                name: "i_x_job_post_scores_offer_id",
                table: "job_post_scores");

            migrationBuilder.DropIndex(
                name: "i_x_job_post_scores_user_id",
                table: "job_post_scores");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "job_post_scores",
                newName: "job_offer_id");

            migrationBuilder.RenameColumn(
                name: "offer_id",
                table: "job_post_scores",
                newName: "it_professional_id");

            migrationBuilder.CreateIndex(
                name: "i_x_job_post_scores_it_professional_id",
                table: "job_post_scores",
                column: "it_professional_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "i_x_job_post_scores_job_offer_id",
                table: "job_post_scores",
                column: "job_offer_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "f_k_job_post_scores_it_professionals_it_professional_id",
                table: "job_post_scores",
                column: "it_professional_id",
                principalTable: "it_professionals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "f_k_job_post_scores_offers_job_offer_id",
                table: "job_post_scores",
                column: "job_offer_id",
                principalTable: "offers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
