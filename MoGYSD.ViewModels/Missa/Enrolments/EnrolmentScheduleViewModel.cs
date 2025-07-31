using System;
using System.ComponentModel.DataAnnotations;

namespace MoGYSD.Business.ViewModels.Missa.Enrolments
{
    public class EnrolmentScheduleViewModel
    {
        [Display(Name = "Enrolment Schedule ID")]
        public int EnrolmentScheduleId { get; set; }

        [Required(ErrorMessage = "Enrolment Event is required.")]
        [Display(Name = "Enrolment Event")]
        public int EnrolmentEventId { get; set; }

        [Display(Name = "Enrolment Event Name")]
        public string EnrolmentEventName { get; set; }

        [Required(ErrorMessage = "District is required.")]
        [Display(Name = "District")]
        public int DistrictId { get; set; }

        [Display(Name = "District Name")]
        public string DistrictName { get; set; }

        [Display(Name = "Community Council")]
        public int? CommunityCouncilId { get; set; }

        [Display(Name = "Community Council Name")]
        public string CommunityCouncilName { get; set; }

        [Display(Name = "Village")]
        public int? VillageId { get; set; }

        [Display(Name = "Village Name")]
        public string VillageName { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Venue is required.")]
        [StringLength(500, ErrorMessage = "Venue cannot exceed 500 characters.")]
        [Display(Name = "Venue")]
        public string Venue { get; set; }

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
