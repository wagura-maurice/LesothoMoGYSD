using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoGYSD.ViewModels.Missa.Setups
{
    public class GradeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Class/ Grade is required.")]
        [StringLength(3, ErrorMessage = "Class/ Grade cannot exceed 3 digits.")]
        [RegularExpression(@"^\d{1,3}$", ErrorMessage = "Class/ Grade must be a number with up to 3 digits.")]
        public string Code { get; set; }
        public int FacilityId { get; set; }
        public bool IsActive { get; set; }
    }
}
