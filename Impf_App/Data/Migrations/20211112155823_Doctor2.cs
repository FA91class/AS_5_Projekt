using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Impf_App.Data.Migrations
{
    public partial class Doctor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationDoses_Doctors_DoctorId",
                table: "VaccinationDoses");

            migrationBuilder.DropIndex(
                name: "IX_VaccinationDoses_DoctorId",
                table: "VaccinationDoses");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "VaccinationDoses");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Doctors",
                newName: "P_DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationDoses_F_DoctorP_DoctorId",
                table: "VaccinationDoses",
                column: "F_DoctorP_DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationDoses_Doctors_F_DoctorP_DoctorId",
                table: "VaccinationDoses",
                column: "F_DoctorP_DoctorId",
                principalTable: "Doctors",
                principalColumn: "P_DoctorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationDoses_Doctors_F_DoctorP_DoctorId",
                table: "VaccinationDoses");

            migrationBuilder.DropIndex(
                name: "IX_VaccinationDoses_F_DoctorP_DoctorId",
                table: "VaccinationDoses");

            migrationBuilder.RenameColumn(
                name: "P_DoctorId",
                table: "Doctors",
                newName: "Id");

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                table: "VaccinationDoses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationDoses_DoctorId",
                table: "VaccinationDoses",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationDoses_Doctors_DoctorId",
                table: "VaccinationDoses",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
