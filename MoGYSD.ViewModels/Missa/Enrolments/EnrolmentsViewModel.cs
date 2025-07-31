using System;
using System.ComponentModel.DataAnnotations; // Enable Data Annotations
using MoGYSD.Business.Views.Missa.Enrolments;

namespace MoGYSD.Business.ViewModels.Missa.Enrolments
{
    public class EnrolmentsViewModel
    {
        [Display(Name = "Enrolment ID")]
        public int EnrolmentId { get; set; }

        [Display(Name = "Enrolment GUID")]
        public string EnrolmentGUId { get; set; }

        [Required(ErrorMessage = "Enrolment Schedule is required.")]
        [Display(Name = "Enrolment Schedule")]
        public int EnrolmentScheduleId { get; set; }

        [Required(ErrorMessage = "Enrolment Event Detail is required.")]
        [Display(Name = "Enrolment Event Detail")]
        public int EnrolmentEventDetailId { get; set; }

        [Required(ErrorMessage = "Household is required.")]
        [Display(Name = "Household")]
        public int HouseholdId { get; set; }

        [StringLength(1000, ErrorMessage = "Postal Address cannot exceed 1000 characters.")]
        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }

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

        [Display(Name = "Enrolment Detail")]
        public EnrolmentDetailsViewModel EnrolmentDetails { get; set; }
    }
}
