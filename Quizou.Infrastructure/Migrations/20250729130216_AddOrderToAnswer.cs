using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizou.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderToAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Answers");
        }
    }
}
