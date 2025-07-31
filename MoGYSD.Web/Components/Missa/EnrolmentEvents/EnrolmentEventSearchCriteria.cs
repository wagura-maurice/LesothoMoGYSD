using System;

namespace MoGYSD.Web.Components.Missa.EnrolmentEvents
{
    public class EnrolmentEventSearchCriteria
    {
        public string EnrolmentEventName { get; set; } = string.Empty;

        public int? ProgrammeId { get; set; }
        public int? DistrictId { get; set; }
        public int? CommunityCouncilId { get; set; }
        public int? VillageId { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
