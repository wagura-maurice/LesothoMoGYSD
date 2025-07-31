using System;
using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Missa.Programmes
{
    /// <summary>
    /// ViewModel for ValidationDetail entity, representing a community validation outcome.
    /// </summary>
    public class ValidationDetailViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Validation List")]
        public int ValidationListId { get; set; }

        [Required]
        [Display(Name = "Household Member")]
        public int HouseholdMemberId { get; set; }
        public string HouseholdMemberName { get; set; }

        [Required]
        [Display(Name = "Validation Status")]
        public int? ValidationStatusId { get; set; }
        public string ValidationStatusName { get; set; }
    }
}
