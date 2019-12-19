using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetMaster.Models.ViewModels
{
    public class ProjectedIncomeCreateViewModel
    {
        public ProjectedIncome ProjectedIncome { get; set; }
        public List<IncomeCategory> IncomeCats { get; set; } = new List<IncomeCategory>();
        public List<SelectListItem> IncomeCategoryOptions
        {   
            get
            {
                if (IncomeCats == null) return null;
                List<SelectListItem> selectItems = IncomeCats
                    .Select(ic => new SelectListItem(ic.Label, ic.IncomeCategoryId.ToString()))
                    .ToList();
                selectItems.Insert(0, new SelectListItem
                {
                    Text = "Choose Income Category...",
                    Value = ""
                });
                return selectItems;

            }
        }

    }
}
