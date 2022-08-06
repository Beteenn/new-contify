using Microsoft.EntityFrameworkCore.Migrations;
using Rentfy.Domain.Enumerations;
using System.Linq;

namespace Rentfy.Data.Migrations
{
    public partial class AddRentStatusEnumeration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentStatus", x => x.Id);
                });

            SeedData(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentStatus");
        }

        private void SeedData(MigrationBuilder builder)
        {
            var script = string.Join("; ", RentStatusEnumeration.GetAll().Select(x => $"INSERT INTO [dbo].[RentStatus](Id, Name) VALUES({x.Id}, '{x.Name}')"));
            builder.Sql(script);
        }
    }
}
