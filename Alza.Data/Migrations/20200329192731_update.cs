using Microsoft.EntityFrameworkCore.Migrations;

namespace Alza.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImgUrl",
                table: "Product",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
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
                values: new object[,]
                {
                    { 100001, 100 },
                    { 100002, 300 },
                    { 100003, 5 },
                    { 100004, 0 },
                    { 100005, 0 },
                    { 100006, 50 },
                    { 100007, 100 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 100001);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 100002);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 100003);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 100004);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 100005);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 100006);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 100007);

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ImgUrl",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }
    }
}
