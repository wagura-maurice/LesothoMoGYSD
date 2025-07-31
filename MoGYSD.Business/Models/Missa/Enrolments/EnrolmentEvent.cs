using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Missa.ProgrammeConfiguration;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Missa.Enrolments
{
    /// <summary>
    /// Represents an enrolment event, capturing details about a specific enrolment campaign or activity.
    /// </summary>
    public class EnrolmentEvent : BaseAuditableEntity<int>
    {


        /// <summary>
        /// Gets or sets the name of the enrolment event.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the associated programme.
        /// </summary>
        public int ProgrammeId { get; set; }

        /// <summary>
        /// Gets or sets the associated programme.
        /// </summary>
        public virtual Programmes Programme { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the district where the event takes place.
        /// </summary>
        public int DistrictId { get; set; }

        /// <summary>
        /// Gets or sets the district where the event takes place.
        /// </summary>
        public virtual District District { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the community council where the event takes place.
        /// </summary>
        public int CommunityCouncilId { get; set; }

        /// <summary>
        /// Gets or sets the community council where the event takes place.
        /// </summary>
        public virtual CommunityCouncil CommunityCouncil { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the village where the event takes place.
        /// </summary>
        public int VillageId { get; set; }

        /// <summary>
        /// Gets or sets the village where the event takes place.
        /// </summary>
        public virtual Village Village { get; set; }

        /// <summary>
        /// Gets or sets the quota for the enrolment event.
        /// </summary>
        public decimal Quota { get; set; }

        /// <summary>
        /// Gets or sets the start date of the enrolment event.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the enrolment event.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Navigation property for the user who created the bank record.
        /// </summary>
        public virtual ApplicationUser CreatedBy { get; set; }
        /// <summary>
        /// Navigation property for the user who last modified the bank record.
        /// </summary>
        public virtual ApplicationUser ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the collection of enrolment event details associated with this event.
        /// </summary>
        public virtual ICollection<EnrolmentEventDetail> EnrolmentEventDetails { get; set; } = new List<EnrolmentEventDetail>();
        public virtual ICollection<EnrolmentSchedule> EnrolmentSchedules { get; set; } = new List<EnrolmentSchedule>();
        public virtual ICollection<Approval> Approvals { get; set; } = new List<Approval>();

    }
}
