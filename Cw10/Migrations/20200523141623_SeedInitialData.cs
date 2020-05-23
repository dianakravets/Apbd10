using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw10.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "kond@gmail.com", "Kondrad", "Nitosz" },
                    { 2, "sikorski@gmail.com", "Mikolaj", "Sikorskij" },
                    { 3, "kk@gmail.com", "Katarzyna", "Kowalska" }
                });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "kaszel", "Thicodin", "w" },
                    { 2, "kaszel", "ACC", "e" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julia", "Kowalska" },
                    { 2, new DateTime(1999, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maciej", "Nowak" }
                });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 2, new DateTime(2020, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 3, new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdPrescription", "IdMedicament", "Details", "Dose", "IdPresMed" },
                values: new object[] { 1, 2, "codzienie", 3, 0 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdPrescription", "IdMedicament", "Details", "Dose", "IdPresMed" },
                values: new object[] { 2, 1, "wiecorem", 2, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdPrescription", "IdMedicament" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdPrescription", "IdMedicament" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1);
        }
    }
}
