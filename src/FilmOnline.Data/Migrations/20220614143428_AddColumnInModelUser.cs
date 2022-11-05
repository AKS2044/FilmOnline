using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmOnline.Data.Migrations
{
    public partial class AddColumnInModelUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathPhoto",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathPhoto",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "AspNetUsers");
        }
    }
}
