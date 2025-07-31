using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Missa.Enrolments;
using MoGYSD.Business.Models.Nissa.UserManagement;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.Business.Models.Missa.Setups
{
    /// <summary>
    /// Represents a grade linked to a facility.
    /// </summary>
    public class Grade : BaseAuditableEntity<int>
    {
        /// <summary>
        /// Unique identifier for the grade.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Unique code for each grade.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// FK to Facilities entity.
        /// </summary>
      public virtual ICollection<Facility> Facilities { get; set; } = new List<Facility>();

        /// <summary>
        /// Indicates if the grade is active (true) or inactive (false).
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Navigation property for the user who created the bank record.
        /// </summary>
        public virtual ApplicationUser CreatedBy { get; set; }
        /// <summary>
        /// Navigation property for the user who last modified the bank record.
        /// </summary>
        public virtual ApplicationUser ModifiedBy { get; set; }
        /// <summary>
        /// One-to-Many: HouseholdMember → EnrolmentDetails
        /// All enrolment details associated with this household member.
        /// </summary>
        public virtual ICollection<EnrolmentDetail> EnrolmentDetails { get; set; } = new List<EnrolmentDetail>();

    }
}
