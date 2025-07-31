using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoGYSD.Business.Models.Missa.ProgrammeConfiguration
{
    public class ArrearsConfiguration : BaseAuditableEntity<int>
    {
        // Id is inherited from BaseAuditableEntity<int> and serves as the primary key.

        /// <summary>
        /// Foreign key referencing the associated programme.
        /// </summary>
        public int ProgrammeId { get; set; }
        /// <summary>
        /// Gets or sets the navigation property to the associated programme configuration.
        /// </summary>
        public virtual Programmes Programme { get; set; }

        /// <summary>
        /// Maximum number of arrears cycles allowed (e.g. 0, 2, 3).
        /// </summary>
        public int MaximumCycles { get; set; }

        /// <summary>
        /// Foreign key referencing a system code (e.g., Suspension, Exit, N/A) for the penalty to be applied.
        /// </summary>
        public int PenaltyId { get; set; }

        public virtual SystemCodeDetail Penalty { get; set; }

        /// <summary>
        /// Indicates whether accruals continue after the penalty (true for Yes, false for No).
        /// </summary>
        public bool AccruedAfterPenalty { get; set; }

        /// <summary>
        /// Indicates whether arrears accrue across fiscal years (true for Yes, false for No).
        /// </summary>
        public bool ArrearsOverYear { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the programme is active.
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
    }
}