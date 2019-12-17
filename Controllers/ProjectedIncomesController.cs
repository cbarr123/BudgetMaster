using BudgetMaster.Data;
using BudgetMaster.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetMaster.Controllers
{
    [Authorize]
    public class ProjectedIncomesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectedIncomesController(ApplicationDbContext context, UserManager<ApplicationUser>userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        
        // GET: ProjectedIncomes
        public async Task<IActionResult> Index()
        {
            var maxYear = _context.Budgets.Max(b => b.CreatedYear);
            var maxMonth = _context.Budgets.Max(b => b.CreatedMonth);
            var user = await GetCurrentUserAsync(); 
            var userProjectedIncome = await _context.ProjectedIncomes
                .Include(b => b.Budget)
                .Where(b => b.Budget.User == user)
                .Where(b => b.Budget.CreatedYear == maxYear && b.Budget.CreatedMonth == maxMonth)
                .ToListAsync();
                return View(userProjectedIncome);
            
        }

        // GET: ProjectedIncomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await GetCurrentUserAsync();
            var projectedIncome = await _context.ProjectedIncomes
                .Include(b => b.Budget)
                .Where(b => b.Budget.User == user)
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
                var user = await _userManager.GetUserAsync(HttpContext.User);
                //TODO: need to associate this income budget with a specific budget
                //(like this sort of)var currentBudget = await _context.Budgets.FindAsync(Id);
                
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
