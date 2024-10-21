using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserProfilesAndAspNetUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AspNetUserId",
                table: "UserProfiles",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "UserProfiles");

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
        }
    }
}
