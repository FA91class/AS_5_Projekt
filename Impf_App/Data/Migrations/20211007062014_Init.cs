using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Impf_App.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    P_InssuranceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdrNmbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PLZ = table.Column<int>(type: "int", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.P_InssuranceId);
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    P_VaccineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfApproval = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.P_VaccineId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    P_InsuranceNr = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PF_InsuranceP_InssuranceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirtHDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdrNmbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PLZ = table.Column<int>(type: "int", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.P_InsuranceNr);
                    table.ForeignKey(
                        name: "FK_Patients_Insurances_PF_InsuranceP_InssuranceId",
                        column: x => x.PF_InsuranceP_InssuranceId,
                        principalTable: "Insurances",
                        principalColumn: "P_InssuranceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationDoses",
                columns: table => new
                {
                    P_Dosis_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    F_VaccineP_VaccineId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    F_PatientP_InsuranceNr = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    F_InsuranceP_InssuranceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VaccinationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doctor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationDoses", x => x.P_Dosis_Id);
                    table.ForeignKey(
                        name: "FK_VaccinationDoses_Insurances_F_InsuranceP_InssuranceId",
                        column: x => x.F_InsuranceP_InssuranceId,
                        principalTable: "Insurances",
                        principalColumn: "P_InssuranceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaccinationDoses_Patients_F_PatientP_InsuranceNr",
                        column: x => x.F_PatientP_InsuranceNr,
                        principalTable: "Patients",
                        principalColumn: "P_InsuranceNr",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaccinationDoses_Vaccines_F_VaccineP_VaccineId",
                        column: x => x.F_VaccineP_VaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "P_VaccineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PF_InsuranceP_InssuranceId",
                table: "Patients",
                column: "PF_InsuranceP_InssuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationDoses_F_InsuranceP_InssuranceId",
                table: "VaccinationDoses",
                column: "F_InsuranceP_InssuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationDoses_F_PatientP_InsuranceNr",
                table: "VaccinationDoses",
                column: "F_PatientP_InsuranceNr");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationDoses_F_VaccineP_VaccineId",
                table: "VaccinationDoses",
                column: "F_VaccineP_VaccineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccinationDoses");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "Insurances");
        }
    }
}
