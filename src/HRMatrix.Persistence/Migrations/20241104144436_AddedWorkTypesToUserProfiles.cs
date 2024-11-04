using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedWorkTypesToUserProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfileWorkType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProfileId = table.Column<int>(type: "int", nullable: false),
                    WorkTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileWorkType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfileWorkType_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileWorkType_WorkTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3c1e2ff-ef3c-4da2-bd62-5cc28ee94b3d", "AQAAAAIAAYagAAAAEHI3mxfpJvnomhoafri4+RIgLrYMlfPDVg5m6jROSA9O7QwrAZaok7fxDkW3uj3YKA==", "9359d3e0-c5a8-4360-bf69-51c513b1bab5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddd7b0cc-2bd8-4707-98fe-7a54edbb6a61", "AQAAAAIAAYagAAAAENRNCvzY/qwdCZW/KcKkKGfw9r7Zg+5HDujaGMMN5sEYrM18yo6nJTdsMDzkgf4UQg==", "6f6d4052-4c78-4a7d-a167-f4644b3d186d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a39b9978-7c58-431c-a9f8-02ceafb0de5e", "AQAAAAIAAYagAAAAEHbttBAnpYjmCKCruAEJ7BDAHWCpaoz0OsuzoAGbloZc14fELBIdKJ5U9KBBCp45QA==", "03548514-f6c0-4e11-8aaf-bacc16a846f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25eb111b-561c-4612-a626-d6b36e592ff9", "AQAAAAIAAYagAAAAEDqHivwC0DRMKZbZ0CHLiB/eJpQ3Myx5HiCWcWlS/pmzlxxALIgyvo5aDN4tYayN5w==", "f9ae169f-f221-4608-81a6-32acb7db467d" });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileWorkType_UserProfileId",
                table: "UserProfileWorkType",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileWorkType_WorkTypeId",
                table: "UserProfileWorkType",
                column: "WorkTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfileWorkType");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "397b34b5-1091-45f5-9b88-1053e1abbcff", "AQAAAAIAAYagAAAAELtDpt4uzzkjo8U2nr9zKNoYDVwDnl/2mDFofw5esAvuMQVf8FmcXChxZybBouqRHw==", "386d5d00-f632-40f3-8d34-d57d708cfa38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c7d5003-8055-48a1-ba0d-2805e0efb29c", "AQAAAAIAAYagAAAAEHPTYwhHtc29eZ7YkQdc28brYttP0eDSQKX9vPYDi422RYHQD1WnnlAifGXpEKFtjg==", "b9c7109c-0a92-4981-925e-5a43b0fae3b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0f8589b-6d23-479a-9008-c484240476bb", "AQAAAAIAAYagAAAAEJ3WzbXOnpKpIu/FmuTFCYBRNQl0KRKpLqxgEMUnDEcX+i+OvXPj39Mcv+mZPSPZVg==", "a2021a58-4b86-4cf8-b511-52af8a344854" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2b904b9-0cb7-4ec2-a0ac-4b8d42f49cf0", "AQAAAAIAAYagAAAAEGWmdOm5svcTaQP1+bZnJYYbQ+zXH0ZBsq3Bu2TFAwePDwdvGDwQLV2KhiLhRVFqOA==", "2aae08e6-b6a6-4e90-be8d-ed797e9b15a8" });
        }
    }
}
