using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventoryx.Data.Migrations
{
    public partial class changedAllocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Employee_EmployeeId",
                table: "Allocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Equipment_EquipmentId",
                table: "Allocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allocation",
                table: "Allocation");

            migrationBuilder.RenameTable(
                name: "Allocation",
                newName: "EquipmentAllocation");

            migrationBuilder.RenameIndex(
                name: "IX_Allocation_EquipmentId",
                table: "EquipmentAllocation",
                newName: "IX_EquipmentAllocation_EquipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Allocation_EmployeeId",
                table: "EquipmentAllocation",
                newName: "IX_EquipmentAllocation_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentAllocation",
                table: "EquipmentAllocation",
                column: "EquipmentAllocationId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentAllocation_Employee_EmployeeId",
                table: "EquipmentAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentAllocation_Equipment_EquipmentId",
                table: "EquipmentAllocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentAllocation",
                table: "EquipmentAllocation");

            migrationBuilder.RenameTable(
                name: "EquipmentAllocation",
                newName: "Allocation");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentAllocation_EquipmentId",
                table: "Allocation",
                newName: "IX_Allocation_EquipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentAllocation_EmployeeId",
                table: "Allocation",
                newName: "IX_Allocation_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allocation",
                table: "Allocation",
                column: "EquipmentAllocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Employee_EmployeeId",
                table: "Allocation",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Equipment_EquipmentId",
                table: "Allocation",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "EquipmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
