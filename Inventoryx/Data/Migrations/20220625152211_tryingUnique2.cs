using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventoryx.Data.Migrations
{
    public partial class tryingUnique2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "Equipment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ADName",
                table: "Equipment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_ADName",
                table: "Equipment",
                column: "ADName",
                unique: true,
                filter: "[ADName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_SerialNumber",
                table: "Equipment",
                column: "SerialNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Equipment_ADName",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_SerialNumber",
                table: "Equipment");

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "Equipment",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ADName",
                table: "Equipment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
