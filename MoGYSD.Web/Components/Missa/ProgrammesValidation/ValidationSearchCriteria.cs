namespace MoGYSD.Web.Components.Missa.ProgrammesValidation
{
    public class ValidationSearchCriteria
    {
        public string Name { get; set; } = string.Empty;
        public int? ProgrammeId { get; set; }
        public int? CommunityCouncilId { get; set; }
        public int? TotalVillages { get; set; }
        public int? TotalHouseholds { get; set; }
        public int? TotalMembers { get; set; }
        public int? ValidatedMembers { get; set; }
        public int? PendingValidation { get; set; }
        public DateTime? ValidationDate { get; set; }     
        public int? DistrictId { get; set; }
    }
}
