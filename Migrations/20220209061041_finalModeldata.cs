using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class finalModeldata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_skillset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    skillset_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_skillset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    lastname = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    username = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    confirm_password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    type = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    contact_no = table.Column<long>(type: "bigint", nullable: true),
                    job_posted = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_company_tbl_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tbl_user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_seeker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    last_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    contact_no = table.Column<long>(type: "bigint", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    quaification = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    job_applied = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_seeker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_seeker_tbl_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tbl_user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_id = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    location = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    salary = table.Column<int>(type: "int", nullable: true),
                    no_of_vacancy = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_jobs_tbl_company_company_id",
                        column: x => x.company_id,
                        principalTable: "tbl_company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_experience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    job_title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    company_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    ending_date = table.Column<DateTime>(type: "date", nullable: true),
                    is_current = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    seeker_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_experience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_experience_tbl_seeker_seeker_id",
                        column: x => x.seeker_id,
                        principalTable: "tbl_seeker",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_seeker_qualification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    starting_date = table.Column<DateTime>(type: "date", nullable: false),
                    completion_date = table.Column<DateTime>(type: "date", nullable: true),
                    percentage = table.Column<double>(type: "float", nullable: true),
                    institute_name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    degere_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    seeker_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_seeker_qualification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_seeker_qualification_tbl_seeker_seeker_id",
                        column: x => x.seeker_id,
                        principalTable: "tbl_seeker",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_seeker_skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    seeker_id = table.Column<int>(type: "int", nullable: true),
                    skillset_Id = table.Column<int>(type: "int", nullable: true),
                    skill_level = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_seeker_skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_seeker_skills_tbl_seeker_seeker_id",
                        column: x => x.seeker_id,
                        principalTable: "tbl_seeker",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_seeker_skills_tbl_skillset_skillset_Id",
                        column: x => x.skillset_Id,
                        principalTable: "tbl_skillset",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_jobs_applied",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    job_id = table.Column<int>(type: "int", nullable: true),
                    seeker_id = table.Column<int>(type: "int", nullable: true),
                    applied_on = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_tbl_jobs_applied_tbl_jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "tbl_jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_jobs_applied_tbl_seeker_seeker_id",
                        column: x => x.seeker_id,
                        principalTable: "tbl_seeker",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_company_user_id",
                table: "tbl_company",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_experience_seeker_id",
                table: "tbl_experience",
                column: "seeker_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_jobs_company_id",
                table: "tbl_jobs",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_jobs_applied_job_id",
                table: "tbl_jobs_applied",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_jobs_applied_seeker_id",
                table: "tbl_jobs_applied",
                column: "seeker_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_seeker_user_id",
                table: "tbl_seeker",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_seeker_qualification_seeker_id",
                table: "tbl_seeker_qualification",
                column: "seeker_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_seeker_skills_seeker_id",
                table: "tbl_seeker_skills",
                column: "seeker_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_seeker_skills_skillset_Id",
                table: "tbl_seeker_skills",
                column: "skillset_Id");

            migrationBuilder.CreateIndex(
                name: "UQ__tbl_user__AB6E6164926B844C",
                table: "tbl_user",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_experience");

            migrationBuilder.DropTable(
                name: "tbl_jobs_applied");

            migrationBuilder.DropTable(
                name: "tbl_seeker_qualification");

            migrationBuilder.DropTable(
                name: "tbl_seeker_skills");

            migrationBuilder.DropTable(
                name: "tbl_jobs");

            migrationBuilder.DropTable(
                name: "tbl_seeker");

            migrationBuilder.DropTable(
                name: "tbl_skillset");

            migrationBuilder.DropTable(
                name: "tbl_company");

            migrationBuilder.DropTable(
                name: "tbl_user");
        }
    }
}
