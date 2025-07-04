using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizou.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Tags",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tags");
        }
    }
}
