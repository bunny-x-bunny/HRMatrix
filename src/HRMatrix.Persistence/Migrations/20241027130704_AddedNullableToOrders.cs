using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedNullableToOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerEmail",
                table: "Orders",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "AssignedUserProfileId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerEmail",
                table: "Orders",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignedUserProfileId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
        }
    }
}
