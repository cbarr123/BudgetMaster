using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudgetMaster.Data;
using BudgetMaster.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BudgetMaster.Controllers
{
    [Authorize]
    public class ProjectedExpensesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectedExpensesController(ApplicationDbContext context, UserManager<ApplicationUser>userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: ProjectedExpenses
        public async Task<IActionResult> Index()
        {
            var maxYear = _context.Budgets.Max(b => b.CreatedYear);
            var maxMonth = _context.Budgets.Max(b => b.CreatedMonth);
            var user = await GetCurrentUserAsync();
            var userProjectedExpense = await _context.ProjectedExpenses
                .Include(b => b.Budget)
                .Where(b => b.Budget.User == user)
                .Where(b => b.Budget.CreatedYear == maxYear && b.Budget.CreatedMonth == maxMonth)
                .ToListAsync();
                return View(userProjectedExpense);
        }

        // GET: ProjectedExpenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await GetCurrentUserAsync();
            var projectedExpense = await _context.ProjectedExpenses
                .Include(b => b.Budget)
                .Where(b =>b.Budget.User == user)
                .FirstOrDefaultAsync(m => m.ProjectedExpenseId == id);
            if (projectedExpense == null)
            {
                return NotFound();
            }

            return View(projectedExpense);
        }

        // GET: ProjectedExpenses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectedExpenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectedExpenseId,BudgetId,ExpenseCategoryId,Amount")] ProjectedExpense projectedExpense)
        {
            if (ModelState.IsValid)
            {
                //TODO need to associate this expense budget with a specific budget
                _context.Add(projectedExpense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectedExpense);
        }

        // GET: ProjectedExpenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectedExpense = await _context.ProjectedExpenses.FindAsync(id);
            if (projectedExpense == null)
            {
                return NotFound();
            }
            return View(projectedExpense);
        }

        // POST: ProjectedExpenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectedExpenseId,BudgetId,ExpenseCategoryId,Amount")] ProjectedExpense projectedExpense)
        {
            if (id != projectedExpense.ProjectedExpenseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectedExpense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectedExpenseExists(projectedExpense.ProjectedExpenseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(projectedExpense);
        }

        // GET: ProjectedExpenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectedExpense = await _context.ProjectedExpenses
                .FirstOrDefaultAsync(m => m.ProjectedExpenseId == id);
            if (projectedExpense == null)
            {
                return NotFound();
            }

            return View(projectedExpense);
        }

        // POST: ProjectedExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectedExpense = await _context.ProjectedExpenses.FindAsync(id);
            _context.ProjectedExpenses.Remove(projectedExpense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectedExpenseExists(int id)
        {
            return _context.ProjectedExpenses.Any(e => e.ProjectedExpenseId == id);
        }
    }
}
