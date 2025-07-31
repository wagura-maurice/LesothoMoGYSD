using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using System;

namespace MoGYSD.Business.Models.Missa.EligibilityTests
{
    /// <summary>
    /// Represents the association between an eligibility test and a district.
    /// </summary>
    public class EligibilityTestDistrict : BaseAuditableEntity<int>
    {
        /// <summary>
        /// Gets or sets the ID of the associated eligibility test.
        /// </summary>
        public int EligibilityTestId { get; set; }

        /// <summary>
        /// Gets or sets the associated eligibility test.
        /// </summary>
        public virtual EligibilityTests EligibilityTest { get; set; }

        /// <summary>
        /// Gets or sets the ID of the associated district.
        /// </summary>
        public int DistrictId { get; set; }

        /// <summary>
        /// Gets or sets the associated district.
        /// </summary>
        public virtual District District { get; set; }
    }
}
