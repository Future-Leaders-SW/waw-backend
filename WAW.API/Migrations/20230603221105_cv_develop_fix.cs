using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAW.API.Migrations
{
    public partial class cv_develop_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_users__cvs_cv_id",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "f_k_users__cvs_cv_id1",
                table: "users");

            migrationBuilder.DropIndex(
                name: "i_x_users_cv_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "i_x_users_cv_id1",
                table: "users");

            migrationBuilder.DropColumn(
                name: "cv_id1",
                table: "users");

            migrationBuilder.AlterColumn<long>(
                name: "cv_id",
                table: "users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "user_id",
                table: "cvs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "i_x_cvs_user_id",
                table: "cvs",
                column: "user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "f_k_cvs_users_user_id",
                table: "cvs",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_cvs_users_user_id",
                table: "cvs");

            migrationBuilder.DropIndex(
                name: "i_x_cvs_user_id",
                table: "cvs");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "cvs");

            migrationBuilder.AlterColumn<long>(
                name: "cv_id",
                table: "users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "cv_id1",
                table: "users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "i_x_users_cv_id",
                table: "users",
                column: "cv_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "i_x_users_cv_id1",
                table: "users",
                column: "cv_id1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "f_k_users__cvs_cv_id",
                table: "users",
                column: "cv_id",
                principalTable: "cvs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "f_k_users__cvs_cv_id1",
                table: "users",
                column: "cv_id1",
                principalTable: "cvs",
                principalColumn: "id");
        }
    }
}
