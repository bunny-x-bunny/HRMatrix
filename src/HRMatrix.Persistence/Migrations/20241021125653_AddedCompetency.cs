using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompetency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompetencyTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CompetencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetencyTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetencyTranslations_Competencies_CompetencyId",
                        column: x => x.CompetencyId,
                        principalTable: "Competencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Competencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Эффективная коммуникация" },
                    { 2, "Клиентоориентированность" },
                    { 3, "Умение работать в команде" },
                    { 4, "Ориентация на результат" },
                    { 5, "Негативный настрой (пессимизм)" },
                    { 6, "Равнодушие" },
                    { 7, "Лицемерие" },
                    { 8, "Лидерство" },
                    { 9, "Надежность / Стабильность" },
                    { 10, "Развитие бизнеса / Партнерство" },
                    { 11, "Креативное мышление" },
                    { 12, "Стратегическое мышление" },
                    { 13, "Самоорганизация" }
                });

            migrationBuilder.InsertData(
                table: "CompetencyTranslations",
                columns: new[] { "Id", "CompetencyId", "LanguageCode", "Name" },
                values: new object[,]
                {
                    { 1, 1, "ru-RU", "Эффективная коммуникация" },
                    { 2, 1, "en-US", "Effective Communication" },
                    { 3, 1, "ky-KG", "Натыйжалуу баарлашуу" },
                    { 4, 2, "ru-RU", "Клиентоориентированность" },
                    { 5, 2, "en-US", "Customer Focus" },
                    { 6, 2, "ky-KG", "Кардарга багытталуу" },
                    { 7, 3, "ru-RU", "Умение работать в команде" },
                    { 8, 3, "en-US", "Teamwork" },
                    { 9, 3, "ky-KG", "Командалык иш" },
                    { 10, 4, "ru-RU", "Ориентация на результат" },
                    { 11, 4, "en-US", "Result Orientation" },
                    { 12, 4, "ky-KG", "Жыйынтыкка багытталуу" },
                    { 13, 5, "ru-RU", "Негативный настрой (пессимизм)" },
                    { 14, 5, "en-US", "Negative Attitude (Pessimism)" },
                    { 15, 5, "ky-KG", "Терс маанай (пессимизм)" },
                    { 16, 6, "ru-RU", "Равнодушие" },
                    { 17, 6, "en-US", "Indifference" },
                    { 18, 6, "ky-KG", "Кайдыгерлик" },
                    { 19, 7, "ru-RU", "Лицемерие" },
                    { 20, 7, "en-US", "Hypocrisy" },
                    { 21, 7, "ky-KG", "Экөө сүйлөөчүлүк" },
                    { 22, 8, "ru-RU", "Лидерство" },
                    { 23, 8, "en-US", "Leadership" },
                    { 24, 8, "ky-KG", "Лидерлик" },
                    { 25, 9, "ru-RU", "Надежность / Стабильность" },
                    { 26, 9, "en-US", "Reliability / Stability" },
                    { 27, 9, "ky-KG", "Ишенимдүүлүк / Туруктуулук" },
                    { 28, 10, "ru-RU", "Развитие бизнеса / Партнерство" },
                    { 29, 10, "en-US", "Business Development / Partnership" },
                    { 30, 10, "ky-KG", "Бизнес өнүктүрүү / Өнөктөш" },
                    { 31, 11, "ru-RU", "Креативное мышление" },
                    { 32, 11, "en-US", "Creative Thinking" },
                    { 33, 11, "ky-KG", "Креативдүү ой жүгүртүү" },
                    { 34, 12, "ru-RU", "Стратегическое мышление" },
                    { 35, 12, "en-US", "Strategic Thinking" },
                    { 36, 12, "ky-KG", "Стратегиялык ой жүгүртүү" },
                    { 37, 13, "ru-RU", "Самоорганизация" },
                    { 38, 13, "en-US", "Self-Organization" },
                    { 39, 13, "ky-KG", "Өзүн-өзү уюштуруу" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetencyTranslations_CompetencyId",
                table: "CompetencyTranslations",
                column: "CompetencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetencyTranslations");

            migrationBuilder.DropTable(
                name: "Competencies");

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
    }
}
