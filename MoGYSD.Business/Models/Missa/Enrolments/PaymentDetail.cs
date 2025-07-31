using MoGYSD.Business.Models.Common; 
using MoGYSD.Business.Models.Missa.Enrolments; 
using MoGYSD.Business.Models.Missa.Setups; 
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.HouseHoldEnumerations; 
using MoGYSD.Business.Models.Nissa.UserManagement; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoGYSD.Business.Models.Missa.Enrolments
{
    /// <summary>
    /// This entity stores the payment information of a payee in a household.
    /// Inherits audit tracking properties from <see cref="BaseAuditableEntity{int}"/>.
    /// </summary>
    public class PaymentDetail : BaseAuditableEntity<int>
    {
        // Id is inherited from BaseAuditableEntity<int> and serves as the PK.

        /// <summary>
        /// Gets or sets the foreign key to the associated Enrolments entity.
        /// </summary>
        public int EnrolmentId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated Enrolments entity.
        /// (Many-to-One relationship with Enrolments)
        /// </summary>
        public virtual Enrolment Enrolment { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the PaymentModes entity.
        /// </summary>
        public int PaymentModeId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated PaymentMode.
        /// </summary>
        public virtual PaymentMode PaymentMode { get; set; } 

        /// <summary>
        /// Gets or sets the mobile number to be used for digital payments.
        /// (Note: In a real-world scenario, mobile numbers are often stored as strings
        /// due to leading zeros, international prefixes, and non-numeric characters,
        /// but the spec indicates 'int'.)
        /// </summary>
        public int MobileNumber { get; set; } 

        /// <summary>
        /// Gets or sets the foreign key to the Facilities entity.
        /// </summary>
        public int FacilityId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated Facility.
        /// </summary>
        public virtual Facility Facility { get; set; } 

        /// <summary>
        /// Gets or sets the foreign key referencing a household member selected to be a payee.
        /// </summary>
        public int PayeeId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated HouseholdMember (Payee).
        /// </summary>
        public virtual HouseholdMember Payee { get; set; } 
        /// <summary>
        /// Gets or sets the foreign key to the Paypoints entity.
        /// </summary>
        public int PayPointId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated PayPoint.
        /// </summary>
        public virtual PayPoint PayPoint { get; set; } 

        /// <summary>
        /// Gets or sets the foreign key to the SystemsCodeDetails entity for Payee Type
        /// (e.g., proxy, beneficiary, other household member, etc.).
        /// </summary>
        public int PayeeTypeId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated SystemCodeDetail (PayeeType).
        /// </summary>
        public virtual SystemCodeDetail PayeeType { get; set; } 

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

        // CreatedOn and ModifiedOn properties are inherited from BaseAuditableEntity<int>
        public virtual ICollection<Proxie> Proxies { get; set; } = new List<Proxie>();

    }
}