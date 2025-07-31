using MoGYSD.Business.Models.Common;

namespace MoGYSD.Business.Models.Missa.ProgrammeConfiguration
{
    /// <summary>
    /// Represents the many-to-many relationship specifying that an eligibility criterion requires
    /// enrollment in another programme.
    /// </summary>
    /// <remarks>
    /// This entity is used for the "Enrolled in other Programmes" multi-select requirement.
    /// The primary key for this table should be a composite of <see cref="EligibilityCriteriaId"/> and <see cref="RequiredProgrammeId"/>.
    /// </remarks>
    public class EnrolledInOtherProgramme:BaseAuditableEntity<int>
    {
        /// <summary>
        /// Gets or sets the foreign key to the <see cref="EligibilityCriteria"/> that has this requirement.
        /// Part of the composite primary key.
        /// </summary>
        public int? EligibilityCriteriaId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated eligibility criterion.
        /// </summary>
        public virtual EligibilityCriteria EligibilityCriteria { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the <see cref="Programmes"/> that an individual must be enrolled in.
        /// Part of the composite primary key.
        /// </summary>
        public int? ProgrammeId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the required programme.
        /// </summary>
        public virtual Programmes Programme { get; set; }
    }
}