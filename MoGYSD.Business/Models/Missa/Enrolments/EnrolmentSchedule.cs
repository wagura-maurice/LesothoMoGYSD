using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Missa.Enrolments
{
    /// <summary>
    /// Represents a schedule for an enrolment event, including location, timing, and related details.
    /// </summary>
    public class EnrolmentSchedule : BaseAuditableEntity<int>
    {

        /// <summary>
        /// Gets or sets the identifier of the associated enrolment event.
        /// </summary>
        public int EnrolmentEventId { get; set; }

        /// <summary>
        /// Gets or sets the associated enrolment event.
        /// </summary>
        public virtual EnrolmentEvent EnrolmentEvent { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the district where the schedule takes place.
        /// </summary>
        public int DistrictId { get; set; }

        /// <summary>
        /// Gets or sets the district where the schedule takes place.
        /// </summary>
        public virtual District District { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the community council where the schedule takes place.
        /// </summary>
        public int? CommunityCouncilId { get; set; }

        /// <summary>
        /// Gets or sets the community council where the schedule takes place.
        /// </summary>
        public virtual CommunityCouncil CommunityCouncil { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the village where the schedule takes place.
        /// </summary>
        public int? VillageId { get; set; }

        /// <summary>
        /// Gets or sets the village where the schedule takes place.
        /// </summary>
        public virtual Village Village { get; set; }

        /// <summary>
        /// Gets or sets the start date and time of the enrolment schedule.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date and time of the enrolment schedule.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the venue for the enrolment schedule.
        /// </summary>
        public string Venue { get; set; }

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

        /// <summary>
        /// Gets or sets the collection of schedule details associated with this schedule.
        /// </summary>
        public virtual ICollection<EnrolmentScheduleDetail> EnrolmentScheduleDetails { get; set; } = new List<EnrolmentScheduleDetail>();
    }
}
