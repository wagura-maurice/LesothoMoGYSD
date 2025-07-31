using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;
using MoGYSD.Business.Models.Missa.Enrolments;

namespace MoGYSD.Business.Models.Missa.Setups
{
    /// <summary>
    /// This entity stores information about the pay points, which are physical locations
    /// where beneficiaries can collect payments.
    /// Inherits audit tracking properties from <see cref="BaseAuditableEntity{int}"/>.
    /// </summary>
    public class PayPoint : BaseAuditableEntity<int>
    {
        // Id is inherited from BaseAuditableEntity<int> and serves as the PK.

        /// <summary>
        /// Gets or sets the unique code for each pay point.
        /// (Needs a unique constraint in the database configuration).
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name of the pay point (as per the column description, it's called "Name of the village" but refers to the pay point's name).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the CommunityCouncils entity.
        /// </summary>
        public int CommunityCouncilId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated CommunityCouncil.
        /// </summary>
        public virtual CommunityCouncil CommunityCouncil { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the pay point is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the Districts entity.
        /// </summary>
        public int DistrictId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated District.
        /// </summary>
        public virtual District District { get; set; }

        /// <summary>
        /// Navigation property for the user who created the record.
        /// (Handled by BaseAuditableEntity, explicit virtual property for EF Core)
        /// </summary>
        public virtual ApplicationUser CreatedBy { get; set; }

        /// <summary>
        /// Navigation property for the user who last modified the record.
        /// (Handled by BaseAuditableEntity, explicit virtual property for EF Core)
        /// </summary>
        public virtual ApplicationUser ModifiedBy { get; set; }

        // CreatedOn and ModifiedOn properties are inherited from BaseAuditableEntity<int>.

        /// <summary>
        /// Gets or sets the collection of PaymentDetails associated with this pay point.
        /// (One-to-many relationship with PaymentDetails)
        /// </summary>
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();
    }
}