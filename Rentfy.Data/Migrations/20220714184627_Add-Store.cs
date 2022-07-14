using Microsoft.EntityFrameworkCore.Migrations;

namespace Rentfy.Data.Migrations
{
    public partial class AddStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StoreId",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegalPersonId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_LegalPerson_LegalPersonId",
                        column: x => x.LegalPersonId,
                        principalTable: "LegalPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_StoreId",
                table: "Product",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_LegalPersonId",
                table: "Store",
                column: "LegalPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Store_StoreId",
                table: "Product",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Store_StoreId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Product_StoreId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Product");
        }
    }
}
