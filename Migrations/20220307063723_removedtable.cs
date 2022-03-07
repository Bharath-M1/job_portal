using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class removedtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSeekerExperience_tbl_seeker_SeekerId",
                table: "TblSeekerExperience");

            migrationBuilder.DropTable(
                name: "tbl_seeker_qualification");

            migrationBuilder.RenameColumn(
                name: "Percentage",
                table: "TblSeekerExperience",
                newName: "percentage");

            migrationBuilder.RenameColumn(
                name: "StartingDate",
                table: "TblSeekerExperience",
                newName: "starting_date");

            migrationBuilder.RenameColumn(
                name: "SeekerId",
                table: "TblSeekerExperience",
                newName: "seeker_id");

            migrationBuilder.RenameColumn(
                name: "InstituteName",
                table: "TblSeekerExperience",
                newName: "institute_name");

            migrationBuilder.RenameColumn(
                name: "DegereName",
                table: "TblSeekerExperience",
                newName: "degere_name");

            migrationBuilder.RenameColumn(
                name: "CompletionDate",
                table: "TblSeekerExperience",
                newName: "completion_date");

            migrationBuilder.RenameIndex(
                name: "IX_TblSeekerExperience_SeekerId",
                table: "TblSeekerExperience",
                newName: "IX_TblSeekerExperience_seeker_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "starting_date",
                table: "TblSeekerExperience",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "institute_name",
                table: "TblSeekerExperience",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "degere_name",
                table: "TblSeekerExperience",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "completion_date",
                table: "TblSeekerExperience",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSeekerExperience_tbl_seeker_seeker_id",
                table: "TblSeekerExperience",
                column: "seeker_id",
                principalTable: "tbl_seeker",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSeekerExperience_tbl_seeker_seeker_id",
                table: "TblSeekerExperience");

            migrationBuilder.RenameColumn(
                name: "percentage",
                table: "TblSeekerExperience",
                newName: "Percentage");

            migrationBuilder.RenameColumn(
                name: "starting_date",
                table: "TblSeekerExperience",
                newName: "StartingDate");

            migrationBuilder.RenameColumn(
                name: "seeker_id",
                table: "TblSeekerExperience",
                newName: "SeekerId");

            migrationBuilder.RenameColumn(
                name: "institute_name",
                table: "TblSeekerExperience",
                newName: "InstituteName");

            migrationBuilder.RenameColumn(
                name: "degere_name",
                table: "TblSeekerExperience",
                newName: "DegereName");

            migrationBuilder.RenameColumn(
                name: "completion_date",
                table: "TblSeekerExperience",
                newName: "CompletionDate");

            migrationBuilder.RenameIndex(
                name: "IX_TblSeekerExperience_seeker_id",
                table: "TblSeekerExperience",
                newName: "IX_TblSeekerExperience_SeekerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartingDate",
                table: "TblSeekerExperience",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "InstituteName",
                table: "TblSeekerExperience",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DegereName",
                table: "TblSeekerExperience",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletionDate",
                table: "TblSeekerExperience",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "tbl_seeker_qualification",
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
                name: "FK_TblSeekerExperience_tbl_seeker_SeekerId",
                table: "TblSeekerExperience",
                column: "SeekerId",
                principalTable: "tbl_seeker",
                principalColumn: "Id");
        }
    }
}
