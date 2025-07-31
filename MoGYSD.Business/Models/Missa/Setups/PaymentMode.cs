using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Missa.Enrolments;
using MoGYSD.Business.Models.Nissa.UserManagement;
using System;

namespace MoGYSD.Business.Models.Missa.Setups
{
    /// <summary>
    /// This entity stores information on payment modes available to the beneficiaries.
    /// Inherits audit tracking properties from <see cref="BaseAuditableEntity{int}"/>.
    /// </summary>
    public class PaymentMode : BaseAuditableEntity<int>
    {
        // Id is inherited from BaseAuditableEntity<int> and serves as the PK.

        /// <summary>
        /// Gets or sets the name of a payment mode.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a brief description of a payment mode.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Navigation property for the user who created the record.
        /// (Corresponds to CreatedById FK)
        /// </summary>
        public virtual ApplicationUser CreatedBy { get; set; }

        /// <summary>
        /// Navigation property for the user who last modified the record.     
        /// </summary>
        public virtual ApplicationUser ModifiedBy { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();


    }
}