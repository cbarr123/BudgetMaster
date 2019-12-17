using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetMaster.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Label = table.Column<string>(nullable: false),
                    BudgetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategories", x => x.ExpenseCategoryId);
                    table.ForeignKey(
                        name: "FK_ExpenseCategories_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "BudgetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncomeCategories",
                columns: table => new
                {
                    IncomeCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(nullable: false),
                    BudgetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeCategories", x => x.IncomeCategoryId);
                    table.ForeignKey(
                        name: "FK_IncomeCategories_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "BudgetId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    table.ForeignKey(
                        name: "FK_ActualExpenses_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "BudgetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActualExpenses_ExpenseCategories_ExpenseCategoryId",
                        column: x => x.ExpenseCategoryId,
                        principalTable: "ExpenseCategories",
                        principalColumn: "ExpenseCategoryId",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_ProjectedExpenses_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "BudgetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectedExpenses_ExpenseCategories_ExpenseCategoryId",
                        column: x => x.ExpenseCategoryId,
                        principalTable: "ExpenseCategories",
                        principalColumn: "ExpenseCategoryId",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_ActualIncomes_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "BudgetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActualIncomes_IncomeCategories_IncomeCategoryId",
                        column: x => x.IncomeCategoryId,
                        principalTable: "IncomeCategories",
                        principalColumn: "IncomeCategoryId",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_ProjectedIncomes_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "BudgetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectedIncomes_IncomeCategories_IncomeCategoryId",
                        column: x => x.IncomeCategoryId,
                        principalTable: "IncomeCategories",
                        principalColumn: "IncomeCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "64a632c8-5a50-44b5-9782-e82c66904561", "admin@admin.com", true, "Admina", "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEHQzq2OB58e82RO0aVKQEJvzUOtNzKZWRd/BAnBe5VCpxAfTwdjS6LskH1rwOz7UCw==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", "123 Infinity Way", false, "admin@admin.com" },
                    { "00000000-ffff-ffff-ffff-fffffffffffg", 0, "86f87d53-5666-4f96-9037-d57628ae7f3f", "tom@cat.com", true, "Tom", "Cat", false, null, "TOM@CAT.COM", "TOM@CAT.COM", "AQAAAAEAACcQAAAAELuofd4cTlrHESsO1fdKrtUVmgbJcBxs2G/4uQYX328npUAJ0zSE1tLFZPXGG/t6+Q==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794578", "123 Feline Way", false, "tom@cat.com" }
                });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "ExpenseCategoryId", "BudgetId", "Label" },
                values: new object[,]
                {
                    { 1, null, "House Payment" },
                    { 2, null, "Car Payment" }
                });

            migrationBuilder.InsertData(
                table: "IncomeCategories",
                columns: new[] { "IncomeCategoryId", "BudgetId", "Label" },
                values: new object[,]
                {
                    { 1, null, "Salary - 1" },
                    { 2, null, "Salary - 2" }
                });

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "BudgetId", "CreatedMonth", "CreatedYear", "UserId" },
                values: new object[] { 1, 11, 2019, "00000000-ffff-ffff-ffff-ffffffffffff" });

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

            migrationBuilder.CreateIndex(
                name: "IX_ActualExpenses_BudgetId",
                table: "ActualExpenses",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualExpenses_ExpenseCategoryId",
                table: "ActualExpenses",
                column: "ExpenseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualIncomes_BudgetId",
                table: "ActualIncomes",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualIncomes_IncomeCategoryId",
                table: "ActualIncomes",
                column: "IncomeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_UserId",
                table: "Budgets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCategories_BudgetId",
                table: "ExpenseCategories",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeCategories_BudgetId",
                table: "IncomeCategories",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectedExpenses_BudgetId",
                table: "ProjectedExpenses",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectedExpenses_ExpenseCategoryId",
                table: "ProjectedExpenses",
                column: "ExpenseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectedIncomes_BudgetId",
                table: "ProjectedIncomes",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectedIncomes_IncomeCategoryId",
                table: "ProjectedIncomes",
                column: "IncomeCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActualExpenses");

            migrationBuilder.DropTable(
                name: "ActualIncomes");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ProjectedExpenses");

            migrationBuilder.DropTable(
                name: "ProjectedIncomes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ExpenseCategories");

            migrationBuilder.DropTable(
                name: "IncomeCategories");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
