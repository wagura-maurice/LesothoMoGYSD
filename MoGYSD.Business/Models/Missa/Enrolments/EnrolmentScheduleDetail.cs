using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Missa.Enrolments
{
    public class EnrolmentScheduleDetail : BaseAuditableEntity<int>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the enrolment schedule detail.
        /// </summary>
        // public int Id { get; set; } // Often removed if inherited from BaseAuditableEntity<int>

        /// <summary>
        /// Gets or sets the foreign key to the associated EnrolmentSchedule.
        /// (This is the missing Many-to-one relationship with EnrolmentSchedules)
        /// </summary>
        public int EnrolmentScheduleId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated EnrolmentSchedule.
        /// </summary>
        public virtual EnrolmentSchedule EnrolmentSchedule { get; set; }


        /// <summary>
        /// Gets or sets the enrolment event identifier associated with this schedule.
        /// </summary>
        public int EnrolmentEventId { get; set; }
        /// <summary>
        /// Gets or sets the enrolment event associated with this schedule.
        /// </summary>
        public virtual EnrolmentEvent EnrolmentEvent { get; set; }
        /// <summary>
        /// Gets or sets the village identifier for this schedule.
        /// </summary>
        public int VillageId { get; set; }
        /// <summary>
        /// Gets or sets the village associated with this schedule.
        /// </summary>
        public virtual Village Village { get; set; }
        /// <summary>
        /// Gets or sets the scheduled date for the enrolment event.
        /// </summary>
        public DateTime ScheduleDate { get; set; }


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

    }
}