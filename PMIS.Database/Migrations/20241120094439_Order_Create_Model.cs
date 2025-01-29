using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerOrderManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class Order_Create_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "EmployeeOfficialId",
            //    table: "Employees",
            //    type: "NUMBER(10)",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateTable(
            //    name: "EmployeeOfficial",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
            //            .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EmployeeOfficial", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Employees_EmployeeOfficialId",
            //    table: "Employees",
            //    column: "EmployeeOfficialId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Employees_EmployeeOfficial_EmployeeOfficialId",
            //    table: "Employees",
            //    column: "EmployeeOfficialId",
            //    principalTable: "EmployeeOfficial",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeOfficial_EmployeeOfficialId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeOfficial");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeOfficialId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeOfficialId",
                table: "Employees");
        }
    }
}
