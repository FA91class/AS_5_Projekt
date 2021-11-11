using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Impf_App.Data.Migrations
{
    public partial class UpdatingVaccines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Insurances_PF_InsuranceP_InssuranceId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationDoses_Insurances_F_InsuranceP_InssuranceId",
                table: "VaccinationDoses");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationDoses_Patients_F_PatientP_InsuranceNr",
                table: "VaccinationDoses");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationDoses_Vaccines_F_VaccineP_VaccineId",
                table: "VaccinationDoses");

            migrationBuilder.DropIndex(
                name: "IX_VaccinationDoses_F_InsuranceP_InssuranceId",
                table: "VaccinationDoses");

            migrationBuilder.DropColumn(
                name: "F_InsuranceP_InssuranceId",
                table: "VaccinationDoses");

            migrationBuilder.AlterColumn<Guid>(
                name: "F_VaccineP_VaccineId",
                table: "VaccinationDoses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "F_PatientP_InsuranceNr",
                table: "VaccinationDoses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PF_InsuranceP_InssuranceId",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Insurances_PF_InsuranceP_InssuranceId",
                table: "Patients",
                column: "PF_InsuranceP_InssuranceId",
                principalTable: "Insurances",
                principalColumn: "P_InssuranceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationDoses_Patients_F_PatientP_InsuranceNr",
                table: "VaccinationDoses",
                column: "F_PatientP_InsuranceNr",
                principalTable: "Patients",
                principalColumn: "P_InsuranceNr",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationDoses_Vaccines_F_VaccineP_VaccineId",
                table: "VaccinationDoses",
                column: "F_VaccineP_VaccineId",
                principalTable: "Vaccines",
                principalColumn: "P_VaccineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Insurances_PF_InsuranceP_InssuranceId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationDoses_Patients_F_PatientP_InsuranceNr",
                table: "VaccinationDoses");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationDoses_Vaccines_F_VaccineP_VaccineId",
                table: "VaccinationDoses");

            migrationBuilder.AlterColumn<Guid>(
                name: "F_VaccineP_VaccineId",
                table: "VaccinationDoses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "F_PatientP_InsuranceNr",
                table: "VaccinationDoses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "F_InsuranceP_InssuranceId",
                table: "VaccinationDoses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PF_InsuranceP_InssuranceId",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationDoses_F_InsuranceP_InssuranceId",
                table: "VaccinationDoses",
                column: "F_InsuranceP_InssuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Insurances_PF_InsuranceP_InssuranceId",
                table: "Patients",
                column: "PF_InsuranceP_InssuranceId",
                principalTable: "Insurances",
                principalColumn: "P_InssuranceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationDoses_Insurances_F_InsuranceP_InssuranceId",
                table: "VaccinationDoses",
                column: "F_InsuranceP_InssuranceId",
                principalTable: "Insurances",
                principalColumn: "P_InssuranceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationDoses_Patients_F_PatientP_InsuranceNr",
                table: "VaccinationDoses",
                column: "F_PatientP_InsuranceNr",
                principalTable: "Patients",
                principalColumn: "P_InsuranceNr",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationDoses_Vaccines_F_VaccineP_VaccineId",
                table: "VaccinationDoses",
                column: "F_VaccineP_VaccineId",
                principalTable: "Vaccines",
                principalColumn: "P_VaccineId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
