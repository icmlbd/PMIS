using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerOrderManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateEmpAndPersonalInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EmployeeId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PresentAddress = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PermanentAddress = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FathersName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MothersName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SpousesName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SpousesOccupation = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdentificationMark = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MobileNo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TelephoneNo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Religion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MaritalStatus = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NoOfChildren = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    HomeDistrict = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BloodGroup = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PassportNo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NIDNo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BankAccountInfo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EmployeeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalInformation_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformation_EmployeeId",
                table: "PersonalInformation",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalInformation");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
