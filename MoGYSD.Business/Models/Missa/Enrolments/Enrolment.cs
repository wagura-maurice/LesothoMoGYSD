using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.UserManagement;
using MoGYSD.Business.Models.Nissa.HouseHoldEnumerations; // Assuming Household is here
// You might also need a using for PaymentDetails if it's in a different namespace

namespace MoGYSD.Business.Models.Missa.Enrolments
{
    /// <summary>
    /// Represents an enrolment record, linking an individual to a specific enrolment schedule and event detail.
    /// Inherits audit tracking properties from <see cref="BaseAuditableEntity{int}"/>.
    /// </summary>
    public class Enrolment : BaseAuditableEntity<int>
    {
        /// <summary>
        /// Gets or sets the globally unique identifier for the enrolment.
        /// </summary>      
        public string GUId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the associated <see cref="EnrolmentSchedules"/>.
        /// </summary>
        public int EnrolmentScheduleId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated <see cref="EnrolmentSchedules"/>.
        /// </summary>
        public virtual EnrolmentSchedule EnrolmentSchedule { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the associated <see cref="Missa.Enrolments.EnrolmentEventDetail"/>.
        /// </summary>
        public int EnrolmentEventDetailId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated <see cref="Missa.Enrolments.EnrolmentEventDetail"/>.
        /// </summary>
        public virtual EnrolmentEventDetail EnrolmentEventDetail { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the associated Household.
        /// </summary>
        public int HouseholdId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated Household.
        /// </summary>
        public virtual Household Household { get; set; }

        /// <summary>
        /// Gets or sets the postal address of the enrollee.
        /// </summary>
        public string PostalAddress { get; set; }

        /// <summary>
        /// Navigation property for the user who created the bank record.
        /// </summary>
        // These are typically inherited from BaseAuditableEntity, but explicitly listing them is also fine if BaseAuditableEntity doesn't provide the virtual properties directly.
        public virtual ApplicationUser CreatedBy { get; set; }
        /// <summary>
        /// Navigation property for the user who last modified the bank record.
        /// </summary>
        public virtual ApplicationUser ModifiedBy { get; set; }


        /// <summary>
        /// Gets or sets the collection of <see cref="EnrolmentDetails"/> associated with this enrolment.
        /// </summary>
        public virtual ICollection<EnrolmentDetail> EnrolmentDetails { get; set; } = new List<EnrolmentDetail>();

        /// <summary>
        /// Gets or sets the collection of PaymentDetails associated with this enrolment.
        /// </summary>
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();


    }
}