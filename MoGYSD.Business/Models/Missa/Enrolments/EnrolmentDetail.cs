using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Missa.Setups;
using MoGYSD.Business.Models.Nissa.HouseHoldEnumerations;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Missa.Enrolments
{
    /// <summary>
    /// Represents the details of an enrolment, linking a household member to a grade within a specific enrolment event.
    /// Inherits audit tracking from <see cref="BaseAuditableEntity{int}"/>.
    /// </summary>
    public class EnrolmentDetail : BaseAuditableEntity<int>
    {

        /// <summary>
        /// Gets or sets the foreign key to the associated <see cref="Enrolments.Enrolment"/>.
        /// </summary>
        public int EnrolmentId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated <see cref="Enrolments.Enrolment"/>.
        /// </summary>
        public virtual Enrolment Enrolment { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the associated <see cref="HouseholdMember"/>.
        /// </summary>
        public int HouseholdMemberId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated <see cref="HouseholdMember"/>.
        /// </summary>
        public virtual HouseholdMember HouseholdMember { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the associated <see cref="Grade"/>.
        /// </summary>
        public int GradeId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated <see cref="Grade"/>.
        /// </summary>
        public virtual Grade Grade { get; set; }
        /// <summary>
        /// Navigation property for the user who created the bank record.
        /// </summary>
        public virtual ApplicationUser CreatedBy { get; set; }
        /// <summary>
        /// Navigation property for the user who last modified the bank record.
        /// </summary>
        public virtual ApplicationUser ModifiedBy { get; set; }

    }
}
