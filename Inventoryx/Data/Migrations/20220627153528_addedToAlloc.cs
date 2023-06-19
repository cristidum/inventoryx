using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventoryx.Data.Migrations
{
    public partial class addedToAlloc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EquipmentSN",
                table: "EquipmentAllocation",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentSN",
                table: "EquipmentAllocation");
        }
    }
}
