using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedRoleRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "role_requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_role_requests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "7857895f-eaa0-4253-8689-51fc02bd4863", "AQAAAAIAAYagAAAAEDRCPp/8Vk9z/c7hKzn8UiMUpJZNkL2S3s2nVaHPJrAKrPrYDqqKM1EGK4Yu4u+HSw==", "1234567890", true, "8cef086e-4ce1-4b2e-b208-eb411bb4d3eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "249b0dda-a58a-41a8-8390-126d26966d7a", "AQAAAAIAAYagAAAAEHrO2amjAR3OtCW+3FoA6mxwB21Jcjkhfz6DrafLFLdtF6OrzYqEOsk4i96CJ2QCNg==", "0987654321", true, "5141792e-aa97-4ba2-b79e-0f9bb09ac234" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "5710fd6f-c60b-4272-bd70-8c4fe07ab9a6", "AQAAAAIAAYagAAAAEH5WMv93YLDa7ocLCyMXKDRRS1nXWnCrDZGTZeaibFJe4bJbTH00OqHEfUE0nmnEDw==", "5551234567", true, "f4227d0f-ed5d-4f95-ac9b-22be1c451078" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "549a7034-9384-41ce-95db-f3e9385ca46e", "AQAAAAIAAYagAAAAEEY46vexG5l/OeMTxmBkdXlieQ/iqg5nmUAk1bQWIEMTVXYZ31prS0fEAsLeSX8Vbg==", "5559876543", true, "18c68d0e-5651-44f6-98a2-bac886b6aa88" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhoneNumber",
                table: "AspNetUsers",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_role_requests_UserId",
                table: "role_requests",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "role_requests");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "cdeff6dc-3a3e-4231-8d8a-fabbd77051cc", "AQAAAAIAAYagAAAAEFYK5Ejh6ITf6tL6GO2D27IlKyFHNfXwdwrHhQ94zyTbfnGE7Bo8AgzxgA84dbvaWw==", null, false, "e3be7c45-a1e2-4b44-9d35-88f6fa1f3103" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "e7c2b5c0-dc2e-46d9-ac23-33518bb0380b", "AQAAAAIAAYagAAAAENiQlCsKDte60gZLHvcPyjOlRl62vIuN29SZPMndlPeV6+z75d7zwD5tIh6f4HRyyA==", null, false, "352fd5ed-0198-4c96-86dc-76a80a894e99" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "978266d6-a2b6-4fda-ac3c-e2d1d422b319", "AQAAAAIAAYagAAAAEM6l42KmTRKofrXm9b9s4YdH19/xxApefUuveLSFCWM0KaGODJj7PXskDoI8teCMyg==", null, false, "69b59483-8c03-495e-9f19-67920aa90956" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "075f4036-af06-4c24-999e-b0aed6ddc4d0", "AQAAAAIAAYagAAAAEG0hCF3jfSu8kAtbh+T+pkbAixL0Crg2CG4BuRVMSXRxMQ9Ve52LTEdE1zVBIiBAwQ==", null, false, "6f42158c-e8db-4986-9feb-dcb95b11e1bd" });
        }
    }
}
