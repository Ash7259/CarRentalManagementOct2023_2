using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalManagementOct2023_2.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultDataAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", null, "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "cc3c71bf-c801-4cd8-9a8e-03968f0d28cf", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEPPrj81JA/DC1gsL5fbwDDfVsVtdBFR+tEjoANGvcAdXyTUu5mJMwu8qViexPAiQjg==", null, false, "30d645ad-0f61-497f-8b31-7930ee99668d", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 12, 3, 20, 10, 10, 294, DateTimeKind.Local).AddTicks(2728), new DateTime(2023, 12, 3, 20, 10, 10, 294, DateTimeKind.Local).AddTicks(2745), "Black", "System" },
                    { 2, "System", new DateTime(2023, 12, 3, 20, 10, 10, 294, DateTimeKind.Local).AddTicks(2750), new DateTime(2023, 12, 3, 20, 10, 10, 294, DateTimeKind.Local).AddTicks(2751), "Blue", "System" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 12, 3, 20, 10, 10, 294, DateTimeKind.Local).AddTicks(3898), new DateTime(2023, 12, 3, 20, 10, 10, 294, DateTimeKind.Local).AddTicks(3899), "BMW", "System" },
                    { 2, "System", new DateTime(2023, 12, 3, 20, 10, 10, 294, DateTimeKind.Local).AddTicks(3903), new DateTime(2023, 12, 3, 20, 10, 10, 294, DateTimeKind.Local).AddTicks(3904), "Toyota", "System" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 12, 3, 20, 10, 10, 294, DateTimeKind.Local).AddTicks(3442), new DateTime(2023, 12, 3, 20, 10, 10, 294, DateTimeKind.Local).AddTicks(3444), "3 Series", "System" },
                    { 2, "System", new DateTime(2023, 12, 3, 20, 10, 10, 294, DateTimeKind.Local).AddTicks(3446), new DateTime(2023, 12, 3, 20, 10, 10, 294, DateTimeKind.Local).AddTicks(3447), "X5", "System" },
                    { 3, "System", new DateTime(2023, 12, 3, 20, 10, 10, 294, DateTimeKind.Local).AddTicks(3449), new DateTime(2023, 12, 3, 20, 10, 10, 294, DateTimeKind.Local).AddTicks(3450), "Prius", "System" },
                    { 4, "System", new DateTime(2023, 12, 3, 20, 10, 10, 294, DateTimeKind.Local).AddTicks(3453), new DateTime(2023, 12, 3, 20, 10, 10, 294, DateTimeKind.Local).AddTicks(3453), "Rav4", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");
        }
    }
}
