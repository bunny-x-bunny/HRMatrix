using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedWorkTypeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypeTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    WorkTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypeTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTypeTranslations_WorkTypes_WorkTypeId",
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
                values: new object[] { "e95cc363-0600-453d-a17a-344ceedec066", "AQAAAAIAAYagAAAAEOZyrtQ8WGpLjgUs22MvOVAaecTSDeNDP+VyMrEnF7TbJEXKHBXnQV983DXt0dEkyA==", "d81fd489-b0ec-4299-8e88-8a11973e3097" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9ff6c99-3295-4304-8a2d-ee22e32a3811", "AQAAAAIAAYagAAAAEJ+BzLO7ej/FAKlFBib/HB8ZZlinslC0iwmpI8rNi6NecA97m7U3Qp7xDcR7aZU25w==", "3c17712f-dcf1-4446-a89d-249628760e37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6eb3c542-0e1b-44d6-beee-46840bd9516e", "AQAAAAIAAYagAAAAEJIAbtQIaBK58nd0xLtAXy/aT8ls65ZhDM2fx1XHqTNOoDa+rYqRtrdfomrPxdFmmA==", "31408f85-75c4-4f98-8bce-bd4cfb442cdf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cd02a44-9474-4874-a5be-70eef8b85628", "AQAAAAIAAYagAAAAEMIlEquMFHR9+aL6Xyh7UveO75+Cum4ZMG4PR5XVc4lXe/YPZJyfwrOHEtrATF5vuA==", "99c4903a-97d5-4e6a-b32c-6a5bbb5e7810" });

            migrationBuilder.InsertData(
                table: "WorkTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Полная занятость" },
                    { 2, "Частичная занятость" },
                    { 3, "Фриланс" }
                });

            migrationBuilder.InsertData(
                table: "WorkTypeTranslations",
                columns: new[] { "Id", "LanguageCode", "Name", "WorkTypeId" },
                values: new object[,]
                {
                    { 1, "ru-RU", "Полная занятость", 1 },
                    { 2, "en-US", "Full-time", 1 },
                    { 3, "ky-KG", "Толук жумуш убактысы", 1 },
                    { 4, "ru-RU", "Частичная занятость", 2 },
                    { 5, "en-US", "Part-time", 2 },
                    { 6, "ky-KG", "Жарым-жартылай жумуш", 2 },
                    { 7, "ru-RU", "Фриланс", 3 },
                    { 8, "en-US", "Freelance", 3 },
                    { 9, "ky-KG", "Эркин иш", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkTypeTranslations_WorkTypeId",
                table: "WorkTypeTranslations",
                column: "WorkTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkTypeTranslations");

            migrationBuilder.DropTable(
                name: "WorkTypes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2c0ebe2-8653-4a1f-b9a6-e1670f414070", "AQAAAAIAAYagAAAAEK3XiTE6x+2IXjB6F9EWL0LbULt1i5btE1nnYnA+pPe+ZC65KhWFnJKH4OZieIX8Cw==", "b17a677e-7a6e-4c59-888d-360cbe8ba8ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b71c94e2-8be4-4e87-99c7-0a6c7089b179", "AQAAAAIAAYagAAAAEOOEkuB0SHOmCqPBUPRMcwB2hn3r/A8f/w4uKS6QY6l6V9jzXDM0Bq5r+pvuA5p3Qw==", "66fc5a21-593d-47e7-9b6d-d103ba14bcb2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e4f66f2-e08b-438a-ad1b-145c6fe60570", "AQAAAAIAAYagAAAAEG8ovQAIcYS1EVbLXUnQ+icJzCzNzg93mVQ1YBFz+xrPDtNSvQHZ6hboHJXsTTp0uQ==", "e48102ee-3965-4637-93f4-9ea842f0756c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "743f9c1a-f81a-452c-a8b7-9d4310187539", "AQAAAAIAAYagAAAAEJ3gh38dCdSaQ6TTXG+Ov0uxmKH0LA43iDX0wWvNqXhzs8/C10r0aDQBOatlH92ceQ==", "c36f2590-6dce-4869-a5dd-fc5ce21cbd1e" });
        }
    }
}
