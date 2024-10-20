using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedNullableToApplcationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c0419fb-7ad3-4840-9327-a942702637e5", "AQAAAAIAAYagAAAAEB2MVy3Pr3vQutdeTXLaRRiVAbJZlwgtiR5gPtupc1BqG2DwGbzJ2KEydaq18CiANw==", "04cc3026-0626-47a1-a663-c3e4f1278faf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85e49879-95c2-4a35-9ac8-9db609d07bb1", "AQAAAAIAAYagAAAAECrFxCjP0FM8NLw0pPk16Yw7omCVD0xC7rmGRSEgymqEdIyxHWF4qsZNw/9lr3wx2A==", "85c764f3-8377-4087-b14b-acfd3a515c94" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4e58987-c7cf-4743-817f-4272bc349b71", "AQAAAAIAAYagAAAAEB0pBMI7h6xRi/7/nIRt9LCoryBEu8DDciCQ7Ui96EjLtj9KTQZ7SYBdQUHmftG6sQ==", "b92703c2-7b27-47a4-bd2b-a2ccbfaa7dc9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2932e163-89ab-4f33-bcea-996d967fb1dd", "AQAAAAIAAYagAAAAEAHYKAjgupXV9WDp3s3YonPxFRxaIdJ5Aha1izsg/tlwufxUExquZPPnK1A17gRRPQ==", "f108f115-0d23-490b-a1f8-7361e4121644" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58ca0117-b098-4090-8e02-9ecaa5e545fa", "AQAAAAIAAYagAAAAEMaxK9nmg+rdAjefF2HAlmD/AMMYzD45DALrBXg6Z+qVBWsh5Hh5VntFoosv8Na+2g==", "f80a438d-68dc-4b11-b67a-e0e8eb02b95b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f713f67-4def-4169-9770-6a952ca3aa0b", "AQAAAAIAAYagAAAAEPdH3q3cb11CMkuZMyASH8YPdjHoGjQxOP36bQXLzGZiP57ZoVGzBka9fC79nMB2Jg==", "da485d61-9d9f-4650-b5e8-dd49debe380c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69fd2e34-3fce-46e2-b427-72ebe0f5ae70", "AQAAAAIAAYagAAAAELOdv+IacgACrVr1ESixIFNj43UJjJ62a9XJf8oAKdFXaQJxZd+fhQff7Ibk3hv8RQ==", "58ac0628-bc9e-4752-a689-df134795a8e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2c61425-54a1-40f7-b0b2-52d5c3bb2835", "AQAAAAIAAYagAAAAEJ9uz/JV+TNvS6eOHDi78EbQFdr125DetKYDv9pN/l19AT7NlB3tgvwv7/ZtNEvUpw==", "41984129-6a14-471b-b58c-60016c2911c6" });
        }
    }
}
