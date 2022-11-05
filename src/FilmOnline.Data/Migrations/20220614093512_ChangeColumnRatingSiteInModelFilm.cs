using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmOnline.Data.Migrations
{
    public partial class ChangeColumnRatingSiteInModelFilm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "RatingSite",
                schema: "Film",
                table: "Films",
                type: "real",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RatingSite",
                schema: "Film",
                table: "Films",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 6);
        }
    }
}
