using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WAW.API.Migrations
{
    public partial class AddNewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<long>(
                name: "ubigeo_id",
                table: "users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "user_type",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

           

            migrationBuilder.CreateTable(
                name: "it_professionals",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    cv_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_it_professionals", x => x.id);
                    table.ForeignKey(
                        name: "f_k_it_professionals_cvs_cv_id",
                        column: x => x.cv_id,
                        principalTable: "cvs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "f_k_it_professionals_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "recruiters",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    company_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_recruiters", x => x.id);
                    table.ForeignKey(
                        name: "f_k_recruiters_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "f_k_recruiters_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

           
            migrationBuilder.CreateTable(
                name: "ubigeos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    departamento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    provincia = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    distrito = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_ubigeos", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "job_post_scores",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    it_professional_id = table.Column<long>(type: "bigint", nullable: false),
                    job_offer_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_job_post_scores", x => x.id);
                    table.ForeignKey(
                        name: "f_k_job_post_scores_it_professionals_it_professional_id",
                        column: x => x.it_professional_id,
                        principalTable: "it_professionals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "f_k_job_post_scores_offers_job_offer_id",
                        column: x => x.job_offer_id,
                        principalTable: "offers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            

            migrationBuilder.CreateIndex(
                name: "i_x_users_ubigeo_id",
                table: "users",
                column: "ubigeo_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "i_x_it_professionals_cv_id",
                table: "it_professionals",
                column: "cv_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "i_x_it_professionals_user_id",
                table: "it_professionals",
                column: "user_id",
                unique: true);

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

            

            migrationBuilder.CreateIndex(
                name: "i_x_recruiters_company_id",
                table: "recruiters",
                column: "company_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "i_x_recruiters_user_id",
                table: "recruiters",
                column: "user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "f_k_users__ubigeos_ubigeo_id",
                table: "users",
                column: "ubigeo_id",
                principalTable: "ubigeos",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_users__ubigeos_ubigeo_id",
                table: "users");

            migrationBuilder.DropTable(
                name: "job_post_scores");

            migrationBuilder.DropTable(
                name: "plan_subscriptions");

            migrationBuilder.DropTable(
                name: "recruiters");

            migrationBuilder.DropTable(
                name: "ubigeos");

            migrationBuilder.DropTable(
                name: "it_professionals");

            migrationBuilder.DropTable(
                name: "subscriptions");

            migrationBuilder.DropIndex(
                name: "i_x_users_ubigeo_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ubigeo_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "user_type",
                table: "users");

            migrationBuilder.DropColumn(
                name: "max_salary",
                table: "offers");

            migrationBuilder.DropColumn(
                name: "min_salary",
                table: "offers");

            migrationBuilder.AddColumn<long>(
                name: "cv_id",
                table: "users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "salary_range",
                table: "offers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

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
    }
}
