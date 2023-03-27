using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Mnch.Infrastructure.Migrations
{
    public partial class PMTCTImmunizationsAndMnchUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InfactCameForHAART",
                table: "PncVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherCameForHIVTest",
                table: "PncVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherGivenHAART",
                table: "PncVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisitTimingBaby",
                table: "PncVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisitTimingMother",
                table: "PncVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacilityReceivingARTCare",
                table: "MnchArts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EDD",
                table: "MatVisits",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LMP",
                table: "MatVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaternalDeathAudited",
                table: "MatVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OnARTMat",
                table: "MatVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferralReason",
                table: "MatVisits",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HeightLength",
                table: "CwcVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Refferred",
                table: "CwcVisits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RevisitThisYear",
                table: "CwcVisits",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MnchImmunizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RefId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    PatientPk = table.Column<int>(nullable: false),
                    SiteCode = table.Column<int>(nullable: false),
                    Emr = table.Column<string>(nullable: true),
                    Project = table.Column<string>(nullable: true),
                    Processed = table.Column<bool>(nullable: true),
                    QueueId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    StatusDate = table.Column<DateTime>(nullable: true),
                    DateExtracted = table.Column<DateTime>(nullable: true),
                    FacilityId = table.Column<Guid>(nullable: false),
                    FacilityName = table.Column<string>(nullable: true),
                    PatientMnchID = table.Column<string>(nullable: true),
                    BCG = table.Column<DateTime>(nullable: true),
                    OPVatBirth = table.Column<DateTime>(nullable: true),
                    OPV1 = table.Column<DateTime>(nullable: true),
                    OPV2 = table.Column<DateTime>(nullable: true),
                    OPV3 = table.Column<DateTime>(nullable: true),
                    IPV = table.Column<DateTime>(nullable: true),
                    DPTHepBHIB1 = table.Column<DateTime>(nullable: true),
                    DPTHepBHIB2 = table.Column<DateTime>(nullable: true),
                    DPTHepBHIB3 = table.Column<DateTime>(nullable: true),
                    PCV101 = table.Column<DateTime>(nullable: true),
                    PCV102 = table.Column<DateTime>(nullable: true),
                    PCV103 = table.Column<DateTime>(nullable: true),
                    ROTA1 = table.Column<DateTime>(nullable: true),
                    MeaslesReubella1 = table.Column<DateTime>(nullable: true),
                    YellowFever = table.Column<DateTime>(nullable: true),
                    MeaslesReubella2 = table.Column<DateTime>(nullable: true),
                    MeaslesAt6Months = table.Column<DateTime>(nullable: true),
                    ROTA2 = table.Column<DateTime>(nullable: true),
                    DateOfNextVisit = table.Column<DateTime>(nullable: true),
                    BCGScarChecked = table.Column<string>(nullable: true),
                    DateChecked = table.Column<DateTime>(nullable: true),
                    DateBCGrepeated = table.Column<DateTime>(nullable: true),
                    VitaminAAt6Months = table.Column<DateTime>(nullable: true),
                    VitaminAAt1Yr = table.Column<DateTime>(nullable: true),
                    VitaminAAt18Months = table.Column<DateTime>(nullable: true),
                    VitaminAAt2Years = table.Column<DateTime>(nullable: true),
                    VitaminAAt2To5Years = table.Column<DateTime>(nullable: true),
                    FullyImmunizedChild = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MnchImmunizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MnchImmunizations_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MnchImmunizations_FacilityId",
                table: "MnchImmunizations",
                column: "FacilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MnchImmunizations");

            migrationBuilder.DropColumn(
                name: "InfactCameForHAART",
                table: "PncVisits");

            migrationBuilder.DropColumn(
                name: "MotherCameForHIVTest",
                table: "PncVisits");

            migrationBuilder.DropColumn(
                name: "MotherGivenHAART",
                table: "PncVisits");

            migrationBuilder.DropColumn(
                name: "VisitTimingBaby",
                table: "PncVisits");

            migrationBuilder.DropColumn(
                name: "VisitTimingMother",
                table: "PncVisits");

            migrationBuilder.DropColumn(
                name: "FacilityReceivingARTCare",
                table: "MnchArts");

            migrationBuilder.DropColumn(
                name: "EDD",
                table: "MatVisits");

            migrationBuilder.DropColumn(
                name: "LMP",
                table: "MatVisits");

            migrationBuilder.DropColumn(
                name: "MaternalDeathAudited",
                table: "MatVisits");

            migrationBuilder.DropColumn(
                name: "OnARTMat",
                table: "MatVisits");

            migrationBuilder.DropColumn(
                name: "ReferralReason",
                table: "MatVisits");

            migrationBuilder.DropColumn(
                name: "HeightLength",
                table: "CwcVisits");

            migrationBuilder.DropColumn(
                name: "Refferred",
                table: "CwcVisits");

            migrationBuilder.DropColumn(
                name: "RevisitThisYear",
                table: "CwcVisits");
        }
    }
}
