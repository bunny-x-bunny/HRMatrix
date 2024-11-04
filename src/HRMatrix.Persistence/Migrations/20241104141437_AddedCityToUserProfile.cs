using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedCityToUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "UserProfiles",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "397b34b5-1091-45f5-9b88-1053e1abbcff", "AQAAAAIAAYagAAAAELtDpt4uzzkjo8U2nr9zKNoYDVwDnl/2mDFofw5esAvuMQVf8FmcXChxZybBouqRHw==", "386d5d00-f632-40f3-8d34-d57d708cfa38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c7d5003-8055-48a1-ba0d-2805e0efb29c", "AQAAAAIAAYagAAAAEHPTYwhHtc29eZ7YkQdc28brYttP0eDSQKX9vPYDi422RYHQD1WnnlAifGXpEKFtjg==", "b9c7109c-0a92-4981-925e-5a43b0fae3b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0f8589b-6d23-479a-9008-c484240476bb", "AQAAAAIAAYagAAAAEJ3WzbXOnpKpIu/FmuTFCYBRNQl0KRKpLqxgEMUnDEcX+i+OvXPj39Mcv+mZPSPZVg==", "a2021a58-4b86-4cf8-b511-52af8a344854" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2b904b9-0cb7-4ec2-a0ac-4b8d42f49cf0", "AQAAAAIAAYagAAAAEGWmdOm5svcTaQP1+bZnJYYbQ+zXH0ZBsq3Bu2TFAwePDwdvGDwQLV2KhiLhRVFqOA==", "2aae08e6-b6a6-4e90-be8d-ed797e9b15a8" });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_CityId",
                table: "UserProfiles",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Cities_CityId",
                table: "UserProfiles",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Cities_CityId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_CityId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "UserProfiles");

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
        }
    }
}
