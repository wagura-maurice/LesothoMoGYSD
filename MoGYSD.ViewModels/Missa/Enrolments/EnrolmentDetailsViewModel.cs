using System;
using System.ComponentModel.DataAnnotations;

namespace MoGYSD.Business.ViewModels.Missa.Enrolments
{
    /// <summary>
    /// Represents a view model for EnrolmentDetails, designed for UI display and data transfer.
    /// </summary>
    public class EnrolmentDetailsViewModel
    {
        [Display(Name = "Enrolment Detail ID")]
        public int EnrolmentDetailId { get; set; }

        [Required(ErrorMessage = "Enrolment is required.")]
        [Display(Name = "Enrolment")]
        public int EnrolmentId { get; set; }

        [Required(ErrorMessage = "Household Member is required.")]
        [Display(Name = "Household Member")]
        public int HouseholdMemberId { get; set; }

        [Display(Name = "Household Member Name")]
        public string HouseholdMemberFullName { get; set; }

        [Required(ErrorMessage = "Grade is required.")]
        [Display(Name = "Grade")]
        public int GradeId { get; set; }

        [Display(Name = "Grade Name")]
        public string GradeName { get; set; }

        [Display(Name = "Created By (ID)")]
        public string CreatedById { get; set; }

        [Display(Name = "Created By")]
        public string CreatedByName { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Modified By (ID)")]
        public string ModifiedById { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedByName { get; set; }

        [Display(Name = "Modified On")]
        public DateTime ModifiedOn { get; set; }
    }
}
