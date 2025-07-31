using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;

namespace MoGYSD.Business.Models.Missa.ProgrammeConfiguration
{
    /// <summary>
    /// Represents the many-to-many relationship between an Eligibility Criterion and a geographical District.
    /// </summary>
    /// <remarks>
    /// This entity allows a single eligibility rule to be applicable across multiple selected districts.
    /// The primary key for this table should be a composite of <see cref="EligibilityCriteriaId"/> and <see cref="DistrictId"/>.
    /// </remarks>
    public class EligibilityCriteriaLocation:BaseAuditableEntity<int>
    {
        /// <summary>
        /// Gets or sets the foreign key to the associated <see cref="EligibilityCriteria"/>.
        /// Part of the composite primary key.
        /// </summary>
        public int EligibilityCriteriaId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated eligibility criterion.
        /// </summary>
        public virtual EligibilityCriteria EligibilityCriteria { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the associated <see cref="District"/>.
        /// Part of the composite primary key.
        /// </summary>
        public int? DistrictId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated district.
        /// </summary>
        public virtual District District { get; set; }
    }
}