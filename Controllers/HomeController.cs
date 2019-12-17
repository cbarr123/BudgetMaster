using System;
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
            var user = await GetCurrentUserAsync();

            //get the most current user and most recent budget
            // 
            var maxYear = _context.Budgets.Max(b => b.CreatedYear);
            var maxMonth = _context.Budgets.Max(b => b.CreatedMonth);

            //var userRecentBudget =await _context.Budgets
            //.Where(b => b.CreatedYear == DateTime.Now.Year)
            //  .Where(b => b.CreatedYear == maxYear && b.CreatedMonth == maxMonth)
            //.FirstOrDefaultAsync();


            var userBudget = await _context.Budgets
                .Include(b => b.ProjectedIncomes)
                .Include(b => b.ProjectedExpenses)
                .Include(b => b.ActualIncomes)
                .Include(b => b.ActualExpenses)
                .Where(b => b.CreatedYear == maxYear && b.CreatedMonth == maxMonth)
                .FirstOrDefaultAsync(b => b.UserId == user.Id);

            var incomeCats = await _context.IncomeCategories.ToListAsync();
            var expenseCats = await _context.ExpenseCategories.ToListAsync();
            var HomeView = new HomeViewModel
            {
                Budget = userBudget,
                IncomeCategories = incomeCats,
                ExpenseCategories = expenseCats
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
