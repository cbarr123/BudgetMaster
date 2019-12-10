using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetMaster.Migrations
{
    public partial class ModelsAndDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActualExpenses",
                columns: table => new
                {
                    ActualExpenseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetId = table.Column<int>(nullable: false),
                    ExpenseCategoryId = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualExpenses", x => x.ActualExpenseId);
                });

            migrationBuilder.CreateTable(
                name: "ActualIncomes",
                columns: table => new
                {
                    ActualIncomeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetId = table.Column<int>(nullable: false),
                    IncomeCategoryId = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualIncomes", x => x.ActualIncomeId);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    BudgetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    CreatedMonth = table.Column<int>(nullable: false),
                    CreatedYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.BudgetId);
                    table.ForeignKey(
                        name: "FK_Budgets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseCategories",
                columns: table => new
                {
                    ExpenseCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategories", x => x.ExpenseCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "IncomeCategories",
                columns: table => new
                {
                    IncomeCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeCategories", x => x.IncomeCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectedExpenses",
                columns: table => new
                {
                    ProjectedExpenseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetId = table.Column<int>(nullable: false),
                    ExpenseCategoryId = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectedExpenses", x => x.ProjectedExpenseId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectedIncomes",
                columns: table => new
                {
                    ProjectedIncomeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetId = table.Column<int>(nullable: false),
                    IncomeCategoryId = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectedIncomes", x => x.ProjectedIncomeId);
                });

            migrationBuilder.InsertData(
                table: "ActualExpenses",
                columns: new[] { "ActualExpenseId", "Amount", "BudgetId", "ExpenseCategoryId" },
                values: new object[,]
                {
                    { 1, 1000.0, 1, 1 },
                    { 2, 500.0, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "ActualIncomes",
                columns: new[] { "ActualIncomeId", "Amount", "BudgetId", "IncomeCategoryId" },
                values: new object[,]
                {
                    { 1, 2000.0, 1, 1 },
                    { 2, 500.0, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "d4007095-617f-4549-aba5-9711919a76a7", "admin@admin.com", true, "Admina", "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEM3yzlbst26Vu26uBX3qUAXbGapilGP6A8PE9kXyHBdgCo0yUC3dsMONjdQyT0mRbQ==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", "123 Infinity Way", false, "admin@admin.com" },
                    { "00000000-ffff-ffff-ffff-fffffffffffg", 0, "9e476ee9-e7e7-4397-bb8d-9e48375ad173", "tom@cat.com", true, "Tom", "Cat", false, null, "TOM@CAT.COM", "TOM@CAT.COM", "AQAAAAEAACcQAAAAEFBBlLSGI/Dbs3AcCQH7KmWoxgpZMvZ8o4fpfS8Ow6KHZcB1vdsRYkLzlh/DCmayyQ==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794578", "123 Feline Way", false, "tom@cat.com" }
                });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "ExpenseCategoryId", "Label" },
                values: new object[,]
                {
                    { 1, "House Payment" },
                    { 2, "Car Payment" }
                });

            migrationBuilder.InsertData(
                table: "IncomeCategories",
                columns: new[] { "IncomeCategoryId", "Label" },
                values: new object[,]
                {
                    { 1, "Salary - 1" },
                    { 2, "Salary - 2" }
                });

            migrationBuilder.InsertData(
                table: "ProjectedExpenses",
                columns: new[] { "ProjectedExpenseId", "Amount", "BudgetId", "ExpenseCategoryId" },
                values: new object[,]
                {
                    { 1, 1000.0, 1, 1 },
                    { 2, 500.0, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProjectedIncomes",
                columns: new[] { "ProjectedIncomeId", "Amount", "BudgetId", "IncomeCategoryId" },
                values: new object[,]
                {
                    { 1, 2000.0, 1, 1 },
                    { 2, 2000.0, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "BudgetId", "CreatedMonth", "CreatedYear", "UserId" },
                values: new object[] { 1, 11, 2019, "00000000-ffff-ffff-ffff-ffffffffffff" });

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_UserId",
                table: "Budgets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActualExpenses");

            migrationBuilder.DropTable(
                name: "ActualIncomes");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "ExpenseCategories");

            migrationBuilder.DropTable(
                name: "IncomeCategories");

            migrationBuilder.DropTable(
                name: "ProjectedExpenses");

            migrationBuilder.DropTable(
                name: "ProjectedIncomes");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-fffffffffffg");
        }
    }
}
