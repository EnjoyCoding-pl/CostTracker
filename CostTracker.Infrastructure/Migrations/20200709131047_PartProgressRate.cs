using Microsoft.EntityFrameworkCore.Migrations;

namespace CostTracker.Infrastructure.Migrations
{
    public partial class PartProgressRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgressRatio",
                table: "Parts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgressRatio",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
