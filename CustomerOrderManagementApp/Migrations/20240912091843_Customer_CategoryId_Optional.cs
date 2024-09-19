using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerOrderManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class Customer_CategoryId_Optional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomersCategories_CategoryId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Customers",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomersCategories_CategoryId",
                table: "Customers",
                column: "CategoryId",
                principalTable: "CustomersCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomersCategories_CategoryId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Customers",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomersCategories_CategoryId",
                table: "Customers",
                column: "CategoryId",
                principalTable: "CustomersCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
