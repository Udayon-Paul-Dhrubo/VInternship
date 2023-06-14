using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Branch_Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Branch_Address = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Customer_Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Customer_DOB = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Customer_Phone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepositSchemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Schema_Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Schema_Rate = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Schema_Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositSchemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Product_Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Product_Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    User_Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    User_Password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Balance = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Branch_Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Product_Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Customer_Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Account_Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Branches_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Products_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepositAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Balance = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    status = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Account_Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DepositSchema_Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Block_no = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    autoRenewal = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Starting_Date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Tenure = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Maturity_Date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositAccounts_Accounts_Account_Id",
                        column: x => x.Account_Id,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepositAccounts_DepositSchemas_DepositSchema_Id",
                        column: x => x.DepositSchema_Id,
                        principalTable: "DepositSchemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkedAccounts",
                columns: table => new
                {
                    System_User_Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Account_Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedAccounts", x => new { x.System_User_Id, x.Account_Id });
                    table.ForeignKey(
                        name: "FK_LinkedAccounts_Accounts_Account_Id",
                        column: x => x.Account_Id,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkedAccounts_Users_System_User_Id",
                        column: x => x.System_User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Branch_Id",
                table: "Accounts",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Customer_Id",
                table: "Accounts",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Product_Id",
                table: "Accounts",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DepositAccounts_Account_Id",
                table: "DepositAccounts",
                column: "Account_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DepositAccounts_DepositSchema_Id",
                table: "DepositAccounts",
                column: "DepositSchema_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedAccounts_Account_Id",
                table: "LinkedAccounts",
                column: "Account_Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepositAccounts");

            migrationBuilder.DropTable(
                name: "LinkedAccounts");

            migrationBuilder.DropTable(
                name: "DepositSchemas");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
