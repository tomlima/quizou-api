using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizou.Infrastructure.Migrations
{
    public partial class RenameFieldToTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Remover a FK antiga
            migrationBuilder.DropForeignKey(
                name: "FK_QuizTag_Tags_TagId",
                table: "QuizTag");

            // 2. Renomear a coluna e índice via SQL
            migrationBuilder.Sql("ALTER TABLE `QuizTag` RENAME COLUMN `TagId` TO `TagsId`;");
            migrationBuilder.Sql("ALTER TABLE `QuizTag` RENAME INDEX `IX_QuizTag_TagId` TO `IX_QuizTag_TagsId`;");

            // 3. Adicionar a nova FK
            migrationBuilder.AddForeignKey(
                name: "FK_QuizTag_Tags_TagsId",
                table: "QuizTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Reverter a FK
            migrationBuilder.DropForeignKey(
                name: "FK_QuizTag_Tags_TagsId",
                table: "QuizTag");

            // Renomear a coluna e índice de volta via SQL
            migrationBuilder.Sql("ALTER TABLE `QuizTag` RENAME COLUMN `TagsId` TO `TagId`;");
            migrationBuilder.Sql("ALTER TABLE `QuizTag` RENAME INDEX `IX_QuizTag_TagsId` TO `IX_QuizTag_TagId`;");

            // Restaurar a FK original
            migrationBuilder.AddForeignKey(
                name: "FK_QuizTag_Tags_TagId",
                table: "QuizTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
