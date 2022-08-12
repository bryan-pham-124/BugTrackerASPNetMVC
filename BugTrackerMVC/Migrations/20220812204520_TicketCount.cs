using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTrackerMVC.Migrations
{
    public partial class TicketCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketCount",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketCount",
                table: "Projects");
        }
    }
}
