using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizou.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTagListToQuiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Tags_TagId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_TagId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Quizzes");

            migrationBuilder.AddColumn<int>(
                name: "QuizId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_QuizId",
                table: "Tags",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Quizzes_QuizId",
                table: "Tags",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Quizzes_QuizId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_QuizId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "Tags");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_TagId",
                table: "Quizzes",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Tags_TagId",
                table: "Quizzes",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
