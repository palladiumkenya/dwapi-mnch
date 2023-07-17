using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Mnch.Infrastructure.Migrations
{
    public partial class AddedZscoreCWCvisit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ZScore",
                table: "CwcVisits",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZScoreAbsolute",
                table: "CwcVisits",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZScore",
                table: "CwcVisits");

            migrationBuilder.DropColumn(
                name: "ZScoreAbsolute",
                table: "CwcVisits");
        }
    }
}
