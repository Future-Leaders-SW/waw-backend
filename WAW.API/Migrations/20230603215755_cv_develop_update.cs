using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAW.API.Migrations
{
    public partial class cv_develop_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "cv_id",
                table: "users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "user_id",
                table: "cvs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "user_id2",
                table: "cvs",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "i_x_users_cv_id",
                table: "users",
                column: "cv_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "i_x_cvs_user_id2",
                table: "cvs",
                column: "user_id2");

            migrationBuilder.AddForeignKey(
                name: "f_k_cvs_users_user_id2",
                table: "cvs",
                column: "user_id2",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "f_k_users__cvs_cv_id",
                table: "users",
                column: "cv_id",
                principalTable: "cvs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_cvs_users_user_id2",
                table: "cvs");

            migrationBuilder.DropForeignKey(
                name: "f_k_users__cvs_cv_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "i_x_users_cv_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "i_x_cvs_user_id2",
                table: "cvs");

            migrationBuilder.DropColumn(
                name: "cv_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "cvs");

            migrationBuilder.DropColumn(
                name: "user_id2",
                table: "cvs");
        }
    }
}
