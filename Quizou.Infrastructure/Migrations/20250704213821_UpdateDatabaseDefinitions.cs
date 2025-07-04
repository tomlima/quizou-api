using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Quizou.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseDefinitions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Histories_HistoryId",
                table: "Battles");

            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Users_UserAId",
                table: "Battles");

            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Users_UserBId",
                table: "Battles");

            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Users_WinnerId",
                table: "Battles");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tags_TagId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_Users_FriendId",
                table: "UserFriends");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TagId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Battles_HistoryId",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "Battles");

            migrationBuilder.CreateTable(
                name: "QuestionTag",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTag", x => new { x.QuestionsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_QuestionTag_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTag_TagsId",
                table: "QuestionTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Users_UserAId",
                table: "Battles",
                column: "UserAId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Users_UserBId",
                table: "Battles",
                column: "UserBId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Users_WinnerId",
                table: "Battles",
                column: "WinnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_Users_FriendId",
                table: "UserFriends",
                column: "FriendId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Users_UserAId",
                table: "Battles");

            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Users_UserBId",
                table: "Battles");

            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Users_WinnerId",
                table: "Battles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_Users_FriendId",
                table: "UserFriends");

            migrationBuilder.DropTable(
                name: "QuestionTag");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "Battles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TagId",
                table: "Questions",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_HistoryId",
                table: "Battles",
                column: "HistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Histories_HistoryId",
                table: "Battles",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Users_UserAId",
                table: "Battles",
                column: "UserAId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Users_UserBId",
                table: "Battles",
                column: "UserBId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Users_WinnerId",
                table: "Battles",
                column: "WinnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tags_TagId",
                table: "Questions",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_Users_FriendId",
                table: "UserFriends",
                column: "FriendId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
