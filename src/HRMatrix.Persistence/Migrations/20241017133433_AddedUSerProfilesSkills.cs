using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedUSerProfilesSkills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfileSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProfileId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    ProficiencyLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfileSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileSkills_UserProfiles_UserProfileId",
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

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileSkills_SkillId",
                table: "UserProfileSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileSkills_UserProfileId",
                table: "UserProfileSkills",
                column: "UserProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfileSkills");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "027ea263-1a38-4f6c-8ef3-d11ef4fbc57c", "AQAAAAIAAYagAAAAEFpGD4LwTxPD7T8nUj/ephe/k9qROVKsRIvl/gZKBxvFedwaLg7fXPMGJQG38Pl6dQ==", "65dc8b61-6f8b-4d10-a80e-99dadc3b34ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9235297-ed59-4b40-a07d-d07844357094", "AQAAAAIAAYagAAAAEJ2bFrfEVlQS4v6o8gsOOhkxi1M7QXrppovIonlgl/gYLLVPSl/JHN6IAPjZFnuEfA==", "b81ac451-2ba5-4f39-8e4a-cfd297e0b267" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e57f989-1a64-4610-9a55-aabb35a077b4", "AQAAAAIAAYagAAAAEDlSoqh63bmVxemPcA3OcjsIrnBxVoJ+TEeZ2AVmcM6TaF9DkC41gMM0geAPhNe9cg==", "c51e6b9c-7eda-4a89-b9f8-e8f922b3e5c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7b6fde4-744c-4028-9bcd-b7577ab82c43", "AQAAAAIAAYagAAAAEGZ6n4h6zRcQuITKznU91xhrn4g5clcIntHYoHqbNsJqFS+Mr5Ar+Fxs7Z5f0LLe2Q==", "d472f82a-599b-49f9-8ece-9815f940d18f" });
        }
    }
}
