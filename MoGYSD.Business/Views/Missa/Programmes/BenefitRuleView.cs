namespace MoGYSD.Business.Views.Missa.Programmes
{
    /// <summary>
    /// View model for displaying benefit rule details.
    /// </summary>
    public class BenefitRuleView
    {
        /// <summary>
        /// Unique identifier for the benefit rule.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identifier of the associated programme.
        /// </summary>
        public int ProgrammeId { get; set; }

        /// <summary>
        /// Name of the associated programme.
        /// </summary>
        public string ProgrammeName { get; set; }

        /// <summary>
        /// Minimum number of household members eligible for the benefit.
        /// </summary>
        public int? MinHHMembers { get; set; }

        /// <summary>
        /// Maximum number of household members eligible for the benefit.
        /// </summary>
        public int? MaxHHMembers { get; set; }

        /// <summary>
        /// Benefit amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Indicates if the benefit rule is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}