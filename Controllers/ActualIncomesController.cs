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
    public class ActualIncomesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ActualIncomesController(ApplicationDbContext context, UserManager<ApplicationUser>userManager)

        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: ActualIncomes
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var userActualIncome = await _context.ActualIncomes
                .Include(b => b.Budget)
                .Where(b => b.Budget.User == user)
                .ToListAsync();

                return View(userActualIncome);
        }

        // GET: ActualIncomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await GetCurrentUserAsync();
            var actualIncome = await _context.ActualIncomes
                .Include(b => b.Budget)
                .Where(b => b.Budget.User == user)
                .FirstOrDefaultAsync(m => m.ActualIncomeId == id);
            if (actualIncome == null)
            {
                return NotFound();
            }

            return View(actualIncome);
        }

        // GET: ActualIncomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActualIncomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActualIncomeId,BudgetId,IncomeCategoryId,Amount")] ActualIncome actualIncome)
        {
            if (ModelState.IsValid)
            {
                //TODO need to associate this actual income with the appropriate budget
                _context.Add(actualIncome);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actualIncome);
        }

        // GET: ActualIncomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actualIncome = await _context.ActualIncomes.FindAsync(id);
            if (actualIncome == null)
            {
                return NotFound();
            }
            return View(actualIncome);
        }

        // POST: ActualIncomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActualIncomeId,BudgetId,IncomeCategoryId,Amount")] ActualIncome actualIncome)
        {
            if (id != actualIncome.ActualIncomeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actualIncome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActualIncomeExists(actualIncome.ActualIncomeId))
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
            return View(actualIncome);
        }

        // GET: ActualIncomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actualIncome = await _context.ActualIncomes
                .FirstOrDefaultAsync(m => m.ActualIncomeId == id);
            if (actualIncome == null)
            {
                return NotFound();
            }

            return View(actualIncome);
        }

        // POST: ActualIncomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actualIncome = await _context.ActualIncomes.FindAsync(id);
            _context.ActualIncomes.Remove(actualIncome);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActualIncomeExists(int id)
        {
            return _context.ActualIncomes.Any(e => e.ActualIncomeId == id);
        }
    }
}
