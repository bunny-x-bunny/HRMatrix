using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrderResponseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderResponses_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0b9a80e-3692-41e6-a605-1f7ea9d26e2d", "AQAAAAIAAYagAAAAEHkD0q19JQANxm9xrwD+gHwf5nugb9XPiFUkaP7r5zt9DML1JEc9DIF2rERN0UNYOw==", "0867df99-3ac1-437e-b0e9-f46f42c6fa0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8d1344c-da7f-4448-92f5-b20113cee6f5", "AQAAAAIAAYagAAAAEJEATQWg3789zhUEzJanmprnTziwUG/am3Hf/4JvwDUQiOVPWnARNZgZ0eopjNxjeQ==", "3b2d8833-c3a1-428d-9f66-b071916d6921" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34d4b8c6-c696-47f9-9151-385ce1d9efa5", "AQAAAAIAAYagAAAAEP3Bkp9rF4ys6h8/ux72pNcDFdnWmaQbrxKzf5+VlKu++fWDRa6WjhYfpcUYpeM1UA==", "d881ff6d-8647-4810-8355-ee0177ba1532" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "090b488b-65b1-4116-a660-838d8afb6149", "AQAAAAIAAYagAAAAEGYeJR7XhOKqNt/a2+3QDwdTILeFozuxEbTIEBqVKh7XQmEPXklYM4oie6w9zSkbCw==", "3affd0a8-18a4-403c-a6ac-eeaa6bb3101c" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderResponses_OrderId",
                table: "OrderResponses",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderResponses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df605f20-70f3-41ea-a00d-04ed73ff12cd", "AQAAAAIAAYagAAAAEJxTxNHYTVyg8UrgWjyQuLiBCoLf47ABB6YZVgG6RW08sc5K86Iu5+uh8bSxZREDmw==", "a62c235c-3afb-4bf9-9dad-db0793e4b533" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8b07577-e3e7-4642-a393-27f14372e569", "AQAAAAIAAYagAAAAEJmnk15gNToM5aqXmrLdnXkfxpRbbOfrhZv4sI/neSPCIHWigtANFUprOpTjI/CMqw==", "e1c978c2-12a5-494e-9759-a230ccbfdc5a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73cabefe-46c0-465d-9e0e-00ff660ba423", "AQAAAAIAAYagAAAAEGcqZxWqLXWtNGKqKw4l8mYq2SwztxvSW4e1ickSJSFjGBkdNKEq8BQuiRCXC7WYTg==", "5ae67e20-f724-4283-8d05-ad82e802d645" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa5487a6-ea59-4437-a566-007700fd6a40", "AQAAAAIAAYagAAAAEL5xOhtX7f+3sFM2lL1zI/LG2av8ZVP3iOvsbb2NEFiizAv+crrbSq1SemtSuXKDXA==", "33cfe581-5232-48e6-afc4-14861455b786" });
        }
    }
}
