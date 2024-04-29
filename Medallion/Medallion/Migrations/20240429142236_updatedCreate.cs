using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medallion.Migrations
{
    public partial class updatedCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "seats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "seats",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
