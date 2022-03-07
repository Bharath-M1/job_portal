using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class cleanedcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_experience_tbl_seeker_seeker_id",
                table: "tbl_experience");

            migrationBuilder.DropTable(
                name: "TblSeekerExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_experience",
                table: "tbl_experience");

            migrationBuilder.RenameTable(
                name: "tbl_experience",
                newName: "tbl_seeker_experience");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_experience_seeker_id",
                table: "tbl_seeker_experience",
                newName: "IX_tbl_seeker_experience_seeker_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_seeker_experience",
                table: "tbl_seeker_experience",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_tbl_seeker_qualification_seeker_id",
                table: "tbl_seeker_qualification",
                column: "seeker_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_seeker_experience_tbl_seeker_seeker_id",
                table: "tbl_seeker_experience",
                column: "seeker_id",
                principalTable: "tbl_seeker",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_seeker_experience_tbl_seeker_seeker_id",
                table: "tbl_seeker_experience");

            migrationBuilder.DropTable(
                name: "tbl_seeker_qualification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_seeker_experience",
                table: "tbl_seeker_experience");

            migrationBuilder.RenameTable(
                name: "tbl_seeker_experience",
                newName: "tbl_experience");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_seeker_experience_seeker_id",
                table: "tbl_experience",
                newName: "IX_tbl_experience_seeker_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_experience",
                table: "tbl_experience",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TblSeekerExperience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    seeker_id = table.Column<int>(type: "int", nullable: true),
                    completion_date = table.Column<DateTime>(type: "date", nullable: true),
                    degere_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    institute_name = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    percentage = table.Column<double>(type: "float", nullable: true),
                    starting_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSeekerExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblSeekerExperience_tbl_seeker_seeker_id",
                        column: x => x.seeker_id,
                        principalTable: "tbl_seeker",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblSeekerExperience_seeker_id",
                table: "TblSeekerExperience",
                column: "seeker_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_experience_tbl_seeker_seeker_id",
                table: "tbl_experience",
                column: "seeker_id",
                principalTable: "tbl_seeker",
                principalColumn: "Id");
        }
    }
}
