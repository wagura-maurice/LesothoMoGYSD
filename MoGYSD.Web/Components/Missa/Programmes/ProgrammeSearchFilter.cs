namespace MoGYSD.Web.Components.Missa.Programmes
{
    public class ProgrammeSearchFilter
    {
        public string? Names { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int? AssistanceUnitId { get; set; }
        public int? ProgramTypeId { get; set; }
        public string? PaymentModesAllowedDescriptions { get; set; }
        public int? PaymentFrequencyId { get; set; }
        public int? ProxiesAllowed { get; set; }
        public decimal? Amount { get; set; }
        public bool? IsActive { get; set; }
    }
}
