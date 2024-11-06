using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedReviewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderReview_Orders_OrderId",
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
                values: new object[] { "31ba849c-513e-457e-acb2-e023ead6b17b", "AQAAAAIAAYagAAAAEMP+Vdq9J8n+pqZm7Lzr/LpvY95K4zncb+hq2rN5FOaCo8E+t3QnuAUckM6zNKF5Iw==", "0e62892e-035c-4cac-be72-8643aa6bf960" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "126977d1-4498-4776-a702-db13589b7e79", "AQAAAAIAAYagAAAAELSipIqoFRnsUlRTh1LJlBabjGzzwQ2WxLusfZDbzKeDfGqok+wVI/Cxrf7vs0OjCA==", "016c57f9-bc99-4b49-a490-bbcffa21cab8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a25020c-a845-4e4f-8a65-6dd317165619", "AQAAAAIAAYagAAAAELOjVpvlbo1CwcCU2umBBdTFai4wigK/NIHSQhlJgXV25TAIqsxZcCXEcU9xhNWCTA==", "b0c53663-e52e-4d2d-812b-e9ba67d3820e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "408ea5cb-f360-484d-a0d8-58e37ef1b3e4", "AQAAAAIAAYagAAAAELki6vNAnrTg6gtPbtz+D6m2VSuqeFbPBPK1PzL66mvlARZqiDMXzO4TxIJBf05ARw==", "c72bb002-3dbb-4ba9-96b9-d7083088a0dc" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderReview_OrderId",
                table: "OrderReview",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderReview");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aaecc633-7e90-4fec-88ae-1a9701b1117a", "AQAAAAIAAYagAAAAEPB6l8qibYohTLnnM9P8fHEaOBBZMMGrMrKgrm5Jd1stGTA5/Vs+Dmh7FM2/FfR8wA==", "7b66fa4a-6668-4ff8-8151-f8f8a227508a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9ac5b9b-1b0e-4b57-a741-8d69f7da8a70", "AQAAAAIAAYagAAAAEDfN++MNX3YDoU6KUU09fAh+zXld5TOoNZpN2aLdU+aeOBMUbS0YLkMuykU0+0rspQ==", "9cdf26d7-f73e-4cda-9ee0-6a46834e2752" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ea73183-eac3-4a6b-9032-13f17b5df33b", "AQAAAAIAAYagAAAAEF5ePOpLg/y/A1xYRlKQKCrURrFQkqkWZXEooUlQ8amE0bOaScODJN+FTGOAiyxzdQ==", "3a975272-803c-4153-8e3f-fcb6e8145942" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25bae6ae-fb82-40eb-8b3f-844f9c66e18d", "AQAAAAIAAYagAAAAEJWOA3IMTEf6G0CKvAGoS2QtYaMxRpA2hnr4sq6xac3ENu406ZdexrKd307r6oBrhQ==", "3e90fc9c-046d-44b9-9a99-1db708306919" });
        }
    }
}
