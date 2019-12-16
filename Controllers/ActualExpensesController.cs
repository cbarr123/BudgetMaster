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
    public class ActualExpensesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ActualExpensesController(ApplicationDbContext context, UserManager<ApplicationUser>userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: ActualExpenses
        public async Task<IActionResult> Index()
        {
            var maxYear = _context.Budgets.Max(b => b.CreatedYear);
            var maxMonth = _context.Budgets.Max(b => b.CreatedMonth);
            var user = await GetCurrentUserAsync();
            var userActualExpense = await _context.ActualExpenses
                .Include(b => b.Budget)
                .Where(b => b.Budget.User == user)
                .Where(b => b.Budget.CreatedYear == maxYear && b.Budget.CreatedMonth == maxMonth)
                .ToListAsync();
                return View(userActualExpense);
        }

        // GET: ActualExpenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await GetCurrentUserAsync();
            var actualExpense = await _context.ActualExpenses
                .Include(b => b.Budget)
                .Where(b => b.Budget.User == user)
                .FirstOrDefaultAsync(m => m.ActualExpenseId == id);
            if (actualExpense == null)
            {
                return NotFound();
            }

            return View(actualExpense);
        }

        // GET: ActualExpenses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActualExpenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActualExpenseId,BudgetId,ExpenseCategoryId,Amount")] ActualExpense actualExpense)
        {
            if (ModelState.IsValid)
            {
               //TODO need to associate this actual expense with the appropriate budget
                _context.Add(actualExpense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actualExpense);
        }

        // GET: ActualExpenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actualExpense = await _context.ActualExpenses.FindAsync(id);
            if (actualExpense == null)
            {
                return NotFound();
            }
            return View(actualExpense);
        }

        // POST: ActualExpenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActualExpenseId,BudgetId,ExpenseCategoryId,Amount")] ActualExpense actualExpense)
        {
            if (id != actualExpense.ActualExpenseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actualExpense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActualExpenseExists(actualExpense.ActualExpenseId))
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
            return View(actualExpense);
        }

        // GET: ActualExpenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actualExpense = await _context.ActualExpenses
                .FirstOrDefaultAsync(m => m.ActualExpenseId == id);
            if (actualExpense == null)
            {
                return NotFound();
            }

            return View(actualExpense);
        }

        // POST: ActualExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actualExpense = await _context.ActualExpenses.FindAsync(id);
            _context.ActualExpenses.Remove(actualExpense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActualExpenseExists(int id)
        {
            return _context.ActualExpenses.Any(e => e.ActualExpenseId == id);
        }
    }
}
