using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetMaster.Models
{
    public class ProjectedIncome
    {
        [Key]
        public int ProjectedIncomeId { get; set; }
        [Required]
        public int BudgetId { get; set; }
        [Required]
        public int IncomeCategoryId { get; set; }
        [Required]
        public double Amount { get; set; }
        public Budget Budget { get; set; }
        public IncomeCategory IncomeCategory { get; set; }
       // public ICollection<ProjectedIncome> projectedIncomes { get; set; }
        //public ICollection<IncomeCategory> IncomeCategories { get; set; }
        //public List<IncomeCategory> IncomeCategoriesList { get; set; }
    }
}
