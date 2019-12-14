using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetMaster.Models.ViewModels
{
    public class AllBudgetsViewModel
    {
        //Info for Projected Income
 
        public ICollection<ProjectedIncome> ProjectedIncomes { get; set; }

        //Infor for Projected Expense
        public ICollection<ProjectedIncome> ProjectedExpenses { get; set; }
        //Infor for Actual Income
        public ICollection<ActualIncome> ActualIncomes { get; set; }
        //Info for Actual Expense
        //public ICollection<ActualExpense> ActualExpenses { get; set; }
        public Budget Budget { get; set; }
        public int BudgetId { get; set; }

    }
}
