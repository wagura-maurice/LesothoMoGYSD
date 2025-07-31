using MoGYSD.ViewModels.Nissa.DistrictRegistrations;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoGYSD.Business.ViewModels.Missa.Enrolments
{
    public class EnrolmentEventViewModel
    {
        [Display(Name = "Enrolment Event ID")]
        public int EnrolmentEventId { get; set; }

        [Required(ErrorMessage = "Enrolment Event Name is required.")]
        [StringLength(255, ErrorMessage = "Enrolment Event Name cannot exceed 255 characters.")]
        [Display(Name = "Enrolment Event Name")]
        public string EnrolmentEventName { get; set; }

        [Required(ErrorMessage = "Programme is required.")]
        [Display(Name = "Programme")]
        public int? ProgrammeId { get; set; }

        [Display(Name = "Programme Name")]
        public string ProgrammeName { get; set; }

        [Required(ErrorMessage = "District is required.")]
        [Display(Name = "District")]
        public int? DistrictId { get; set; }

        [Display(Name = "District Name")]
        public string DistrictName { get; set; }

        [Required(ErrorMessage = "Community Council is required.")]
        [Display(Name = "Community Council")]
        public int? CommunityCouncilId { get; set; }

        [Display(Name = "Community Council Name")]
        public string CommunityCouncilName { get; set; }

        [Required(ErrorMessage = "Village is required.")]
        [Display(Name = "Village")]
        public int? VillageId { get; set; }

        [Display(Name = "Village Name")]
        public string VillageName { get; set; }

        [Required(ErrorMessage = "Quota is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Quota must be a positive value.")]
        [Display(Name = "Quota")]
        public decimal Quota { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        [Display(Name = "End Date")]
        [DateGreaterThan("StartDate")]
        public DateTime? EndDate { get; set; }

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
