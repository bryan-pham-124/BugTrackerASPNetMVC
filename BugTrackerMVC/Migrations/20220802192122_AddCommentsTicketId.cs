using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTrackerMVC.Migrations
{
    public partial class AddCommentsTicketId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Comments");
        }
    }
}
