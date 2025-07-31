using System;

namespace MoGYSD.Business.Views.Missa.Enrolments
{
    public class EnrolmentScheduleDetailView
    {
        public int EnrolmentScheduleDetailId { get; set; }
        public int EnrolmentScheduleId { get; set; }
        public string EnrolmentScheduleVenue { get; set; }
        public int EnrolmentEventId { get; set; }
        public string EnrolmentEventName { get; set; }
        public int VillageId { get; set; }
        public string VillageName { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedById { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
