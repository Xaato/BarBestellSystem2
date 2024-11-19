using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    X = table.Column<int>(type: "INTEGER", nullable: false),
                    Y = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ArticleGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_ArticleGroups_ArticleGroupId",
                        column: x => x.ArticleGroupId,
                        principalTable: "ArticleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TableId = table.Column<int>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Employee = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticleId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderArticles_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderArticles_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ArticleGroups",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Drinks" });

            migrationBuilder.InsertData(
                table: "ArticleGroups",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Food" });

            migrationBuilder.InsertData(
                table: "ArticleGroups",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Desserts" });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Name", "X", "Y" },
                values: new object[] { 1, "Table 1", 0, 0 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Name", "X", "Y" },
                values: new object[] { 2, "Table 2", 100, 150 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Name", "X", "Y" },
                values: new object[] { 3, "Table 3", 200, 300 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Name", "X", "Y" },
                values: new object[] { 4, "Table 4", 300, 450 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Name", "X", "Y" },
                values: new object[] { 5, "Table 5", 400, 600 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Name", "X", "Y" },
                values: new object[] { 6, "Table 6", 500, 750 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Name", "X", "Y" },
                values: new object[] { 7, "Table 7", 600, 900 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Name", "X", "Y" },
                values: new object[] { 8, "Table 8", 700, 1050 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleGroupId", "Name", "Number", "Price" },
                values: new object[] { 1, 1, "Beer", 0, 3.50m });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleGroupId", "Name", "Number", "Price" },
                values: new object[] { 2, 1, "Wine", 0, 4.50m });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleGroupId", "Name", "Number", "Price" },
                values: new object[] { 3, 1, "Soda", 0, 2.00m });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleGroupId", "Name", "Number", "Price" },
                values: new object[] { 4, 2, "Pizza", 0, 8.50m });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleGroupId", "Name", "Number", "Price" },
                values: new object[] { 5, 2, "Burger", 0, 7.50m });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleGroupId", "Name", "Number", "Price" },
                values: new object[] { 6, 2, "Fries", 0, 3.50m });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleGroupId", "Name", "Number", "Price" },
                values: new object[] { 7, 3, "Ice Cream", 0, 4.50m });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleGroupId", "Name", "Number", "Price" },
                values: new object[] { 8, 3, "Cake", 0, 5.50m });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleGroupId",
                table: "Articles",
                column: "ArticleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderArticles_ArticleId",
                table: "OrderArticles",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderArticles_OrderId",
                table: "OrderArticles",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableId",
                table: "Orders",
                column: "TableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderArticles");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ArticleGroups");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
