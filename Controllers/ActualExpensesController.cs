using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudgetMaster.Data;
using BudgetMaster.Models;

namespace BudgetMaster.Controllers
{
    public class ActualExpensesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActualExpensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActualExpenses
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActualExpenses.ToListAsync());
        }

        // GET: ActualExpenses/Details/5
        public async Task<IActionResult> Details(int? id)
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
