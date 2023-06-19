using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventoryx.Data.Migrations
{
    public partial class changedAllocation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "EquipmentAllocation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EquipmentName",
                table: "EquipmentAllocation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EquipmentAllocation_EmployeeId",
                table: "EquipmentAllocation");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentAllocation_EquipmentId",
                table: "EquipmentAllocation");

            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "EquipmentAllocation");

            migrationBuilder.DropColumn(
                name: "EquipmentName",
                table: "EquipmentAllocation");
        }
    }
}
