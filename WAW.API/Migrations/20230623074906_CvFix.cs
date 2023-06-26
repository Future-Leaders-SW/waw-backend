using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAW.API.Migrations
{
    public partial class CvFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ubigeo_id",
                table: "users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "cv_id",
                table: "users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "score",
                table: "job_post_scores",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "extract",
                table: "cvs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "i_x_users_cv_id",
                table: "users",
                column: "cv_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "f_k_users__cvs_cv_id",
                table: "users",
                column: "cv_id",
                principalTable: "cvs",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_users__cvs_cv_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "i_x_users_cv_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "cv_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "score",
                table: "job_post_scores");

            migrationBuilder.DropColumn(
                name: "extract",
                table: "cvs");

            migrationBuilder.AlterColumn<long>(
                name: "ubigeo_id",
                table: "users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
