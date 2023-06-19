using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventoryx.Data.Migrations
{
    public partial class addedADName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ADName",
                table: "Equipment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ADName",
                table: "Equipment");
        }
    }
}
