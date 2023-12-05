using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Mnch.Infrastructure.Migrations
{
    public partial class RecordUUIDandVoided : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "PncVisits",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "PncVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "MotherBabyPairs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "MotherBabyPairs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "MnchPatients",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "MnchPatients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "MnchLabs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "MnchLabs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "MnchImmunizations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "MnchImmunizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "MnchEnrolments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "MnchEnrolments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "MnchArts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "MnchArts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "MatVisits",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "MatVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "Heis",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "Heis",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "CwcVisits",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "CwcVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "CwcEnrolments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "CwcEnrolments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordUUID",
                table: "AncVisits",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Voided",
                table: "AncVisits",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "PncVisits");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "PncVisits");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "MotherBabyPairs");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "MotherBabyPairs");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "MnchPatients");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "MnchPatients");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "MnchLabs");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "MnchLabs");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "MnchImmunizations");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "MnchImmunizations");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "MnchEnrolments");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "MnchEnrolments");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "MnchArts");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "MnchArts");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "MatVisits");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "MatVisits");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "Heis");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "Heis");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "CwcVisits");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "CwcVisits");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "CwcEnrolments");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "CwcEnrolments");

            migrationBuilder.DropColumn(
                name: "RecordUUID",
                table: "AncVisits");

            migrationBuilder.DropColumn(
                name: "Voided",
                table: "AncVisits");
        }
    }
}
