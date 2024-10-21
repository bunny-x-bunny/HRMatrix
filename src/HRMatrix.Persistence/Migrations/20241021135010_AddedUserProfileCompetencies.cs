using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserProfileCompetencies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfileCompetencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProfileId = table.Column<int>(type: "int", nullable: false),
                    CompetencyId = table.Column<int>(type: "int", nullable: false),
                    ProficiencyLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileCompetencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfileCompetencies_Competencies_CompetencyId",
                        column: x => x.CompetencyId,
                        principalTable: "Competencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileCompetencies_UserProfiles_UserProfileId",
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
                values: new object[] { "bd89d31a-cbea-4258-a391-e5f39c94040b", "AQAAAAIAAYagAAAAEPQXvQsIOVyLsolpiAsRVL9TuRpG3pypjjc8XsY/2jwX2SgveldNBvqZWxX8n+leUQ==", "2fddd168-eb0e-4a3f-b3f0-e2ae9cd621b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74a02921-0c6b-48c4-808b-b8a3d972869a", "AQAAAAIAAYagAAAAENP+f24wYPyxtvKMs613fiZXV5f8LIbCsDbCNBOKspwfFYXuEVua06xSs1gsxL5fPw==", "617bd115-9f0e-47bb-a0c9-d8be0d367ff6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e13c1ba-5429-4dae-8e31-62504cf0a25c", "AQAAAAIAAYagAAAAEMGJgHnDr+9SbCVUPYhMVjPjdkOW+MaL3tzcmhTeFvMbYaF934aLSE4qgzKAST3XOw==", "b1462a09-d7d7-42e4-9c2b-2300244d27e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9dbf6ec-6fe2-4506-b706-5564f6e1d2fd", "AQAAAAIAAYagAAAAELApYkTrg9mAn7z9QKeUVErhV4M9bX8oWtWYjki/AvZaoTPx3EkuZUNqHTiQDAJvQg==", "9500cf96-bd1c-4a28-b3db-f6a4cbbcddf7" });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileCompetencies_CompetencyId",
                table: "UserProfileCompetencies",
                column: "CompetencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileCompetencies_UserProfileId",
                table: "UserProfileCompetencies",
                column: "UserProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfileCompetencies");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e367dcdc-5018-45de-977d-758a8a083eba", "AQAAAAIAAYagAAAAEGvyhTTwtJDIz837Q9dLdX+OJgnEdUtfGk9jGZpPoBrN9SRvyFC2aTUC7Ma2xMWBlg==", "caf56133-cda2-4d10-b6d1-8c292add0691" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ef734d7-8c38-4154-bfcb-e1d62cf67de0", "AQAAAAIAAYagAAAAEJXsieMkVfFFFB92XzYK5dF9GSN129cvgLIF10cMgBYUyFS/no8Ax0d8+ZZ93zLIlw==", "ce8658bb-90cf-4af2-b96e-33caa2698995" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c04ad40-a0ea-446d-b722-e98340d062c3", "AQAAAAIAAYagAAAAECBX/yphznbD/hi6LLgPQZrMV+/s1M/rgcHxeScUN9z0+7ndvhCxQ1M9+fY0viXELQ==", "9bdcb462-efbd-489b-830e-243432fb98b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f14cd93-f921-41e3-9c5d-93ec33980ba4", "AQAAAAIAAYagAAAAEGkSvBPMJb/H1NTp8/lhxnHiTdas83HY0om5FGWWiVzHLepPERfGZsn6LTWo0mngbg==", "ff0dd533-e935-49b3-a774-51fc8e3e47c0" });
        }
    }
}
