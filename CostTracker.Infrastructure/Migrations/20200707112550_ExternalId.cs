using Microsoft.EntityFrameworkCore.Migrations;

namespace CostTracker.Infrastructure.Migrations
{
    public partial class ExternalId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "Parts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "Costs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "Buildings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Buildings");
        }
    }
}
