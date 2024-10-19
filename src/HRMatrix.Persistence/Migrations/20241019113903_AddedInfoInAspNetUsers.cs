using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedInfoInAspNetUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58ca0117-b098-4090-8e02-9ecaa5e545fa", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe", "AQAAAAIAAYagAAAAEMaxK9nmg+rdAjefF2HAlmD/AMMYzD45DALrBXg6Z+qVBWsh5Hh5VntFoosv8Na+2g==", "f80a438d-68dc-4b11-b67a-e0e8eb02b95b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f713f67-4def-4169-9770-6a952ca3aa0b", new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Doe", "AQAAAAIAAYagAAAAEPdH3q3cb11CMkuZMyASH8YPdjHoGjQxOP36bQXLzGZiP57ZoVGzBka9fC79nMB2Jg==", "da485d61-9d9f-4650-b5e8-dd49debe380c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69fd2e34-3fce-46e2-b427-72ebe0f5ae70", new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice", "Smith", "AQAAAAIAAYagAAAAELOdv+IacgACrVr1ESixIFNj43UJjJ62a9XJf8oAKdFXaQJxZd+fhQff7Ibk3hv8RQ==", "58ac0628-bc9e-4752-a689-df134795a8e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2c61425-54a1-40f7-b0b2-52d5c3bb2835", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob", "Johnson", "AQAAAAIAAYagAAAAEJ9uz/JV+TNvS6eOHDi78EbQFdr125DetKYDv9pN/l19AT7NlB3tgvwv7/ZtNEvUpw==", "41984129-6a14-471b-b58c-60016c2911c6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54958ca9-85b7-4ed0-8ed0-7761121248a8", "AQAAAAIAAYagAAAAEEsxrB2sI4SIMcQPsXRjdpGLczKiYNEdyhf9GYovkJIQohpMBbaWtyjHokiwIT8hNw==", "5f0b0691-9b21-485e-bf33-036b5446120f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aac2310b-c958-40c6-a667-9c24ea57d3c3", "AQAAAAIAAYagAAAAELb2aze2ACETLEyICfOZvAZtx37GchmUUoT8QRVKzbP8FS/HdnYqEECMbPj2XlvFgw==", "d4f41a25-33c2-4fea-8800-916334313b89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05a079b1-84ef-41ff-99c0-85e3355a2f4b", "AQAAAAIAAYagAAAAEJW8ShAY3vPsFWq6rPgKhjs0ph88iQDnX6tyAwlBVYt+WgTCc/Z1jNyUXyRRoI1C3Q==", "57688798-908e-48f4-aa2a-70fa2b4511df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "066cc268-77af-455c-9a61-08966067f1d1", "AQAAAAIAAYagAAAAELOWwYKiyGt9plxT7zsMk4ThcDAepw8b0B1/DjygP5y3XAKktdibJ/VQNrXXxUzYog==", "39cb98c1-35c4-496f-bd45-fa377f188c56" });
        }
    }
}
