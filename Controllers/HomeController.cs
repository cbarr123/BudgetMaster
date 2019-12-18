﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BudgetMaster.Models;
using BudgetMaster.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using BudgetMaster.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace BudgetMaster.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }
       
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> Index()
        {

            //get the most current user and most recent budget fot the user
            var user = await GetCurrentUserAsync();
            //var maxYear = _context.Budgets.Max(b => b.CreatedYear);
            //var maxMonth = _context.Budgets.Max(b => b.CreatedMonth);

            var userBudgetMaxYear = _context.Budgets
                .Where(b => b.UserId == user.Id)
                .Max(b => b.CreatedYear);
            var userBudgetMaxMonth = _context.Budgets
                .Where(b => b.UserId == user.Id)
                .Max(b => b.CreatedMonth);

            var userBudget = await _context.Budgets
                .Include(b => b.ProjectedIncomes)
                .Include(b => b.ProjectedExpenses)
                .Include(b => b.ActualIncomes)
                .Include(b => b.ActualExpenses)
                .Where(b => b.UserId == user.Id)
                .Where(b => b.CreatedYear == userBudgetMaxYear && b.CreatedMonth == userBudgetMaxMonth)
                .FirstOrDefaultAsync();

            //ViewBag.BudgetId = userBudget.BudgetId;

            var incomeCats = await _context.IncomeCategories.ToListAsync();
            var expenseCats = await _context.ExpenseCategories.ToListAsync();
       
            //var currentBudget = userBudget.BudgetId;
           
            
            HttpContext.Session.SetInt32("budgetKey", userBudget.BudgetId);
            var BudgetKey = HttpContext.Session.GetInt32("budgetKey");

            var HomeView = new HomeViewModel
            {
                Budget = userBudget,
                //IncomeCategories = incomeCats,
                //ExpenseCategories = expenseCats
            };

            return View(HomeView);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
