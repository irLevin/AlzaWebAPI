using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alza.Data.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ImgUrl = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UnitsInStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Inventory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 100001, "Product 100001 description", "http://img.com/100001.jps", "Product 100001", 20.5m },
                    { 100002, "Product 100002 description", "http://img.com/100002.jps", "Product 100002", 12.5m },
                    { 100003, "Product 100003 description", "http://img.com/100003.jps", "Product 100003", 10m },
                    { 100004, "Product 100004 description", "http://img.com/100004.jps", "Product 100004", 16m },
                    { 100005, "Product 100005 description", "http://img.com/100005.jps", "Product 100005", 9.5m },
                    { 100006, "Product 100006 description", "http://img.com/100006.jps", "Product 100006", 30m },
                    { 100007, "Product 100007 description", "http://img.com/100007.jps", "Product 100007", 40m }
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "ProductId", "UnitsInStock" },
                values: new object[] { 100001, 100 });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "ProductId", "UnitsInStock" },
                values: new object[] { 100002, 300 });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "ProductId", "UnitsInStock" },
                values: new object[] { 100003, 5 });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "ProductId", "UnitsInStock" },
                values: new object[] { 100004, 0 });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "ProductId", "UnitsInStock" },
                values: new object[] { 100005, 0 });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "ProductId", "UnitsInStock" },
                values: new object[] { 100006, 50 });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "ProductId", "UnitsInStock" },
                values: new object[] { 100007, 100 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }
    }
}
