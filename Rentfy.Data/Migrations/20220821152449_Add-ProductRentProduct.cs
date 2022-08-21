using Microsoft.EntityFrameworkCore.Migrations;

namespace Rentfy.Data.Migrations
{
    public partial class AddProductRentProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductRentProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ProductRentId = table.Column<long>(type: "bigint", nullable: false),
                    RentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRentProduct", x => new { x.ProductRentId, x.RentId });
                    table.ForeignKey(
                        name: "FK_ProductRentProduct_Rent_RentId",
                        column: x => x.RentId,
                        principalTable: "Rent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProductRentProduct_RentProduct_ProductRentId",
                        column: x => x.ProductRentId,
                        principalTable: "RentProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRentProduct_RentId",
                table: "ProductRentProduct",
                column: "RentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductRentProduct");
        }
    }
}
