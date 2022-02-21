using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class seekerandcompanymodiofiedbyuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "confirm_password",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "firstname",
                table: "tbl_user");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "tbl_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "confirm_password",
                table: "tbl_user",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "tbl_user",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "tbl_user",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);
        }
    }
}
