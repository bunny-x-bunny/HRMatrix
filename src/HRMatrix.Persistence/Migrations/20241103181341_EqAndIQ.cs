using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMatrix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EqAndIQ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Eq",
                table: "UserProfiles",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Iq",
                table: "UserProfiles",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03bfec12-8e72-447a-b2d1-1e6da190a0fc", "AQAAAAIAAYagAAAAEBXHCHxbpPN5RBhWNJ/+xTDES2L0S6S/ny9X4Wk0dYrfhnsJE+03pLhKUfCgYq8neg==", "26ce7feb-707f-4730-b87f-3cdf1aa59ce5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67fcfe54-f00c-4e2c-a190-ff19fcb51cfd", "AQAAAAIAAYagAAAAEHfUtKYFLVK+WYKABR3pid9ZySfCv26L4rcqJTH3icOeGOI7zBvAcVRaRILSrH1s7w==", "2edf8193-e4d2-4044-a31e-2a2b095f7a7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ba87dc9-9ae3-41b4-9284-08926d7fff2f", "AQAAAAIAAYagAAAAEF7qV8G2sgy/6CjhDUCr8lP0c5TYPX9pgCSxoTfhhklVW1pSZADsHZ4CnlN0OQIZOw==", "8cb196c4-5d6f-4dc9-83ff-5babc6879e19" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd10c271-ac2b-4d87-8dc5-107d777a28ba", "AQAAAAIAAYagAAAAEHhC5x2y1vViCE2pIM0M2OJRbinZ3s/ltKa/2CHesev0qPqIKPCjRS4+NhiNojONCA==", "e521f7f1-4663-4446-8884-6c8aa2b46a23" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eq",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Iq",
                table: "UserProfiles");

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
        }
    }
}
