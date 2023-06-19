using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventoryx.Data.Migrations
{
    public partial class changedAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentAllocation_Employee_EmployeeId",
                table: "EquipmentAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentAllocation_Equipment_EquipmentId",
                table: "EquipmentAllocation");

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
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAllocation_EquipmentId",
                table: "EquipmentAllocation",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentAllocation_Employee_EmployeeId",
                table: "EquipmentAllocation",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentAllocation_Equipment_EquipmentId",
                table: "EquipmentAllocation",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "EquipmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
