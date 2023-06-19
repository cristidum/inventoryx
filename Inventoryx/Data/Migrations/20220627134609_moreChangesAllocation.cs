using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventoryx.Data.Migrations
{
    public partial class moreChangesAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EquipmentAllocation_EmployeeId",
                table: "EquipmentAllocation");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentAllocation_EquipmentId",
                table: "EquipmentAllocation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAllocation_EmployeeId",
                table: "EquipmentAllocation",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAllocation_EquipmentId",
                table: "EquipmentAllocation",
                column: "EquipmentId",
                unique: true);
        }
    }
}
