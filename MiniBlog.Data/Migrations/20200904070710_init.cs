using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniBlog.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    User = table.Column<string>(maxLength: 32, nullable: false),
                    Password = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Category = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Origin = table.Column<string>(maxLength: 256, nullable: true),
                    Big = table.Column<string>(maxLength: 256, nullable: true),
                    Small = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 64, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Summary = table.Column<string>(maxLength: 256, nullable: true),
                    Icon = table.Column<string>(maxLength: 256, nullable: true),
                    IsShow = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "CreateTime", "Password", "UpdateTime", "User" },
                values: new object[] { 1, new DateTime(2020, 9, 4, 15, 7, 10, 210, DateTimeKind.Local).AddTicks(6285), "123456", new DateTime(2020, 9, 4, 15, 7, 10, 212, DateTimeKind.Local).AddTicks(1781), "admin" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Category", "CreateTime", "UpdateTime" },
                values: new object[,]
                {
                    { 1, "Category1", new DateTime(2020, 9, 4, 15, 7, 10, 221, DateTimeKind.Local).AddTicks(8099), new DateTime(2020, 9, 4, 15, 7, 10, 221, DateTimeKind.Local).AddTicks(8137) },
                    { 2, "Category2", new DateTime(2020, 9, 4, 15, 7, 10, 221, DateTimeKind.Local).AddTicks(8199), new DateTime(2020, 9, 4, 15, 7, 10, 221, DateTimeKind.Local).AddTicks(8201) },
                    { 3, "Category3", new DateTime(2020, 9, 4, 15, 7, 10, 221, DateTimeKind.Local).AddTicks(8203), new DateTime(2020, 9, 4, 15, 7, 10, 221, DateTimeKind.Local).AddTicks(8205) },
                    { 4, "Category4", new DateTime(2020, 9, 4, 15, 7, 10, 221, DateTimeKind.Local).AddTicks(8207), new DateTime(2020, 9, 4, 15, 7, 10, 221, DateTimeKind.Local).AddTicks(8208) },
                    { 5, "Category5", new DateTime(2020, 9, 4, 15, 7, 10, 221, DateTimeKind.Local).AddTicks(8210), new DateTime(2020, 9, 4, 15, 7, 10, 221, DateTimeKind.Local).AddTicks(8212) },
                    { 6, "Category6", new DateTime(2020, 9, 4, 15, 7, 10, 221, DateTimeKind.Local).AddTicks(8220), new DateTime(2020, 9, 4, 15, 7, 10, 221, DateTimeKind.Local).AddTicks(8221) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_CategoryId",
                table: "Post",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
