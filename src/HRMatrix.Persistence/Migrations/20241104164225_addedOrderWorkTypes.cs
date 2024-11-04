using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedOrderWorkTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileWorkType_UserProfiles_UserProfileId",
                table: "UserProfileWorkType");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileWorkType_WorkTypes_WorkTypeId",
                table: "UserProfileWorkType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfileWorkType",
                table: "UserProfileWorkType");

            migrationBuilder.RenameTable(
                name: "UserProfileWorkType",
                newName: "UserProfileWorkTypes");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfileWorkType_WorkTypeId",
                table: "UserProfileWorkTypes",
                newName: "IX_UserProfileWorkTypes_WorkTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfileWorkType_UserProfileId",
                table: "UserProfileWorkTypes",
                newName: "IX_UserProfileWorkTypes_UserProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfileWorkTypes",
                table: "UserProfileWorkTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OrderWorkTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    WorkTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderWorkTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderWorkTypes_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderWorkTypes_WorkTypes_WorkTypeId",
                        column: x => x.WorkTypeId,
                        principalTable: "WorkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "978ba10f-291e-4e8c-ba2a-8d57f3f24dfa", "AQAAAAIAAYagAAAAEBTsyoSdpZ43OlI58DKrybZZVeBEMkiFq9p14oq7yQs7AdFxjUPpDIpeIQSrtG5HJw==", "527a34dc-ac3c-4951-b05d-8f8de37604cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dd98af0-2d5e-4303-8e6a-abc27343fb8b", "AQAAAAIAAYagAAAAEHhtjLYRF7I370sHWwn1uMAboDAq83McE2wnHKq0r5D2JMahDZKBxPr7Y1cwzHXMAA==", "f7228a57-c604-45b9-8cc2-a2606fc348f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb8aa098-c99f-4dc9-9140-8e8950c0feea", "AQAAAAIAAYagAAAAEAu4Un8bLhyGjIA9TUQCj0M51jvW3dadDp12pmoRKi2n7oOo/mlAB/JCu8cBZcHQhw==", "4eb5c231-9f88-4227-9193-87bd73c4a5de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b40a617-8723-4296-a567-cb3861b27c58", "AQAAAAIAAYagAAAAEKQJyBpoboRWA++af/v3I9gvPRSxjoiCjCuDAZQ/CRfvCvtoE+Vbo8fmp1Tg7prOww==", "d2628030-af08-4b0e-8bfa-8e0e6d5adc99" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderWorkTypes_OrderId",
                table: "OrderWorkTypes",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderWorkTypes_WorkTypeId",
                table: "OrderWorkTypes",
                column: "WorkTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileWorkTypes_UserProfiles_UserProfileId",
                table: "UserProfileWorkTypes",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileWorkTypes_WorkTypes_WorkTypeId",
                table: "UserProfileWorkTypes",
                column: "WorkTypeId",
                principalTable: "WorkTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileWorkTypes_UserProfiles_UserProfileId",
                table: "UserProfileWorkTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileWorkTypes_WorkTypes_WorkTypeId",
                table: "UserProfileWorkTypes");

            migrationBuilder.DropTable(
                name: "OrderWorkTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfileWorkTypes",
                table: "UserProfileWorkTypes");

            migrationBuilder.RenameTable(
                name: "UserProfileWorkTypes",
                newName: "UserProfileWorkType");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfileWorkTypes_WorkTypeId",
                table: "UserProfileWorkType",
                newName: "IX_UserProfileWorkType_WorkTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfileWorkTypes_UserProfileId",
                table: "UserProfileWorkType",
                newName: "IX_UserProfileWorkType_UserProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfileWorkType",
                table: "UserProfileWorkType",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileWorkType_UserProfiles_UserProfileId",
                table: "UserProfileWorkType",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileWorkType_WorkTypes_WorkTypeId",
                table: "UserProfileWorkType",
                column: "WorkTypeId",
                principalTable: "WorkTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
