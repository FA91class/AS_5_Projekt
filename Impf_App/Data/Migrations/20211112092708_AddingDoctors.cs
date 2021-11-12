using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Impf_App.Data.Migrations
{
    public partial class AddingDoctors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Doctor",
                table: "VaccinationDoses");

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                table: "VaccinationDoses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationDoses_Doctors_DoctorId",
                table: "VaccinationDoses");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_VaccinationDoses_DoctorId",
                table: "VaccinationDoses");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "VaccinationDoses");

            migrationBuilder.AddColumn<string>(
                name: "Doctor",
                table: "VaccinationDoses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
