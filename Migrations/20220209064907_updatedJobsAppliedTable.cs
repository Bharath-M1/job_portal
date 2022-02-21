using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
  public partial class updatedJobsAppliedTable : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterColumn<int>(
          name: "Id",
          table: "tbl_jobs_applied",
          type: "int",
          nullable: false,
          oldClrType: typeof(int),
          oldType: "int");

      migrationBuilder.AddPrimaryKey(
          name: "PK_tbl_jobs_applied",
          table: "tbl_jobs_applied",
          column: "Id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropPrimaryKey(
          name: "PK_tbl_jobs_applied",
          table: "tbl_jobs_applied");

      migrationBuilder.AlterColumn<int>(
          name: "Id",
          table: "tbl_jobs_applied",
          type: "int",
          nullable: false,
          oldClrType: typeof(int),
          oldType: "int");
    }
  }
}
