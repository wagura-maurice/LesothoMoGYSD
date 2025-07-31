using System;

namespace MoGYSD.Business.Views.Missa.Enrolments
{
    public class EnrolmentEventDetailView
    {
        public int EnrolmentEventDetailId { get; set; }

        public int EnrolmentEventId { get; set; }
        public string EnrolmentEventName { get; set; }

        public int? HouseholdMemberId { get; set; }
        public string HouseholdMemberFullName { get; set; }
        public string HouseholdMemberIDNumber { get; set; }

        public int? HouseholdId { get; set; }
        public string HouseholdCode { get; set; }

        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedById { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
