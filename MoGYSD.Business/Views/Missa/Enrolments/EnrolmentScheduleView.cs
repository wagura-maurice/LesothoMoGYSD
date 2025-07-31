using System;

namespace MoGYSD.Business.Views.Missa.Enrolments
{
    public class EnrolmentScheduleView
    {
        public int EnrolmentScheduleId { get; set; }
        public int EnrolmentEventId { get; set; }
        public string EnrolmentEventName { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int? CommunityCouncilId { get; set; }
        public string CommunityCouncilName { get; set; }
        public int? VillageId { get; set; }
        public string VillageName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Venue { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedById { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
