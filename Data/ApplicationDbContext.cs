using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BudgetMaster.Models;
using Microsoft.AspNetCore.Identity;

namespace BudgetMaster.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<ActualExpense> ActualExpenses { get; set; }
        public DbSet<ActualIncome> ActualIncomes { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        public DbSet<ProjectedExpense> ProjectedExpenses { get; set; }
        public DbSet<ProjectedIncome> ProjectedIncomes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Admina",
                LastName = "Straytor",
                StreetAddress = "123 Infinity Way",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            ApplicationUser tom = new ApplicationUser
            {
                FirstName = "Tom",
                LastName = "Cat",
                StreetAddress = "123 Feline Way",
                UserName = "tom@cat.com",
                NormalizedUserName = "TOM@CAT.COM",
                Email = "tom@cat.com",
                NormalizedEmail = "TOM@CAT.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794578",
                Id = "00000000-ffff-ffff-ffff-fffffffffffg"
            };
            var tomPasswordHash = new PasswordHasher<ApplicationUser>();
            tom.PasswordHash = passwordHash.HashPassword(tom, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(tom);


            modelBuilder.Entity<Budget>().HasData(
            new Budget()
                {
                    BudgetId = 1,
                    UserId = user.Id,
                    CreatedMonth = 11,
                    CreatedYear = 2019
                }
            );
            modelBuilder.Entity<ExpenseCategory>().HasData(
            new ExpenseCategory()
                {
                    ExpenseCategoryId = 1,
                    Label = "House Payment"
                },
            new ExpenseCategory()
                {
                    ExpenseCategoryId = 2,
                    Label = "Car Payment"
                }
            );
            modelBuilder.Entity<ProjectedExpense>().HasData(
            new ProjectedExpense()
                {
                    ProjectedExpenseId = 1,
                    BudgetId = 1,
                    ExpenseCategoryId = 1,
                    Amount = 1000.00
                },
            new ProjectedExpense()
                {
                    ProjectedExpenseId = 2,
                    BudgetId = 1,
                    ExpenseCategoryId = 2,
                    Amount = 500.00
                }
            );
            modelBuilder.Entity<ActualExpense>().HasData(
            new ActualExpense()
                {
                    ActualExpenseId = 1,
                    BudgetId = 1,
                    ExpenseCategoryId = 1,
                    Amount = 1000.00
                },
                new ActualExpense()
                {
                    ActualExpenseId = 2,
                    BudgetId = 1,
                    ExpenseCategoryId = 2,
                    Amount = 500.00
                }
            );

            modelBuilder.Entity<IncomeCategory>().HasData(
            new IncomeCategory()
                {
                    IncomeCategoryId = 1,
                    Label = "Salary - 1"
                },
            new IncomeCategory()
                {
                    IncomeCategoryId = 2,
                    Label = "Salary - 2"
                }
            );
            modelBuilder.Entity<ProjectedIncome>().HasData(
            new ProjectedIncome()
                {
                    ProjectedIncomeId = 1,
                    BudgetId = 1,
                    IncomeCategoryId = 1,
                    Amount = 2000.00
                },
                new ProjectedIncome()
                {
                    ProjectedIncomeId = 2,
                    BudgetId = 1,
                    IncomeCategoryId = 2,
                    Amount = 2000.00
                }
            );
            modelBuilder.Entity<ActualIncome>().HasData(
            new ActualIncome()
                {
                    ActualIncomeId = 1,
                    BudgetId = 1,
                    IncomeCategoryId = 1,
                    Amount = 2000.00
                },
                new ActualIncome()
                {
                    ActualIncomeId = 2,
                    BudgetId = 1,
                    IncomeCategoryId = 2,
                    Amount = 500.00
                }
            );

        }
    }
}
