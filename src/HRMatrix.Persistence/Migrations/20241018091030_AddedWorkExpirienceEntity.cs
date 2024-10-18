using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedWorkExpirienceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProfileId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Achievements = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkExperiences_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7bfa207-5781-4ad1-ad08-f12a45dd1a3e", "AQAAAAIAAYagAAAAEEAzvjASasbu7YfPSOiHtzQRxjygDDHJi37KN/Qk6HwJtM5Sy6iyT5e+M7BlkvQQ7g==", "3887a3be-cd0f-4a69-8824-57ab1683861b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a3bd288-9cb4-4763-8c95-6bac62975c8f", "AQAAAAIAAYagAAAAECb1YxbVPyInn2Hkbcs7NMewZ2Iar2Oqj2gvn43BdLm5I6t6ukNp0i+PN0dAt70NNA==", "916114f5-11dc-4599-8a19-c867e4fa489f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7fbddd0-7281-4488-a5c7-7cd32b5240ef", "AQAAAAIAAYagAAAAEDnmsogveAJm6bDCQYk1F6tvirneJ2BgwPxj8Mofm000VdiynK9HldMbbo96lR/kkA==", "204af449-b9ea-402e-a1b2-1a7c9895b4a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fa25f0e-7f3e-4c6e-931b-5d12fb599312", "AQAAAAIAAYagAAAAEEAn0+Ecn9++tuW3A8/ARz+GyyV4Jshnu5e7Weny78kcvcEdkjtB5kx2pBRjYefBOg==", "3d301734-3657-4f32-a29e-ece1e55cdac1" });

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_UserProfileId",
                table: "WorkExperiences",
                column: "UserProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkExperiences");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a40cdd53-7b9e-494b-8590-57eead485ada", "AQAAAAIAAYagAAAAEC4yCkAJazEqTRtCMfPpQ7iLKRfLnisvyolkQAbHzW1gwx9YwNjxDaVXztnV5Ck+gA==", "228d7250-a68b-4b29-98a6-e3f02584ea53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e12823c0-12a2-4f83-848b-05986c5de488", "AQAAAAIAAYagAAAAEAYYf727dOofCfu2xvEb7rYk6YKO/GUlySWtyZ7oHmwdv0X4Bsg4+w3D7MBPtFyhLg==", "140a5205-ce32-4412-beac-8ad9690a8a1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae0d526f-6cbc-4ea7-8c55-1bdefce4a07e", "AQAAAAIAAYagAAAAEE4jpil6Zq08Xm8/g9nyWRxLuIgVXZLJ2Xc7pyItfsqA8Rwr5ZAXVCwXyU+YlOqAjg==", "0c88a5f1-b64a-4dcf-acc9-1e18758c141a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b4082b5-780b-40eb-8899-ddee553f0843", "AQAAAAIAAYagAAAAEG0xGrw/DDcGeYgfgfHHAZ9NkmOJasdmy4JhPRUjaiWATZmsd5501/MDwIy5XxeGDw==", "69bbc581-54c5-4930-94cb-3260cdf70501" });
        }
    }
}
