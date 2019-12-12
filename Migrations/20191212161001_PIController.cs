using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetMaster.Migrations
{
    public partial class PIController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectedIncomeId",
                table: "Budgets",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c047945e-1f67-40af-9942-10cf3663c815", "AQAAAAEAACcQAAAAEDrLOKZDftVlX0HdgU4fyduhoc/HfQYRq6+BvdziWX8dDBSs+66G1KaiszNHcNbnOQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-fffffffffffg",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a58ef938-047c-4a7b-98be-1e75e1628981", "AQAAAAEAACcQAAAAEK8ST8OazWm9dGyi4wrqrOhQ1CAky9PEYLiRO5AFuQcc8Uiq9LtTEh4ffcMKZ71XKA==" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectedIncomes_BudgetId",
                table: "ProjectedIncomes",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectedIncomes_IncomeCategoryId",
                table: "ProjectedIncomes",
                column: "IncomeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectedExpenses_BudgetId",
                table: "ProjectedExpenses",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectedExpenses_ExpenseCategoryId",
                table: "ProjectedExpenses",
                column: "ExpenseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_ProjectedIncomeId",
                table: "Budgets",
                column: "ProjectedIncomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_ProjectedIncomes_ProjectedIncomeId",
                table: "Budgets",
                column: "ProjectedIncomeId",
                principalTable: "ProjectedIncomes",
                principalColumn: "ProjectedIncomeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectedExpenses_Budgets_BudgetId",
                table: "ProjectedExpenses",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "BudgetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectedExpenses_ExpenseCategories_ExpenseCategoryId",
                table: "ProjectedExpenses",
                column: "ExpenseCategoryId",
                principalTable: "ExpenseCategories",
                principalColumn: "ExpenseCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectedIncomes_Budgets_BudgetId",
                table: "ProjectedIncomes",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "BudgetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectedIncomes_IncomeCategories_IncomeCategoryId",
                table: "ProjectedIncomes",
                column: "IncomeCategoryId",
                principalTable: "IncomeCategories",
                principalColumn: "IncomeCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_ProjectedIncomes_ProjectedIncomeId",
                table: "Budgets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectedExpenses_Budgets_BudgetId",
                table: "ProjectedExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectedExpenses_ExpenseCategories_ExpenseCategoryId",
                table: "ProjectedExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectedIncomes_Budgets_BudgetId",
                table: "ProjectedIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectedIncomes_IncomeCategories_IncomeCategoryId",
                table: "ProjectedIncomes");

            migrationBuilder.DropIndex(
                name: "IX_ProjectedIncomes_BudgetId",
                table: "ProjectedIncomes");

            migrationBuilder.DropIndex(
                name: "IX_ProjectedIncomes_IncomeCategoryId",
                table: "ProjectedIncomes");

            migrationBuilder.DropIndex(
                name: "IX_ProjectedExpenses_BudgetId",
                table: "ProjectedExpenses");

            migrationBuilder.DropIndex(
                name: "IX_ProjectedExpenses_ExpenseCategoryId",
                table: "ProjectedExpenses");

            migrationBuilder.DropIndex(
                name: "IX_Budgets_ProjectedIncomeId",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "ProjectedIncomeId",
                table: "Budgets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d4007095-617f-4549-aba5-9711919a76a7", "AQAAAAEAACcQAAAAEM3yzlbst26Vu26uBX3qUAXbGapilGP6A8PE9kXyHBdgCo0yUC3dsMONjdQyT0mRbQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-fffffffffffg",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9e476ee9-e7e7-4397-bb8d-9e48375ad173", "AQAAAAEAACcQAAAAEFBBlLSGI/Dbs3AcCQH7KmWoxgpZMvZ8o4fpfS8Ow6KHZcB1vdsRYkLzlh/DCmayyQ==" });
        }
    }
}
