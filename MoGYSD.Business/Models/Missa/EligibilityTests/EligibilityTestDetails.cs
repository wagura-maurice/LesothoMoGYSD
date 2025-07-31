using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Missa.Enrolments;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.HouseHoldEnumerations;
using MoGYSD.Business.Models.Nissa.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoGYSD.Business.Models.Missa.EligibilityTests
{
    /// <summary>
    /// Stores the outcomes of the eligibility test.
    /// </summary>
    public class EligibilityTestDetail : BaseAuditableEntity<int>
    {

        /// <summary>
        /// FK to EligibilityTests entity.
        /// </summary>
        public int EligibilityTestId { get; set; }
        public virtual EligibilityTests EligibilityTest { get; set; }

        /// <summary>
        /// FK to EnrolmentEventDetail entity.
        /// </summary>
        public int? EnrolmentEventDetailId { get; set; }
        public virtual EnrolmentEventDetail EnrolmentEventDetail { get; set; }

        /// <summary>
        /// FK to EligibilityStatus entity (e.g., "Eligible", "Not Eligible").
        /// </summary>
        public int EligibilityStatusId { get; set; }
        public virtual SystemCodeDetail EligibilityStatus { get; set; }
        public int HouseholdId { get; set; }
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
