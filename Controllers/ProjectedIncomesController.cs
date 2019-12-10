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
    public class ProjectedIncomesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectedIncomesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectedIncomes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProjectedIncomes.ToListAsync());
        }

        // GET: ProjectedIncomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectedIncome = await _context.ProjectedIncomes
                .FirstOrDefaultAsync(m => m.ProjectedIncomeId == id);
            if (projectedIncome == null)
            {
                return NotFound();
            }

            return View(projectedIncome);
        }

        // GET: ProjectedIncomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectedIncomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectedIncomeId,BudgetId,IncomeCategoryId,Amount")] ProjectedIncome projectedIncome)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectedIncome);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectedIncome);
        }

        // GET: ProjectedIncomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectedIncome = await _context.ProjectedIncomes.FindAsync(id);
            if (projectedIncome == null)
            {
                return NotFound();
            }
            return View(projectedIncome);
        }

        // POST: ProjectedIncomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectedIncomeId,BudgetId,IncomeCategoryId,Amount")] ProjectedIncome projectedIncome)
        {
            if (id != projectedIncome.ProjectedIncomeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectedIncome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectedIncomeExists(projectedIncome.ProjectedIncomeId))
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
            return View(projectedIncome);
        }

        // GET: ProjectedIncomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectedIncome = await _context.ProjectedIncomes
                .FirstOrDefaultAsync(m => m.ProjectedIncomeId == id);
            if (projectedIncome == null)
            {
                return NotFound();
            }

            return View(projectedIncome);
        }

        // POST: ProjectedIncomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectedIncome = await _context.ProjectedIncomes.FindAsync(id);
            _context.ProjectedIncomes.Remove(projectedIncome);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectedIncomeExists(int id)
        {
            return _context.ProjectedIncomes.Any(e => e.ProjectedIncomeId == id);
        }
    }
}
