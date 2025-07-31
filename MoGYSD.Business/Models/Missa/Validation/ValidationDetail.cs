using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Missa.Validation;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.HouseHoldEnumerations;
using System;

namespace MoGYSD.Business.Models.Missa.Validation
{
    /// <summary>
    /// Represents the outcome of a validation exercise for a specific household member.
    /// </summary>
    public class ValidationDetail : BaseAuditableEntity<int>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the validation detail.
        /// </summary>
        public new int Id { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the associated validation list.
        /// </summary>
        public int ValidationListId { get; set; }

        /// <summary>
        /// Gets or sets the parent validation list that this detail belongs to.
        /// </summary>
        public virtual ValidationList ValidationList { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the household member who was validated.
        /// </summary>
        public int HouseholdMemberId { get; set; }

        /// <summary>
        /// Gets or sets the household member involved in the validation.
        /// </summary>
        public virtual HouseholdMember HouseholdMember { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the validation status.
        /// </summary>
        public int ValidationStatusId { get; set; }

        /// <summary>
        /// Gets or sets the result of the validation (e.g., Validated, Rejected).
        /// </summary>
        public virtual SystemCodeDetail ValidationStatus { get; set; }
    }
}
