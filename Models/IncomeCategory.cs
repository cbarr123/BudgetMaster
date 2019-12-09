using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetMaster.Models
{
    public class IncomeCategory
    {
            [Key]
            public int IncomeCategoryId { get; set; }
            [Required]
            public string Label { get; set; }
    }
}
