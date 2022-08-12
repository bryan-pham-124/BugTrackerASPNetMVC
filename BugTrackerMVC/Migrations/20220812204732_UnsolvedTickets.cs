using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTrackerMVC.Migrations
{
    public partial class UnsolvedTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketCount",
                table: "Projects",
                newName: "UnsolvedTicketCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnsolvedTicketCount",
                table: "Projects",
                newName: "TicketCount");
        }
    }
}
