using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BudgetMaster.Models.ViewModels
{
    public class ActualExpenseCreateViewModel
    {
        public ActualExpense ActualExpense { get; set; }
        public List<ExpenseCategory> ExpenseCats { get; set; } = new List<ExpenseCategory>();
        public List<SelectListItem> ExpenseCategoryOptions
        {
            get
            {
                if (ExpenseCats == null) return null;
                List<SelectListItem> selectItems = ExpenseCats
                    .Select(ic => new SelectListItem(ic.Label, ic.ExpenseCategoryId.ToString()))
                    .ToList();
                selectItems.Insert(0, new SelectListItem
                {
                    Text = "Choose Expense Category...",
                    Value = ""
                });
                return selectItems;

            }
        }
    }
}
