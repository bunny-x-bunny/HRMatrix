using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrdersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ExpectedCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    AssignedUserProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_UserProfiles_AssignedUserProfileId",
                        column: x => x.AssignedUserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d73e393-3529-4453-9177-646104fd5141", "AQAAAAIAAYagAAAAEOjLvGMKy3uerKP07g0tDYkrGPNoUNmRoo5ILXRrbWo0hXOd4NSyibIAdHz7xPFWeg==", "ee7ddac8-4c11-46ee-80d3-0eed1ba0677e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "492354df-fb11-40a5-a8ee-7bc182b7def0", "AQAAAAIAAYagAAAAEPOCPxo+1Z3Bd3Z5zJnHyN4hjot55DI8a0h/RyTMcTOMQ9qQjn3L/ZCkmSr3WQMqUQ==", "164b44d8-1777-4c55-a3b1-430a8ac10f8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae94b4fe-b0f1-4359-a4ce-f1e377b62e40", "AQAAAAIAAYagAAAAEEcLWPz/m/fFJaBZDXhXQBdIeecCqtcO8AH06O9OVnr7dkWTexHloq3J3bI7np2GmQ==", "75e15f65-b6a1-4471-bc96-d7992ee3975a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "055216c6-8977-4119-87f8-d20d0181ec0f", "AQAAAAIAAYagAAAAEDFME1SNh3JpYzrc+WTCiMj6h8QqwZAlqA8xj43u1oO2cuAzD1VuaBWtOXdZ8gp99Q==", "1a415936-0ad1-4fef-af5c-fa5b98a1b21b" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AssignedUserProfileId",
                table: "Orders",
                column: "AssignedUserProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd827303-c4b8-4e9c-99cc-2c81c24c17e1", "AQAAAAIAAYagAAAAEEXc714N5j3o3KiRnRAXeYY1SavLjk42mGWBIlbY9AL9Z6t1wBFWr1ECC1MnDxXzBg==", "376babde-06c5-465d-b6b5-ddd2c5c7a850" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1d5429e-4523-4ec2-9495-c49385d30463", "AQAAAAIAAYagAAAAEJS4Btr+0QutXY4UUActfeEJHqrSnR+o8x7Hy7Rqk+QF/6dLM/7ctBz+IWPBN4FyLQ==", "faf92a6c-b188-49aa-a46d-b4b20db8f6fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8925c464-d6a3-4d8c-9b74-7c70c9eae229", "AQAAAAIAAYagAAAAEHmQqej1RTD+/qLOo8JmXyxSqJVdBVMGlaA1YWGMpabGU0JLp4bCN7/ad62CC4y9Ow==", "b2e4715b-16a5-4f4b-81e2-f2fdf7124f66" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "079de386-e656-48c6-be0b-004d1eabe05c", "AQAAAAIAAYagAAAAEKdirxJ/I/Che1rH7RHmYTBd+gBjvNx8W9Ur7xjaL4itPxDxIgEjBDf+Wpbvm9InZw==", "bda1073a-8c5a-4cf6-a065-8987ebb7f533" });
        }
    }
}
