using System;

namespace MoGYSD.Business.Views.Missa.EligibilityTests
{
    /// <summary>
    /// Represents a summarized, human-readable record of an eligibility test run.
    /// This class maps directly to the columns of the dbo.EligibilityTestsView SQL view.
    /// </summary>
    public class EligibilityTestsView
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? Quota { get; set; }
        public int ProgrammeId { get; set; }
        public string? ProgrammeName { get; set; }

        public string? DistrictIds { get; set; }
        public string? DistrictNames { get; set; }
        public int? CommunityCouncilId { get; set; }
        public string? CommunityCouncilName { get; set; }

        public int? VillageId { get; set; }
        public string? Village { get; set; }

        public int TotalProcessed { get; set; }
        public int TotalSelected { get; set; }
        public int TotalWaitlisted { get; set; }
        public int TotalNotEligible { get; set; }
        public int TotalEligiblePreQuota { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedById { get; set; }
        public string? CreatedByUserName { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedById { get; set; }
        public string? ModifiedByUserName { get; set; }
    }
}