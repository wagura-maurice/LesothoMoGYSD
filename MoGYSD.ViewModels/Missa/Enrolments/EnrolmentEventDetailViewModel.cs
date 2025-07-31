using System;
using System.ComponentModel.DataAnnotations;

namespace MoGYSD.Business.ViewModels.Missa.Enrolments
{
    public class EnrolmentEventDetailViewModel
    {
        [Display(Name = "Enrolment Event Detail ID")]
        public int EnrolmentEventDetailId { get; set; }

        [Required(ErrorMessage = "Enrolment Event is required.")]
        [Display(Name = "Enrolment Event")]
        public int EnrolmentEventId { get; set; }

        [Display(Name = "Enrolment Event Name")]
        public string EnrolmentEventName { get; set; }

        [Display(Name = "Household Member ID")]
        public int? HouseholdMemberId { get; set; }

        [Display(Name = "Household Member Full Name")]
        public string HouseholdMemberFullName { get; set; }

        [Display(Name = "Household Member ID Number")]
        public string HouseholdMemberIDNumber { get; set; }

        [Display(Name = "Household ID")]
        public int? HouseholdId { get; set; }

        [Display(Name = "Household Code")]
        public string HouseholdCode { get; set; }

        [Display(Name = "Created By ID")]
        public string CreatedById { get; set; }

        [Display(Name = "Created By")]
        public string CreatedByName { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Modified By ID")]
        public string ModifiedById { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedByName { get; set; }

        [Display(Name = "Modified On")]
        public DateTime ModifiedOn { get; set; }
    }
}
