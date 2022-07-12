using Microsoft.EntityFrameworkCore.Migrations;

namespace Rentfy.Data.Migrations
{
    public partial class AddLegalPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LegalPerson",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    FantasyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalPerson_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegalPerson");
        }
    }
}
