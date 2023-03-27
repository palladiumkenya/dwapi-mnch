using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Mnch.Infrastructure.Migrations
{
    public partial class AncVisitsAddedVariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HepatitisBScreening",
                table: "AncVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiminumPackageOfCareReceived",
                table: "AncVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiminumPackageOfCareServices",
                table: "AncVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresumptiveTreatmentDose",
                table: "AncVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresumptiveTreatmentGiven",
                table: "AncVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TreatedHepatitisB",
                table: "AncVisits",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HepatitisBScreening",
                table: "AncVisits");

            migrationBuilder.DropColumn(
                name: "MiminumPackageOfCareReceived",
                table: "AncVisits");

            migrationBuilder.DropColumn(
                name: "MiminumPackageOfCareServices",
                table: "AncVisits");

            migrationBuilder.DropColumn(
                name: "PresumptiveTreatmentDose",
                table: "AncVisits");

            migrationBuilder.DropColumn(
                name: "PresumptiveTreatmentGiven",
                table: "AncVisits");

            migrationBuilder.DropColumn(
                name: "TreatedHepatitisB",
                table: "AncVisits");
        }
    }
}
