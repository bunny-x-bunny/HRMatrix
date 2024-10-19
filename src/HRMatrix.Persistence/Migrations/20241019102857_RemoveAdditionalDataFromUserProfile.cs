using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAdditionalDataFromUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalCompetences",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "AdditionalSkills",
                table: "UserProfiles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97082b23-0c0a-4e6e-839a-f2a35721daa7", "AQAAAAIAAYagAAAAEDG/jydIJadNkrxRcnaNEThp0ifgv0KvBBb7a8MGC6SU8OHe+5OOH1S47eMsRLf8TQ==", "39ffb000-9a4e-45af-b8b6-c49d351f0267" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09ad85b1-2444-4089-9cc0-811f1d84cee0", "AQAAAAIAAYagAAAAEK129H5wJ/DsYCZP6VnAZdU+BLxvoUK5VqIBFJaO9p82ebFNLGgQEoKoVkXLh/fdPQ==", "ca104a18-e4a7-4f8f-adbf-93b5b4bd8618" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21960ebb-9a55-4e52-b5dd-f9e0fc711ded", "AQAAAAIAAYagAAAAEGpT8vsVPuCxlXl75S3nenCvkpeXwjN1H4yBMdjrl9GQ0cdl3+OCgs1XOqXx8ZOm9w==", "b9c96d83-8a8f-4863-982f-d4d6d48de8e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23f27184-1846-4427-8076-4a6cadb1c769", "AQAAAAIAAYagAAAAEHi3SsBby13YyRSVpwhYrhB+Sr1mkW3fQKCMZzoLCbhiI1PLgiLijaT03qqcJQoC+A==", "5bcb7f3c-87c4-41c8-9121-d01b8e2b27c1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalCompetences",
                table: "UserProfiles",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalSkills",
                table: "UserProfiles",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2e564d5-1690-430e-b523-3bf0fb7cce88", "AQAAAAIAAYagAAAAEGPnCm9NsKGtd7tnte6LRbkhQIioWz1mUE1pUQxuEBFfSGoE2sTex75KDCxlC1ra8w==", "cce93891-f06d-4efc-a2f0-36350ba20a5c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "420e1f6f-4090-48f5-b52e-50ac9f2081fb", "AQAAAAIAAYagAAAAEOu2DdkjkK9z+slQsg1GB50ivJA4DJOabj8hTfEeLTzj9EQDZ1GvpDapH3jrpyKQZA==", "81f25803-2e90-4f28-9fd5-38ece42fac23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70cd7a4e-e7a8-44e6-99c5-ee5a44ed523f", "AQAAAAIAAYagAAAAEA/XK/hZ8c4+ycTQlyY3V2SgSNer2F4HbFPJCDvRoNjrtpofpBDJGlO8LyvT/bnyFw==", "ed455a1e-a3c6-4db3-9fc8-fb244e9ca8f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db00d3be-e47d-496d-975d-ff820eaf718e", "AQAAAAIAAYagAAAAEEoP3wE70mrEjdY6X54PyWwPKnIFY1qiVFhckfu2YMJQadG8M/bxGwpZwRZpuK99qw==", "d017d803-fc8e-4498-b6df-354f2cd6ca29" });
        }
    }
}
