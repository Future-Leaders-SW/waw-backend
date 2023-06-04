using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAW.API.Migrations
{
    public partial class cv_develop_user2_deleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_cvs_users_user_id2",
                table: "cvs");

            migrationBuilder.DropIndex(
                name: "i_x_cvs_user_id2",
                table: "cvs");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "cvs");

            migrationBuilder.DropColumn(
                name: "user_id2",
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
                name: "i_x_users_cv_id1",
                table: "users",
                column: "cv_id1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "f_k_users__cvs_cv_id1",
                table: "users",
                column: "cv_id1",
                principalTable: "cvs",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_users__cvs_cv_id1",
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

            migrationBuilder.AddColumn<long>(
                name: "user_id2",
                table: "cvs",
                type: "bigint",
                nullable: true);

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
        }
    }
}
