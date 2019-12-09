using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetMaster.Models
{
    public class Budget
    {
        [Key]
        public int BudgetId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        [Required]
        public int CreatedMonth { get; set; }
        [Required]
        public int CreatedYear { get; set; }


    }
}
