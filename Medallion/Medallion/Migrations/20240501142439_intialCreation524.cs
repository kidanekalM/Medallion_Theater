using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medallion.Migrations
{
    public partial class intialCreation524 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoxOfficeManagerId",
                table: "reports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoxOfficeManagerId",
                table: "productions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "boxOfficeManagerId",
                table: "performances",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "boxOfficeManagers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boxOfficeManagers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reports_BoxOfficeManagerId",
                table: "reports",
                column: "BoxOfficeManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_productions_BoxOfficeManagerId",
                table: "productions",
                column: "BoxOfficeManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_performances_boxOfficeManagerId",
                table: "performances",
                column: "boxOfficeManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_performances_boxOfficeManagers_boxOfficeManagerId",
                table: "performances",
                column: "boxOfficeManagerId",
                principalTable: "boxOfficeManagers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_productions_boxOfficeManagers_BoxOfficeManagerId",
                table: "productions",
                column: "BoxOfficeManagerId",
                principalTable: "boxOfficeManagers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_reports_boxOfficeManagers_BoxOfficeManagerId",
                table: "reports",
                column: "BoxOfficeManagerId",
                principalTable: "boxOfficeManagers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_performances_boxOfficeManagers_boxOfficeManagerId",
                table: "performances");

            migrationBuilder.DropForeignKey(
                name: "FK_productions_boxOfficeManagers_BoxOfficeManagerId",
                table: "productions");

            migrationBuilder.DropForeignKey(
                name: "FK_reports_boxOfficeManagers_BoxOfficeManagerId",
                table: "reports");

            migrationBuilder.DropTable(
                name: "boxOfficeManagers");

            migrationBuilder.DropIndex(
                name: "IX_reports_BoxOfficeManagerId",
                table: "reports");

            migrationBuilder.DropIndex(
                name: "IX_productions_BoxOfficeManagerId",
                table: "productions");

            migrationBuilder.DropIndex(
                name: "IX_performances_boxOfficeManagerId",
                table: "performances");

            migrationBuilder.DropColumn(
                name: "BoxOfficeManagerId",
                table: "reports");

            migrationBuilder.DropColumn(
                name: "BoxOfficeManagerId",
                table: "productions");

            migrationBuilder.DropColumn(
                name: "boxOfficeManagerId",
                table: "performances");
        }
    }
}
