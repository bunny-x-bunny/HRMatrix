using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderSkillConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "OrderSkill",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSkill", x => new { x.OrderId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_OrderSkill_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a66ddfac-360b-45fe-a59b-9528af1cacd3", "AQAAAAIAAYagAAAAECjhptntV15BR/JU5qIHbZqFkmbY62VnwqmVm/Eto5N8iJbKAtTlgFfD/1KVldUFMA==", "69423d88-7b00-483b-bd6f-3443c8622654" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7509ea0a-6e6a-4c0a-a3e9-5d794eadad24", "AQAAAAIAAYagAAAAEDtsLW4E0OuiNULl/C63pWt7k5Bchij3Dqpw0HVjR9msMLbSLBkqpYhKXgcp7fHVkA==", "713fefff-15f3-456b-b17a-6c85c9d7fc65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d68440a-cd56-4065-94da-0d01f0a5033f", "AQAAAAIAAYagAAAAECjWbFRgZixRrIZXGSVpFEqRLtbL76uSajx6ORtBDf/BinXUwUOL4get3uJsr2ihWw==", "3d91ef1f-d8f4-43f2-aaff-4c4922aa19f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29a56005-63ff-4eac-b39a-b35b9909d7d9", "AQAAAAIAAYagAAAAEGD1idsW+UvjZRsTFaPsHhw1lr6evSgmNqkrYGViqmxZknF40cy4GNTE71YTSIuVnQ==", "4eab8c69-910a-4d65-bddc-4a7dc5b1186c" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderSkill_SkillId",
                table: "OrderSkill",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderSkill");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Orders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

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
        }
    }
}
