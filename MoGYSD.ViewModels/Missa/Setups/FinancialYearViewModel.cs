using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoGYSD.ViewModels.Missa.Setups
{
    public class FinancialYearViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [RegularExpression(@"^\d{4}/\d{2}$", ErrorMessage = "Name must be in the format YYYY/YY, e.g., 2025/26.")]
        public string Name { get; set; }


        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }
    }
}
