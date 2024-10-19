using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedNullableToVideoAndPhotoPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VideoPath",
                table: "UserProfiles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePhotoPath",
                table: "UserProfiles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VideoPath",
                table: "UserProfiles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePhotoPath",
                table: "UserProfiles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

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
    }
}
