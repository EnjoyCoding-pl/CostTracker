using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CostTracker.Infrastructure.Migrations
{
    public partial class PartDate_BuildingBudget_CostInvoiceUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Parts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Parts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InvoiceUrl",
                table: "Costs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "Buildings",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "InvoiceUrl",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Buildings");
        }
    }
}
