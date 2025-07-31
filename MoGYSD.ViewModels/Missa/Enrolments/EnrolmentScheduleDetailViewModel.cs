using System;
using System.ComponentModel.DataAnnotations;

namespace MoGYSD.Business.ViewModels.Missa.Enrolments
{
    public class EnrolmentScheduleDetailViewModel
    {
        [Display(Name = "Enrolment Schedule Detail ID")]
        public int EnrolmentScheduleDetailId { get; set; }

        [Required(ErrorMessage = "Enrolment Schedule is required.")]
        [Display(Name = "Enrolment Schedule")]
        public int EnrolmentScheduleId { get; set; }

        [Display(Name = "Schedule Venue")]
        public string EnrolmentScheduleVenue { get; set; }

        [Required(ErrorMessage = "Enrolment Event is required.")]
        [Display(Name = "Enrolment Event")]
        public int EnrolmentEventId { get; set; }

        [Display(Name = "Enrolment Event Name")]
        public string EnrolmentEventName { get; set; }

        [Required(ErrorMessage = "Village is required.")]
        [Display(Name = "Village")]
        public int VillageId { get; set; }

        [Display(Name = "Village Name")]
        public string VillageName { get; set; }

        [Required(ErrorMessage = "Schedule Date is required.")]
        [Display(Name = "Schedule Date")]
        public DateTime ScheduleDate { get; set; }

        [Display(Name = "Created By")]
        public string CreatedById { get; set; }

        [Display(Name = "Created By Name")]
        public string CreatedByName { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedById { get; set; }

        [Display(Name = "Modified By Name")]
        public string ModifiedByName { get; set; }

        [Display(Name = "Modified On")]
        public DateTime ModifiedOn { get; set; }
    }
}
