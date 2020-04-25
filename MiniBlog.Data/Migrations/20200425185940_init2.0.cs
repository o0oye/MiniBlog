using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniBlog.Data.Migrations
{
    public partial class init20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2020, 4, 26, 2, 59, 39, 672, DateTimeKind.Local).AddTicks(3245), new DateTime(2020, 4, 26, 2, 59, 39, 673, DateTimeKind.Local).AddTicks(7534) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2020, 4, 26, 2, 59, 39, 687, DateTimeKind.Local).AddTicks(8464), new DateTime(2020, 4, 26, 2, 59, 39, 687, DateTimeKind.Local).AddTicks(8466) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2020, 4, 26, 2, 59, 39, 687, DateTimeKind.Local).AddTicks(8469), new DateTime(2020, 4, 26, 2, 59, 39, 687, DateTimeKind.Local).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2020, 4, 26, 2, 59, 39, 687, DateTimeKind.Local).AddTicks(8473), new DateTime(2020, 4, 26, 2, 59, 39, 687, DateTimeKind.Local).AddTicks(8474) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2020, 4, 26, 2, 59, 39, 687, DateTimeKind.Local).AddTicks(8476), new DateTime(2020, 4, 26, 2, 59, 39, 687, DateTimeKind.Local).AddTicks(8477) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2020, 4, 26, 2, 59, 39, 687, DateTimeKind.Local).AddTicks(8484), new DateTime(2020, 4, 26, 2, 59, 39, 687, DateTimeKind.Local).AddTicks(8486) });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Category", "CreateTime", "UpdateTime" },
                values: new object[] { 1, "Category1", new DateTime(2020, 4, 26, 2, 59, 39, 687, DateTimeKind.Local).AddTicks(8368), new DateTime(2020, 4, 26, 2, 59, 39, 687, DateTimeKind.Local).AddTicks(8396) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2020, 4, 26, 2, 57, 32, 364, DateTimeKind.Local).AddTicks(2346), new DateTime(2020, 4, 26, 2, 57, 32, 366, DateTimeKind.Local).AddTicks(5041) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2020, 4, 26, 2, 57, 32, 387, DateTimeKind.Local).AddTicks(1489), new DateTime(2020, 4, 26, 2, 57, 32, 387, DateTimeKind.Local).AddTicks(1520) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2020, 4, 26, 2, 57, 32, 387, DateTimeKind.Local).AddTicks(1594), new DateTime(2020, 4, 26, 2, 57, 32, 387, DateTimeKind.Local).AddTicks(1597) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2020, 4, 26, 2, 57, 32, 387, DateTimeKind.Local).AddTicks(1600), new DateTime(2020, 4, 26, 2, 57, 32, 387, DateTimeKind.Local).AddTicks(1601) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2020, 4, 26, 2, 57, 32, 387, DateTimeKind.Local).AddTicks(1604), new DateTime(2020, 4, 26, 2, 57, 32, 387, DateTimeKind.Local).AddTicks(1605) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2020, 4, 26, 2, 57, 32, 387, DateTimeKind.Local).AddTicks(1608), new DateTime(2020, 4, 26, 2, 57, 32, 387, DateTimeKind.Local).AddTicks(1609) });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Category", "CreateTime", "UpdateTime" },
                values: new object[] { 7, "Category6", new DateTime(2020, 4, 26, 2, 57, 32, 387, DateTimeKind.Local).AddTicks(1618), new DateTime(2020, 4, 26, 2, 57, 32, 387, DateTimeKind.Local).AddTicks(1619) });
        }
    }
}
