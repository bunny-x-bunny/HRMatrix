using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedCountryAndCityEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CountryTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryTranslations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityTranslations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "692fc11c-1b88-49e7-87e4-30c5c9d44878", "AQAAAAIAAYagAAAAEOrx/TJCeUqBYw9Vm2aUkY80f0Oo1AHTU2/YVp9GC8Zu2rpsi3RPpnZ1lFY087D/Aw==", "b39e1f54-22be-49ab-a846-bc33bc2abe3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "208840d1-9fed-4085-9879-6d938693936a", "AQAAAAIAAYagAAAAEFRrpJT00vygyz55/RyTp8x9PKxfAqp9R6Qiz44oMT8UFmRfEyAQsmSxVHxn5JQOsA==", "278a2976-1833-4ea1-bc7a-e0f8f2fdf95a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "444b14f8-0c50-4843-a9a5-c5b9e7c5ce79", "AQAAAAIAAYagAAAAEEy0Fmhr4qc2hqCnahv1AbuVIy+TYmVhd2yH583SONRKSQplqnyb6rlhgJ2TAyMMCA==", "0e08f227-e90d-4773-a6f8-3d3e65b13870" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2f8409e-54ab-44af-bff6-44f8fc05a776", "AQAAAAIAAYagAAAAEJCmhXZU09k4+sZYxtuLLOiCli9X8KsGfKEgCVgBKgfvYFlcHqbPp3qEE5YY+ib64w==", "e1506700-1ee9-4209-b8cf-0965a1ec3691" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Россия" },
                    { 2, "Казахстан" },
                    { 3, "Беларусь" },
                    { 4, "Украина" },
                    { 5, "Узбекистан" },
                    { 6, "Кыргызстан" },
                    { 7, "Таджикистан" },
                    { 8, "Армения" },
                    { 9, "Азербайджан" },
                    { 10, "Молдова" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Москва" },
                    { 2, 1, "Санкт-Петербург" },
                    { 3, 2, "Алматы" },
                    { 4, 2, "Нур-Султан" },
                    { 5, 3, "Минск" },
                    { 6, 3, "Гомель" },
                    { 7, 4, "Киев" },
                    { 8, 4, "Одесса" },
                    { 9, 5, "Ташкент" },
                    { 10, 5, "Самарканд" },
                    { 11, 6, "Бишкек" },
                    { 12, 6, "Ош" },
                    { 13, 7, "Душанбе" },
                    { 14, 7, "Худжанд" },
                    { 15, 8, "Ереван" },
                    { 16, 8, "Гюмри" },
                    { 17, 9, "Баку" },
                    { 18, 9, "Гянджа" },
                    { 19, 10, "Кишинёв" },
                    { 20, 10, "Бельцы" }
                });

            migrationBuilder.InsertData(
                table: "CountryTranslations",
                columns: new[] { "Id", "CountryId", "LanguageCode", "Name" },
                values: new object[,]
                {
                    { 1, 1, "en-US", "Russia" },
                    { 2, 1, "ru-RU", "Россия" },
                    { 3, 1, "ky-KG", "Россия" },
                    { 4, 2, "en-US", "Kazakhstan" },
                    { 5, 2, "ru-RU", "Казахстан" },
                    { 6, 2, "ky-KG", "Казакстан" },
                    { 7, 3, "en-US", "Belarus" },
                    { 8, 3, "ru-RU", "Беларусь" },
                    { 9, 3, "ky-KG", "Беларусь" },
                    { 10, 4, "en-US", "Ukraine" },
                    { 11, 4, "ru-RU", "Украина" },
                    { 12, 4, "ky-KG", "Украина" },
                    { 13, 5, "en-US", "Uzbekistan" },
                    { 14, 5, "ru-RU", "Узбекистан" },
                    { 15, 5, "ky-KG", "Өзбекстан" },
                    { 16, 6, "en-US", "Kyrgyzstan" },
                    { 17, 6, "ru-RU", "Кыргызстан" },
                    { 18, 6, "ky-KG", "Кыргызстан" },
                    { 19, 7, "en-US", "Tajikistan" },
                    { 20, 7, "ru-RU", "Таджикистан" },
                    { 21, 7, "ky-KG", "Тажикстан" },
                    { 22, 8, "en-US", "Armenia" },
                    { 23, 8, "ru-RU", "Армения" },
                    { 24, 8, "ky-KG", "Армения" },
                    { 25, 9, "en-US", "Azerbaijan" },
                    { 26, 9, "ru-RU", "Азербайджан" },
                    { 27, 9, "ky-KG", "Азербайжан" },
                    { 28, 10, "en-US", "Moldova" },
                    { 29, 10, "ru-RU", "Молдова" },
                    { 30, 10, "ky-KG", "Молдова" }
                });

            migrationBuilder.InsertData(
                table: "CityTranslations",
                columns: new[] { "Id", "CityId", "LanguageCode", "Name" },
                values: new object[,]
                {
                    { 1, 1, "en-US", "Moscow" },
                    { 2, 1, "ru-RU", "Москва" },
                    { 3, 1, "ky-KG", "Москва" },
                    { 4, 2, "en-US", "Saint Petersburg" },
                    { 5, 2, "ru-RU", "Санкт-Петербург" },
                    { 6, 2, "ky-KG", "Санкт-Петербург" },
                    { 7, 3, "en-US", "Almaty" },
                    { 8, 3, "ru-RU", "Алматы" },
                    { 9, 3, "ky-KG", "Алматы" },
                    { 10, 4, "en-US", "Nur-Sultan" },
                    { 11, 4, "ru-RU", "Нур-Султан" },
                    { 12, 4, "ky-KG", "Нур-Султан" },
                    { 13, 5, "en-US", "Minsk" },
                    { 14, 5, "ru-RU", "Минск" },
                    { 15, 5, "ky-KG", "Минск" },
                    { 16, 6, "en-US", "Gomel" },
                    { 17, 6, "ru-RU", "Гомель" },
                    { 18, 6, "ky-KG", "Гомель" },
                    { 19, 7, "en-US", "Kyiv" },
                    { 20, 7, "ru-RU", "Киев" },
                    { 21, 7, "ky-KG", "Киев" },
                    { 22, 8, "en-US", "Odessa" },
                    { 23, 8, "ru-RU", "Одесса" },
                    { 24, 8, "ky-KG", "Одесса" },
                    { 25, 9, "en-US", "Tashkent" },
                    { 26, 9, "ru-RU", "Ташкент" },
                    { 27, 9, "ky-KG", "Ташкент" },
                    { 28, 10, "en-US", "Samarkand" },
                    { 29, 10, "ru-RU", "Самарканд" },
                    { 30, 10, "ky-KG", "Самарканд" },
                    { 31, 11, "en-US", "Bishkek" },
                    { 32, 11, "ru-RU", "Бишкек" },
                    { 33, 11, "ky-KG", "Бишкек" },
                    { 34, 12, "en-US", "Osh" },
                    { 35, 12, "ru-RU", "Ош" },
                    { 36, 12, "ky-KG", "Ош" },
                    { 37, 13, "en-US", "Dushanbe" },
                    { 38, 13, "ru-RU", "Душанбе" },
                    { 39, 13, "ky-KG", "Душанбе" },
                    { 40, 14, "en-US", "Khujand" },
                    { 41, 14, "ru-RU", "Худжанд" },
                    { 42, 14, "ky-KG", "Худжанд" },
                    { 43, 15, "en-US", "Yerevan" },
                    { 44, 15, "ru-RU", "Ереван" },
                    { 45, 15, "ky-KG", "Ереван" },
                    { 46, 16, "en-US", "Gyumri" },
                    { 47, 16, "ru-RU", "Гюмри" },
                    { 48, 16, "ky-KG", "Гюмри" },
                    { 49, 17, "en-US", "Baku" },
                    { 50, 17, "ru-RU", "Баку" },
                    { 51, 17, "ky-KG", "Баку" },
                    { 52, 18, "en-US", "Ganja" },
                    { 53, 18, "ru-RU", "Гянджа" },
                    { 54, 18, "ky-KG", "Гянджа" },
                    { 55, 19, "en-US", "Chisinau" },
                    { 56, 19, "ru-RU", "Кишинёв" },
                    { 57, 19, "ky-KG", "Кишинёв" },
                    { 58, 20, "en-US", "Balti" },
                    { 59, 20, "ru-RU", "Бельцы" },
                    { 60, 20, "ky-KG", "Бельцы" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CityTranslations_CityId",
                table: "CityTranslations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTranslations_CountryId",
                table: "CountryTranslations",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityTranslations");

            migrationBuilder.DropTable(
                name: "CountryTranslations");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03bfec12-8e72-447a-b2d1-1e6da190a0fc", "AQAAAAIAAYagAAAAEBXHCHxbpPN5RBhWNJ/+xTDES2L0S6S/ny9X4Wk0dYrfhnsJE+03pLhKUfCgYq8neg==", "26ce7feb-707f-4730-b87f-3cdf1aa59ce5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67fcfe54-f00c-4e2c-a190-ff19fcb51cfd", "AQAAAAIAAYagAAAAEHfUtKYFLVK+WYKABR3pid9ZySfCv26L4rcqJTH3icOeGOI7zBvAcVRaRILSrH1s7w==", "2edf8193-e4d2-4044-a31e-2a2b095f7a7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ba87dc9-9ae3-41b4-9284-08926d7fff2f", "AQAAAAIAAYagAAAAEF7qV8G2sgy/6CjhDUCr8lP0c5TYPX9pgCSxoTfhhklVW1pSZADsHZ4CnlN0OQIZOw==", "8cb196c4-5d6f-4dc9-83ff-5babc6879e19" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd10c271-ac2b-4d87-8dc5-107d777a28ba", "AQAAAAIAAYagAAAAEHhC5x2y1vViCE2pIM0M2OJRbinZ3s/ltKa/2CHesev0qPqIKPCjRS4+NhiNojONCA==", "e521f7f1-4663-4446-8884-6c8aa2b46a23" });
        }
    }
}
