using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmOnline.Data.Migrations
{
    public partial class AddConf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentFilmUsers_AspNetUsers_UserId",
                table: "CommentFilmUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentFilmUsers_Comments_CommentId",
                table: "CommentFilmUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentFilmUsers_Films_FilmId",
                table: "CommentFilmUsers");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comments",
                newSchema: "Film");

            migrationBuilder.RenameTable(
                name: "CommentFilmUsers",
                newName: "CommentFilmUsers",
                newSchema: "Film");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                schema: "Film",
                table: "Comments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentFilmUsers_AspNetUsers_UserId",
                schema: "Film",
                table: "CommentFilmUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentFilmUsers_Comments_CommentId",
                schema: "Film",
                table: "CommentFilmUsers",
                column: "CommentId",
                principalSchema: "Film",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentFilmUsers_Films_FilmId",
                schema: "Film",
                table: "CommentFilmUsers",
                column: "FilmId",
                principalSchema: "Film",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentFilmUsers_AspNetUsers_UserId",
                schema: "Film",
                table: "CommentFilmUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentFilmUsers_Comments_CommentId",
                schema: "Film",
                table: "CommentFilmUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentFilmUsers_Films_FilmId",
                schema: "Film",
                table: "CommentFilmUsers");

            migrationBuilder.RenameTable(
                name: "Comments",
                schema: "Film",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "CommentFilmUsers",
                schema: "Film",
                newName: "CommentFilmUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentFilmUsers_AspNetUsers_UserId",
                table: "CommentFilmUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentFilmUsers_Comments_CommentId",
                table: "CommentFilmUsers",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentFilmUsers_Films_FilmId",
                table: "CommentFilmUsers",
                column: "FilmId",
                principalSchema: "Film",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
