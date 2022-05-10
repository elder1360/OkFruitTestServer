using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infractructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "unitType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unitType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_unitType_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "unitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_purchase_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchase_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "Id", "LastName", "Name" },
                values: new object[,]
                {
                    { 1, "معدلی", "محمدعلی" },
                    { 2, "ناصحی", "علی" },
                    { 3, "رنجبر", "حامد" },
                    { 4, "شیری", "کریم" },
                    { 5, "محمدزاده", "نیما" }
                });

            migrationBuilder.InsertData(
                table: "unitType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "کیلوگرم" });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "Id", "Name", "Price", "UnitTypeId" },
                values: new object[,]
                {
                    { 1, "سیب", 8000.0, 1 },
                    { 2, "پرتقال", 6500.0, 1 },
                    { 3, "هویج", 5000.0, 1 },
                    { 4, "گیلاس", 10000.0, 1 },
                    { 5, "موز", 15000.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "purchase",
                columns: new[] { "Id", "CustomerId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 3 },
                    { 2, 1, 2, 2 },
                    { 3, 1, 3, 3 },
                    { 4, 1, 4, 4 },
                    { 5, 2, 5, 1 },
                    { 6, 2, 4, 5 },
                    { 7, 2, 3, 4 },
                    { 8, 3, 1, 3 },
                    { 9, 4, 2, 2 },
                    { 10, 4, 1, 1 },
                    { 11, 4, 3, 2 },
                    { 12, 4, 4, 3 },
                    { 13, 4, 5, 4 },
                    { 14, 5, 4, 5 },
                    { 15, 5, 3, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_UnitTypeId",
                table: "product",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_CustomerId",
                table: "purchase",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_ProductId",
                table: "purchase",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchase");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "unitType");
        }
    }
}
