using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizou.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQuizTagRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "QuizTag",
                columns: table => new
                {
                    QuizzesId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizTag", x => new { x.QuizzesId, x.TagId });
                    table.ForeignKey(
                        name: "FK_QuizTag_Quizzes_QuizzesId",
                        column: x => x.QuizzesId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_QuizTag_TagId",
                table: "QuizTag",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizTag");

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
    }
}
