using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerOrderManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePersonalInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalInformation",
                table: "PersonalInformation");

            migrationBuilder.DropIndex(
                name: "IX_PersonalInformation_EmployeeId",
                table: "PersonalInformation");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PersonalInformation");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "EmployeeIDNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalInformation",
                table: "PersonalInformation",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalInformation",
                table: "PersonalInformation");

            migrationBuilder.RenameColumn(
                name: "EmployeeIDNo",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PersonalInformation",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0)
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalInformation",
                table: "PersonalInformation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformation_EmployeeId",
                table: "PersonalInformation",
                column: "EmployeeId",
                unique: true);
        }
    }
}
