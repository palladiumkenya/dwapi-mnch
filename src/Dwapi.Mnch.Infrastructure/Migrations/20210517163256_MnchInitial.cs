using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dwapi.Mnch.Infrastructure.Migrations
{
    public partial class MnchInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dockets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RefId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Instance = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dockets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    RefId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 120, nullable: true),
                    County = table.Column<string>(maxLength: 120, nullable: true),
                    SnapshotDate = table.Column<DateTime>(nullable: true),
                    SnapshotSiteCode = table.Column<int>(nullable: true),
                    SnapshotVersion = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterFacilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RefId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AuthCode = table.Column<string>(nullable: true),
                    DocketId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscribers_Dockets_DocketId",
                        column: x => x.DocketId,
                        principalTable: "Dockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RefId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    SiteCode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 120, nullable: true),
                    MasterFacilityId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Emr = table.Column<string>(nullable: true),
                    SnapshotDate = table.Column<DateTime>(nullable: true),
                    SnapshotSiteCode = table.Column<int>(nullable: true),
                    SnapshotVersion = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facilities_MasterFacilities_MasterFacilityId",
                        column: x => x.MasterFacilityId,
                        principalTable: "MasterFacilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AncVisits",
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
                    PatientMnchID = table.Column<string>(nullable: true),
                    FacilityName = table.Column<string>(nullable: true),
                    VisitID = table.Column<int>(nullable: true),
                    VisitDate = table.Column<DateTime>(nullable: true),
                    ANCClinicNumber = table.Column<string>(nullable: true),
                    ANCVisitNo = table.Column<int>(nullable: true),
                    GestationWeeks = table.Column<int>(nullable: true),
                    Height = table.Column<decimal>(nullable: true),
                    Weight = table.Column<decimal>(nullable: true),
                    Temp = table.Column<decimal>(nullable: true),
                    PulseRate = table.Column<int>(nullable: true),
                    RespiratoryRate = table.Column<int>(nullable: true),
                    OxygenSaturation = table.Column<decimal>(nullable: true),
                    MUAC = table.Column<int>(nullable: true),
                    BP = table.Column<int>(nullable: true),
                    BreastExam = table.Column<string>(nullable: true),
                    AntenatalExercises = table.Column<string>(nullable: true),
                    FGM = table.Column<string>(nullable: true),
                    FGMComplications = table.Column<string>(nullable: true),
                    Haemoglobin = table.Column<decimal>(nullable: true),
                    DiabetesTest = table.Column<string>(nullable: true),
                    TBScreening = table.Column<string>(nullable: true),
                    CACxScreen = table.Column<string>(nullable: true),
                    CACxScreenMethod = table.Column<string>(nullable: true),
                    WHOStaging = table.Column<int>(nullable: true),
                    VLSampleTaken = table.Column<string>(nullable: true),
                    VLDate = table.Column<DateTime>(nullable: true),
                    VLResult = table.Column<string>(nullable: true),
                    SyphilisTreatment = table.Column<string>(nullable: true),
                    HIVStatusBeforeANC = table.Column<string>(nullable: true),
                    HIVTestingDone = table.Column<string>(nullable: true),
                    HIVTestType = table.Column<string>(nullable: true),
                    HIVTest1 = table.Column<string>(nullable: true),
                    HIVTest1Result = table.Column<string>(nullable: true),
                    HIVTest2 = table.Column<string>(nullable: true),
                    HIVTest2Result = table.Column<string>(nullable: true),
                    HIVTestFinalResult = table.Column<string>(nullable: true),
                    SyphilisTestDone = table.Column<string>(nullable: true),
                    SyphilisTestType = table.Column<string>(nullable: true),
                    SyphilisTestResults = table.Column<string>(nullable: true),
                    SyphilisTreated = table.Column<string>(nullable: true),
                    MotherProphylaxisGiven = table.Column<string>(nullable: true),
                    MotherGivenHAART = table.Column<DateTime>(nullable: true),
                    AZTBabyDispense = table.Column<string>(nullable: true),
                    NVPBabyDispense = table.Column<string>(nullable: true),
                    ChronicIllness = table.Column<string>(nullable: true),
                    CounselledOn = table.Column<string>(nullable: true),
                    PartnerHIVTestingANC = table.Column<string>(nullable: true),
                    PartnerHIVStatusANC = table.Column<string>(nullable: true),
                    PostParturmFP = table.Column<string>(nullable: true),
                    Deworming = table.Column<string>(nullable: true),
                    MalariaProphylaxis = table.Column<string>(nullable: true),
                    TetanusDose = table.Column<string>(nullable: true),
                    IronSupplementsGiven = table.Column<string>(nullable: true),
                    ReceivedMosquitoNet = table.Column<string>(nullable: true),
                    PreventiveServices = table.Column<string>(nullable: true),
                    UrinalysisVariables = table.Column<string>(nullable: true),
                    ReferredFrom = table.Column<string>(nullable: true),
                    ReferredTo = table.Column<string>(nullable: true),
                    ReferralReasons = table.Column<string>(nullable: true),
                    NextAppointmentANC = table.Column<DateTime>(nullable: true),
                    ClinicalNotes = table.Column<string>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AncVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AncVisits_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CwcEnrolments",
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
                    Pkv = table.Column<string>(nullable: true),
                    PatientIDCWC = table.Column<string>(nullable: true),
                    HEIID = table.Column<string>(nullable: true),
                    MothersPkv = table.Column<string>(nullable: true),
                    RegistrationAtCWC = table.Column<DateTime>(nullable: true),
                    RegistrationAtHEI = table.Column<DateTime>(nullable: true),
                    VisitID = table.Column<int>(nullable: true),
                    Gestation = table.Column<DateTime>(nullable: true),
                    BirthWeight = table.Column<string>(nullable: true),
                    BirthLength = table.Column<decimal>(nullable: true),
                    BirthOrder = table.Column<int>(nullable: true),
                    BirthType = table.Column<string>(nullable: true),
                    PlaceOfDelivery = table.Column<string>(nullable: true),
                    ModeOfDelivery = table.Column<string>(nullable: true),
                    SpecialNeeds = table.Column<string>(nullable: true),
                    SpecialCare = table.Column<string>(nullable: true),
                    HEI = table.Column<string>(nullable: true),
                    MotherAlive = table.Column<string>(nullable: true),
                    MothersCCCNo = table.Column<string>(nullable: true),
                    TransferIn = table.Column<string>(nullable: true),
                    TransferInDate = table.Column<string>(nullable: true),
                    TransferredFrom = table.Column<string>(nullable: true),
                    HEIDate = table.Column<string>(nullable: true),
                    NVP = table.Column<string>(nullable: true),
                    BreastFeeding = table.Column<string>(nullable: true),
                    ReferredFrom = table.Column<string>(nullable: true),
                    ARTMother = table.Column<string>(nullable: true),
                    ARTRegimenMother = table.Column<string>(nullable: true),
                    ARTStartDateMother = table.Column<DateTime>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CwcEnrolments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CwcEnrolments_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CwcVisits",
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
                    VisitDate = table.Column<DateTime>(nullable: true),
                    VisitID = table.Column<int>(nullable: true),
                    Height = table.Column<decimal>(nullable: true),
                    Weight = table.Column<decimal>(nullable: true),
                    Temp = table.Column<decimal>(nullable: true),
                    PulseRate = table.Column<int>(nullable: true),
                    RespiratoryRate = table.Column<int>(nullable: true),
                    OxygenSaturation = table.Column<decimal>(nullable: true),
                    MUAC = table.Column<int>(nullable: true),
                    WeightCategory = table.Column<string>(nullable: true),
                    Stunted = table.Column<string>(nullable: true),
                    InfantFeeding = table.Column<string>(nullable: true),
                    MedicationGiven = table.Column<string>(nullable: true),
                    TBAssessment = table.Column<string>(nullable: true),
                    MNPsSupplementation = table.Column<string>(nullable: true),
                    Immunization = table.Column<string>(nullable: true),
                    DangerSigns = table.Column<string>(nullable: true),
                    Milestones = table.Column<string>(nullable: true),
                    VitaminA = table.Column<string>(nullable: true),
                    Disability = table.Column<string>(nullable: true),
                    ReceivedMosquitoNet = table.Column<string>(nullable: true),
                    Dewormed = table.Column<string>(nullable: true),
                    ReferredFrom = table.Column<string>(nullable: true),
                    ReferredTo = table.Column<string>(nullable: true),
                    ReferralReasons = table.Column<string>(nullable: true),
                    FollowUP = table.Column<string>(nullable: true),
                    NextAppointment = table.Column<DateTime>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CwcVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CwcVisits_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Heis",
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
                    DNAPCR1Date = table.Column<DateTime>(nullable: true),
                    DNAPCR2Date = table.Column<DateTime>(nullable: true),
                    DNAPCR3Date = table.Column<DateTime>(nullable: true),
                    ConfirmatoryPCRDate = table.Column<DateTime>(nullable: true),
                    BasellineVLDate = table.Column<DateTime>(nullable: true),
                    FinalyAntibodyDate = table.Column<DateTime>(nullable: true),
                    DNAPCR1 = table.Column<DateTime>(nullable: true),
                    DNAPCR2 = table.Column<DateTime>(nullable: true),
                    DNAPCR3 = table.Column<DateTime>(nullable: true),
                    ConfirmatoryPCR = table.Column<DateTime>(nullable: true),
                    BasellineVL = table.Column<DateTime>(nullable: true),
                    FinalyAntibody = table.Column<DateTime>(nullable: true),
                    HEIExitDate = table.Column<DateTime>(nullable: true),
                    HEIHIVStatus = table.Column<string>(nullable: true),
                    HEIExitCritearia = table.Column<string>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heis_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manifests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RefId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    SiteCode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Sent = table.Column<int>(nullable: false),
                    Recieved = table.Column<int>(nullable: false),
                    DateLogged = table.Column<DateTime>(nullable: false),
                    DateArrived = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusDate = table.Column<DateTime>(nullable: false),
                    FacilityId = table.Column<Guid>(nullable: false),
                    EmrId = table.Column<Guid>(nullable: true),
                    EmrName = table.Column<string>(nullable: true),
                    EmrSetup = table.Column<int>(nullable: false),
                    Session = table.Column<Guid>(nullable: true),
                    Start = table.Column<DateTime>(nullable: true),
                    End = table.Column<DateTime>(nullable: true),
                    Tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manifests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manifests_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatVisits",
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
                    PatientMnchID = table.Column<string>(nullable: true),
                    FacilityName = table.Column<string>(nullable: true),
                    VisitID = table.Column<int>(nullable: true),
                    VisitDate = table.Column<DateTime>(nullable: true),
                    AdmissionNumber = table.Column<string>(nullable: true),
                    ANCVisits = table.Column<int>(nullable: true),
                    DateOfDelivery = table.Column<DateTime>(nullable: true),
                    DurationOfDelivery = table.Column<int>(nullable: true),
                    GestationAtBirth = table.Column<int>(nullable: true),
                    ModeOfDelivery = table.Column<string>(nullable: true),
                    PlacentaComplete = table.Column<string>(nullable: true),
                    UterotonicGiven = table.Column<string>(nullable: true),
                    VaginalExamination = table.Column<string>(nullable: true),
                    BloodLoss = table.Column<int>(nullable: true),
                    BloodLossVisual = table.Column<string>(nullable: true),
                    ConditonAfterDelivery = table.Column<string>(nullable: true),
                    MaternalDeath = table.Column<DateTime>(nullable: true),
                    DeliveryComplications = table.Column<string>(nullable: true),
                    NoBabiesDelivered = table.Column<int>(nullable: true),
                    BabyBirthNumber = table.Column<int>(nullable: true),
                    SexBaby = table.Column<string>(nullable: true),
                    BirthWeight = table.Column<string>(nullable: true),
                    BirthOutcome = table.Column<string>(nullable: true),
                    BirthWithDeformity = table.Column<string>(nullable: true),
                    TetracyclineGiven = table.Column<string>(nullable: true),
                    InitiatedBF = table.Column<string>(nullable: true),
                    ApgarScore1 = table.Column<int>(nullable: true),
                    ApgarScore5 = table.Column<int>(nullable: true),
                    ApgarScore10 = table.Column<int>(nullable: true),
                    KangarooCare = table.Column<string>(nullable: true),
                    ChlorhexidineApplied = table.Column<string>(nullable: true),
                    VitaminKGiven = table.Column<string>(nullable: true),
                    StatusBabyDischarge = table.Column<string>(nullable: true),
                    MotherDischargeDate = table.Column<string>(nullable: true),
                    SyphilisTestResults = table.Column<string>(nullable: true),
                    HIVStatusLastANC = table.Column<string>(nullable: true),
                    HIVTestingDone = table.Column<string>(nullable: true),
                    HIVTest1 = table.Column<string>(nullable: true),
                    HIV1Results = table.Column<string>(nullable: true),
                    HIVTest2 = table.Column<string>(nullable: true),
                    HIV2Results = table.Column<string>(nullable: true),
                    HIVTestFinalResult = table.Column<string>(nullable: true),
                    OnARTANC = table.Column<string>(nullable: true),
                    BabyGivenProphylaxis = table.Column<string>(nullable: true),
                    MotherGivenCTX = table.Column<string>(nullable: true),
                    PartnerHIVTestingMAT = table.Column<string>(nullable: true),
                    PartnerHIVStatusMAT = table.Column<string>(nullable: true),
                    CounselledOn = table.Column<string>(nullable: true),
                    ReferredFrom = table.Column<string>(nullable: true),
                    ReferredTo = table.Column<string>(nullable: true),
                    ClinicalNotes = table.Column<string>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatVisits_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MnchArts",
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
                    Pkv = table.Column<string>(nullable: true),
                    PatientMnchID = table.Column<string>(nullable: true),
                    PatientHeiID = table.Column<string>(nullable: true),
                    FacilityName = table.Column<string>(nullable: true),
                    RegistrationAtCCC = table.Column<DateTime>(nullable: true),
                    StartARTDate = table.Column<DateTime>(nullable: true),
                    StartRegimen = table.Column<string>(nullable: true),
                    StartRegimenLine = table.Column<string>(nullable: true),
                    StatusAtCCC = table.Column<string>(nullable: true),
                    LastARTDate = table.Column<DateTime>(nullable: true),
                    LastRegimen = table.Column<string>(nullable: true),
                    LastRegimenLine = table.Column<string>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MnchArts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MnchArts_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MnchEnrolments",
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
                    PatientMnchID = table.Column<string>(nullable: true),
                    FacilityName = table.Column<string>(nullable: true),
                    ServiceType = table.Column<string>(nullable: true),
                    EnrollmentDateAtMnch = table.Column<DateTime>(nullable: true),
                    MnchNumber = table.Column<DateTime>(nullable: true),
                    FirstVisitAnc = table.Column<DateTime>(nullable: true),
                    Parity = table.Column<string>(nullable: true),
                    Gravidae = table.Column<int>(nullable: false),
                    LMP = table.Column<DateTime>(nullable: true),
                    EDDFromLMP = table.Column<DateTime>(nullable: true),
                    HIVStatusBeforeANC = table.Column<string>(nullable: true),
                    HIVTestDate = table.Column<DateTime>(nullable: true),
                    PartnerHIVStatus = table.Column<string>(nullable: true),
                    PartnerHIVTestDate = table.Column<DateTime>(nullable: true),
                    BloodGroup = table.Column<string>(nullable: true),
                    StatusAtMnch = table.Column<string>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MnchEnrolments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MnchEnrolments_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MnchLabs",
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
                    PatientMNCH_ID = table.Column<string>(nullable: true),
                    FacilityName = table.Column<string>(nullable: true),
                    SatelliteName = table.Column<string>(nullable: true),
                    VisitID = table.Column<int>(nullable: true),
                    OrderedbyDate = table.Column<DateTime>(nullable: true),
                    ReportedbyDate = table.Column<DateTime>(nullable: true),
                    TestName = table.Column<string>(nullable: true),
                    TestResult = table.Column<string>(nullable: true),
                    LabReason = table.Column<string>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MnchLabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MnchLabs_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MnchPatients",
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
                    Pkv = table.Column<string>(nullable: true),
                    PatientMnchID = table.Column<string>(nullable: true),
                    PatientHeiID = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: true),
                    FirstEnrollmentAtMnch = table.Column<DateTime>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true),
                    EducationLevel = table.Column<string>(nullable: true),
                    PatientResidentCounty = table.Column<string>(nullable: true),
                    PatientResidentSubCounty = table.Column<string>(nullable: true),
                    PatientResidentWard = table.Column<string>(nullable: true),
                    InSchool = table.Column<string>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MnchPatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MnchPatients_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotherBabyPairs",
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
                    BabyPatientPK = table.Column<int>(nullable: false),
                    MotherPatientPK = table.Column<int>(nullable: false),
                    BabyPatientMncHeiID = table.Column<string>(nullable: true),
                    MotherPatientMncHeiID = table.Column<string>(nullable: true),
                    PatientIDCCC = table.Column<string>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherBabyPairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotherBabyPairs_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PncVisits",
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
                    PatientMnchID = table.Column<string>(nullable: true),
                    VisitID = table.Column<int>(nullable: true),
                    VisitDate = table.Column<DateTime>(nullable: true),
                    PNCRegisterNumber = table.Column<string>(nullable: true),
                    PNCVisitNo = table.Column<int>(nullable: true),
                    DeliveryDate = table.Column<DateTime>(nullable: true),
                    ModeOfDelivery = table.Column<string>(nullable: true),
                    PlaceOfDelivery = table.Column<string>(nullable: true),
                    Height = table.Column<decimal>(nullable: true),
                    Weight = table.Column<decimal>(nullable: true),
                    Temp = table.Column<decimal>(nullable: true),
                    PulseRate = table.Column<int>(nullable: true),
                    RespiratoryRate = table.Column<int>(nullable: true),
                    OxygenSaturation = table.Column<decimal>(nullable: true),
                    MUAC = table.Column<int>(nullable: true),
                    BP = table.Column<int>(nullable: true),
                    BreastExam = table.Column<string>(nullable: true),
                    GeneralCondition = table.Column<string>(nullable: true),
                    HasPallor = table.Column<string>(nullable: true),
                    Pallor = table.Column<string>(nullable: true),
                    Breast = table.Column<string>(nullable: true),
                    PPH = table.Column<string>(nullable: true),
                    CSScar = table.Column<string>(nullable: true),
                    UterusInvolution = table.Column<string>(nullable: true),
                    Episiotomy = table.Column<string>(nullable: true),
                    Lochia = table.Column<string>(nullable: true),
                    Fistula = table.Column<string>(nullable: true),
                    MaternalComplications = table.Column<string>(nullable: true),
                    TBScreening = table.Column<string>(nullable: true),
                    ClientScreenedCACx = table.Column<string>(nullable: true),
                    CACxScreenMethod = table.Column<string>(nullable: true),
                    CACxScreenResults = table.Column<string>(nullable: true),
                    PriorHIVStatus = table.Column<string>(nullable: true),
                    HIVTestingDone = table.Column<string>(nullable: true),
                    HIVTest1 = table.Column<string>(nullable: true),
                    HIVTest1Result = table.Column<string>(nullable: true),
                    HIVTest2 = table.Column<string>(nullable: true),
                    HIVTest2Result = table.Column<string>(nullable: true),
                    HIVTestFinalResult = table.Column<string>(nullable: true),
                    InfantProphylaxisGiven = table.Column<string>(nullable: true),
                    MotherProphylaxisGiven = table.Column<string>(nullable: true),
                    CoupleCounselled = table.Column<string>(nullable: true),
                    PartnerHIVTestingPNC = table.Column<string>(nullable: true),
                    PartnerHIVResultPNC = table.Column<string>(nullable: true),
                    CounselledOnFP = table.Column<string>(nullable: true),
                    ReceivedFP = table.Column<string>(nullable: true),
                    HaematinicsGiven = table.Column<string>(nullable: true),
                    DeliveryOutcome = table.Column<string>(nullable: true),
                    BabyConditon = table.Column<string>(nullable: true),
                    BabyFeeding = table.Column<string>(nullable: true),
                    UmbilicalCord = table.Column<string>(nullable: true),
                    Immunization = table.Column<string>(nullable: true),
                    InfantFeeding = table.Column<string>(nullable: true),
                    PreventiveServices = table.Column<string>(nullable: true),
                    ReferredFrom = table.Column<string>(nullable: true),
                    ReferredTo = table.Column<string>(nullable: true),
                    NextAppointmentPNC = table.Column<DateTime>(nullable: true),
                    ClinicalNotes = table.Column<string>(nullable: true),
                    Date_Created = table.Column<DateTime>(nullable: true),
                    Date_Last_Modified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PncVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PncVisits_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cargoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RefId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Items = table.Column<string>(nullable: true),
                    ManifestId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargoes_Manifests_ManifestId",
                        column: x => x.ManifestId,
                        principalTable: "Manifests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AncVisits_FacilityId",
                table: "AncVisits",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargoes_ManifestId",
                table: "Cargoes",
                column: "ManifestId");

            migrationBuilder.CreateIndex(
                name: "IX_CwcEnrolments_FacilityId",
                table: "CwcEnrolments",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_CwcVisits_FacilityId",
                table: "CwcVisits",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_MasterFacilityId",
                table: "Facilities",
                column: "MasterFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Heis_FacilityId",
                table: "Heis",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Manifests_FacilityId",
                table: "Manifests",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MatVisits_FacilityId",
                table: "MatVisits",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MnchArts_FacilityId",
                table: "MnchArts",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MnchEnrolments_FacilityId",
                table: "MnchEnrolments",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MnchLabs_FacilityId",
                table: "MnchLabs",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MnchPatients_FacilityId",
                table: "MnchPatients",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherBabyPairs_FacilityId",
                table: "MotherBabyPairs",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PncVisits_FacilityId",
                table: "PncVisits",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_DocketId",
                table: "Subscribers",
                column: "DocketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AncVisits");

            migrationBuilder.DropTable(
                name: "Cargoes");

            migrationBuilder.DropTable(
                name: "CwcEnrolments");

            migrationBuilder.DropTable(
                name: "CwcVisits");

            migrationBuilder.DropTable(
                name: "Heis");

            migrationBuilder.DropTable(
                name: "MatVisits");

            migrationBuilder.DropTable(
                name: "MnchArts");

            migrationBuilder.DropTable(
                name: "MnchEnrolments");

            migrationBuilder.DropTable(
                name: "MnchLabs");

            migrationBuilder.DropTable(
                name: "MnchPatients");

            migrationBuilder.DropTable(
                name: "MotherBabyPairs");

            migrationBuilder.DropTable(
                name: "PncVisits");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "Manifests");

            migrationBuilder.DropTable(
                name: "Dockets");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "MasterFacilities");
        }
    }
}
