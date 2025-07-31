using MoGYSD.Business.Models.Common;

namespace MoGYSD.Business.Models.Missa.ProgrammeConfiguration
{
    /// <summary>
    /// Represents a top-up rule for a programme.
    /// </summary>
    /// <remarks>
    /// Each <see cref="TopUps"/> defines an additional payment rule that can be applied to a <see cref="Programmes.Programmes"/>.
    /// Top-ups are used to provide extra benefits to eligible recipients based on specific criteria.
    /// </remarks>
    public class TopUps : BaseAuditableEntity<int>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the top-up rule.
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
        /// Gets or sets the name of the top-up rule.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the top-up amount to be added to the base benefit.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the top-up rule is active.
        /// </summary>
        public bool IsActive { get; set; } = true;
        
    }
}