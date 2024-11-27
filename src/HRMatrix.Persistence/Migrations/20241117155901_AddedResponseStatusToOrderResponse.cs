using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedResponseStatusToOrderResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderReview_Orders_OrderId",
                table: "OrderReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderReview",
                table: "OrderReview");

            migrationBuilder.RenameTable(
                name: "OrderReview",
                newName: "OrderReviews");

            migrationBuilder.RenameIndex(
                name: "IX_OrderReview_OrderId",
                table: "OrderReviews",
                newName: "IX_OrderReviews_OrderId");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "OrderResponses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderReviews",
                table: "OrderReviews",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cdeff6dc-3a3e-4231-8d8a-fabbd77051cc", "AQAAAAIAAYagAAAAEFYK5Ejh6ITf6tL6GO2D27IlKyFHNfXwdwrHhQ94zyTbfnGE7Bo8AgzxgA84dbvaWw==", "e3be7c45-a1e2-4b44-9d35-88f6fa1f3103" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7c2b5c0-dc2e-46d9-ac23-33518bb0380b", "AQAAAAIAAYagAAAAENiQlCsKDte60gZLHvcPyjOlRl62vIuN29SZPMndlPeV6+z75d7zwD5tIh6f4HRyyA==", "352fd5ed-0198-4c96-86dc-76a80a894e99" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "978266d6-a2b6-4fda-ac3c-e2d1d422b319", "AQAAAAIAAYagAAAAEM6l42KmTRKofrXm9b9s4YdH19/xxApefUuveLSFCWM0KaGODJj7PXskDoI8teCMyg==", "69b59483-8c03-495e-9f19-67920aa90956" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "075f4036-af06-4c24-999e-b0aed6ddc4d0", "AQAAAAIAAYagAAAAEG0hCF3jfSu8kAtbh+T+pkbAixL0Crg2CG4BuRVMSXRxMQ9Ve52LTEdE1zVBIiBAwQ==", "6f42158c-e8db-4986-9feb-dcb95b11e1bd" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderReviews_Orders_OrderId",
                table: "OrderReviews",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderReviews_Orders_OrderId",
                table: "OrderReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderReviews",
                table: "OrderReviews");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrderResponses");

            migrationBuilder.RenameTable(
                name: "OrderReviews",
                newName: "OrderReview");

            migrationBuilder.RenameIndex(
                name: "IX_OrderReviews_OrderId",
                table: "OrderReview",
                newName: "IX_OrderReview_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderReview",
                table: "OrderReview",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderReview_Orders_OrderId",
                table: "OrderReview",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
