using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Missa.ProgrammeConfiguration
{
    /// <summary>
    /// Represents a benefit calculation rule for a programme.
    /// </summary>
    /// <remarks>
    /// Each <see cref="BenefitRule"/> defines the amount to be paid based on the number of household members.
    /// The rule is associated with a specific <see cref="Programmes"/>.
    /// </remarks>
    public class BenefitRule : BaseAuditableEntity<int>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the benefit rule.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the associated programme configuration.
        /// </summary>
        public int ProgrammeId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated programme configuration.
        /// </summary>
        public virtual Programmes Programme { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of household members for this rule to apply.
        /// Null means no minimum.
        /// </summary>
        public int? MinHHMembers { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of household members for this rule to apply.
        /// Null means no maximum.
        /// </summary>
        public int? MaxHHMembers { get; set; }

        /// <summary>
        /// Gets or sets the benefit amount for this rule.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this rule is active.
        /// </summary>
        public bool IsActive { get; set; } = true;
        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ApplicationUser ModifiedBy { get; set; }

    }
}