using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAW.API.Migrations
{
    public partial class cv_fix : Migration
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
                name: "cv_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "cvs");
        }
    }
}
