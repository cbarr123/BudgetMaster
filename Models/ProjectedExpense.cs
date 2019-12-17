using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetMaster.Models
{
    public class ProjectedExpense
    {
        [Key]
        public int ProjectedExpenseId { get; set; }
        [Required]
        public int BudgetId { get; set; }
        [Required]
        public int ExpenseCategoryId { get; set; }
        [Required]
        public double Amount { get; set; }
        public Budget Budget { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        //public ICollection<ExpenseCategory> ExpenseCategories { get; set; }
        //public List<ExpenseCategory> ExpenseCategoriesList { get; set; }
    }
}
