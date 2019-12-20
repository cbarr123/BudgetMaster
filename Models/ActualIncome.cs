using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetMaster.Models
{
    public class ActualIncome
    {
        [Key]
        public int ActualIncomeId { get; set; }
        [Required]
        public int BudgetId { get; set; }
        [Required]
        public int IncomeCategoryId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public Budget Budget { get; set; }
        public IncomeCategory IncomeCategory { get; set; }

    }
}
