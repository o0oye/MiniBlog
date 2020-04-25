using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniBlog.Data.Migrations
{
    public partial class init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new DateTime(2020, 4, 26, 2, 54, 32, 140, DateTimeKind.Local).AddTicks(6696), new DateTime(2020, 4, 26, 2, 54, 32, 142, DateTimeKind.Local).AddTicks(1124) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2020, 4, 26, 2, 54, 32, 156, DateTimeKind.Local).AddTicks(7398), new DateTime(2020, 4, 26, 2, 54, 32, 156, DateTimeKind.Local).AddTicks(7400) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2020, 4, 26, 2, 54, 32, 156, DateTimeKind.Local).AddTicks(7403), new DateTime(2020, 4, 26, 2, 54, 32, 156, DateTimeKind.Local).AddTicks(7405) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2020, 4, 26, 2, 54, 32, 156, DateTimeKind.Local).AddTicks(7407), new DateTime(2020, 4, 26, 2, 54, 32, 156, DateTimeKind.Local).AddTicks(7408) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2020, 4, 26, 2, 54, 32, 156, DateTimeKind.Local).AddTicks(7410), new DateTime(2020, 4, 26, 2, 54, 32, 156, DateTimeKind.Local).AddTicks(7412) });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2020, 4, 26, 2, 54, 32, 156, DateTimeKind.Local).AddTicks(7418), new DateTime(2020, 4, 26, 2, 54, 32, 156, DateTimeKind.Local).AddTicks(7420) });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Category", "CreateTime", "UpdateTime" },
                values: new object[] { 1, "Category1", new DateTime(2020, 4, 26, 2, 54, 32, 156, DateTimeKind.Local).AddTicks(7307), new DateTime(2020, 4, 26, 2, 54, 32, 156, DateTimeKind.Local).AddTicks(7332) });
        }
    }
}
