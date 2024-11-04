using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedCityToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Orders",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CityId",
                table: "Orders",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cities_CityId",
                table: "Orders",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cities_CityId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "978ba10f-291e-4e8c-ba2a-8d57f3f24dfa", "AQAAAAIAAYagAAAAEBTsyoSdpZ43OlI58DKrybZZVeBEMkiFq9p14oq7yQs7AdFxjUPpDIpeIQSrtG5HJw==", "527a34dc-ac3c-4951-b05d-8f8de37604cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dd98af0-2d5e-4303-8e6a-abc27343fb8b", "AQAAAAIAAYagAAAAEHhtjLYRF7I370sHWwn1uMAboDAq83McE2wnHKq0r5D2JMahDZKBxPr7Y1cwzHXMAA==", "f7228a57-c604-45b9-8cc2-a2606fc348f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb8aa098-c99f-4dc9-9140-8e8950c0feea", "AQAAAAIAAYagAAAAEAu4Un8bLhyGjIA9TUQCj0M51jvW3dadDp12pmoRKi2n7oOo/mlAB/JCu8cBZcHQhw==", "4eb5c231-9f88-4227-9193-87bd73c4a5de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b40a617-8723-4296-a567-cb3861b27c58", "AQAAAAIAAYagAAAAEKQJyBpoboRWA++af/v3I9gvPRSxjoiCjCuDAZQ/CRfvCvtoE+Vbo8fmp1Tg7prOww==", "d2628030-af08-4b0e-8bfa-8e0e6d5adc99" });
        }
    }
}
