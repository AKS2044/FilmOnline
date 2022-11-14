using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmOnline.Data.Migrations
{
    public partial class ChangeColumnDateReg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateReg",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateReg",
                table: "AspNetUsers");
        }
    }
}
