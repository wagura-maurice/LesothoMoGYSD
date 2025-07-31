using MoGYSD.Business.Models.Common;
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
    /// Represents the details of an enrolment event, linking an event to a household member or household.
    /// </summary>
    public class EnrolmentEventDetail : BaseAuditableEntity<int>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the enrolment event detail.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the enrolment event.
        /// </summary>
        public int EnrolmentEventId { get; set; }

        /// <summary>
        /// Gets or sets the enrolment event associated with this detail.
        /// </summary>
        public virtual EnrolmentEvent EnrolmentEvent { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the household member associated with this enrolment event detail.
        /// </summary>
        public int? HouseholdMemberId { get; set; }

        /// <summary>
        /// Gets or sets the household member associated with this enrolment event detail.
        /// </summary>
        public virtual HouseholdMember HouseholdMember { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the household associated with this enrolment event detail.
        /// </summary>
        public int? HouseholdId { get; set; }

        /// <summary>
        /// Gets or sets the household associated with this enrolment event detail.
        /// </summary>
        public virtual Household Household { get; set; }
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