using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetMaster.Models
{
    public class ActualExpense
    {
        [Key]
        public int ActualExpenseId { get; set; }
        [Required]
        public int BudgetId { get; set; }
        [Required]
        public int ExpenseCategoryId { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}
