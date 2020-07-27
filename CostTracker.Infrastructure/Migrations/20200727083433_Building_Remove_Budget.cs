using Microsoft.EntityFrameworkCore.Migrations;

namespace CostTracker.Infrastructure.Migrations
{
    public partial class Building_Remove_Budget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpectedCost",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Buildings");

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "Parts",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Parts");

            migrationBuilder.AddColumn<decimal>(
                name: "ExpectedCost",
                table: "Parts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "Buildings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
