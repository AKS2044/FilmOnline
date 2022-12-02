using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmOnline.Data.Migrations
{
    public partial class DeleteTwoColumsInFilmModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatingImdb",
                schema: "Film",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "RatingKinopoisk",
                schema: "Film",
                table: "Films");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RatingImdb",
                schema: "Film",
                table: "Films",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RatingKinopoisk",
                schema: "Film",
                table: "Films",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");
        }
    }
}
