namespace MoGYSD.Web.Components.Missa.ProgrammeEligibilityCriteria
{
    public class EligibilitySetupCriteria
    {
        public string Name { get; set; } = string.Empty;
        public int? ProgrammeId { get; set; }
        public int? LocationIds { get; set; }
        public int? CommunityCouncilId { get; set; }
        public int? VillageId { get; set; }
        public int? AssistanceUnitId { get; set; }
        public int? VulnerabilityTypeId { get; set; }
        public bool? IsActive { get; set; }
        public int? PovertyStatusId { get; set; }
    }
}
