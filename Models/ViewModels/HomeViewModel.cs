using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetMaster.Models.ViewModels
{
    public class HomeViewModel
    {
        public Budget Budget { get; set; }
        public ICollection<IncomeCategory> IncomeCategories { get; set; }
        public ICollection<ExpenseCategory> ExpenseCategories { get; set; }



    }
}
