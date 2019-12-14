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

namespace BudgetMaster.Controllers
{
    [Authorize]
    public class IncomeCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncomeCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IncomeCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.IncomeCategories.ToListAsync());
        }

        // GET: IncomeCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeCategory = await _context.IncomeCategories
                .FirstOrDefaultAsync(m => m.IncomeCategoryId == id);
            if (incomeCategory == null)
            {
                return NotFound();
            }

            return View(incomeCategory);
        }

        // GET: IncomeCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IncomeCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IncomeCategoryId,Label")] IncomeCategory incomeCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incomeCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incomeCategory);
        }

        // GET: IncomeCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeCategory = await _context.IncomeCategories.FindAsync(id);
            if (incomeCategory == null)
            {
                return NotFound();
            }
            return View(incomeCategory);
        }

        // POST: IncomeCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IncomeCategoryId,Label")] IncomeCategory incomeCategory)
        {
            if (id != incomeCategory.IncomeCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incomeCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomeCategoryExists(incomeCategory.IncomeCategoryId))
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
            return View(incomeCategory);
        }

        // GET: IncomeCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeCategory = await _context.IncomeCategories
                .FirstOrDefaultAsync(m => m.IncomeCategoryId == id);
            if (incomeCategory == null)
            {
                return NotFound();
            }

            return View(incomeCategory);
        }

        // POST: IncomeCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incomeCategory = await _context.IncomeCategories.FindAsync(id);
            _context.IncomeCategories.Remove(incomeCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomeCategoryExists(int id)
        {
            return _context.IncomeCategories.Any(e => e.IncomeCategoryId == id);
        }
    }
}
