using MoGYSD.Business.Models.Common;
//using MoGYSD.Business.Models.Missa.Enrolments;
using MoGYSD.Business.Models.Missa.ProgrammeConfiguration;
using MoGYSD.Business.Models.Nissa.Admin;
using System;
using System.Collections.Generic;

namespace MoGYSD.Business.Models.Missa.EligibilityTests
{
    /// <summary>
    /// Stores the header information for the eligibility test which is run before every program pay cycle.
    /// </summary>
    public class EligibilityTests:BaseAuditableEntity<int>
    {
        /// <summary>
        /// Unique identifier for the eligibility header.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// FK to Programmes entity.
        /// </summary>
        public int ProgrammeId { get; set; }
        public virtual Programmes Programme { get; set; }
        /// <summary>
        ///This is for the multi-district selection (many-to-many)/>.
        /// </summary>
        public virtual ICollection<EligibilityTestDistrict> EligibilityTestDistricts { get; set; } = new HashSet<EligibilityTestDistrict>();
        /// <summary>
        /// Gets or sets the foreign key of the associated community council.
        /// </summary>
        public int? CommunityCouncilId { get; set; }

        /// <summary>
        /// Gets or sets the community council where the validation took place.
        /// </summary>
        public virtual CommunityCouncil CommunityCouncil { get; set; }

        public int? VillageId { get; set; }

        /// <summary>
        /// Gets or sets the community council where the validation took place.
        /// </summary>
        public virtual Village Village { get; set; }
        /// <summary>
        /// The number of eligible households to be selected for enrolment. This is a critical parameter for the test.
        /// </summary>
        public int Quota { get; set; }
        /// <summary>
        /// An optional user-provided description for the eligibility test run, used for context and identification.
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Collection of eligibility test details.
        /// </summary>
        public virtual ICollection<EligibilityTestDetail> EligibilityTestDetails { get; set; } = new List<EligibilityTestDetail>();

    }
    
}
