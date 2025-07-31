// CORRECTED ValidationList.cs

using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Missa.ProgrammeConfiguration;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.Business.Models.Missa.Validation
{
    /// <summary>
    /// Represents a record of a community validation exercise, including its details and associations.
    /// </summary>
    public class ValidationList : BaseAuditableEntity<int>
    {
       
        /// <summary>
        /// Gets or sets the date when the validation was conducted.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the validation was conducted.
        /// </summary>
        public DateTime EndDate { get; set; }
       

        /// <summary>
        /// Gets or sets the foreign key reference to the user's associated <see cref="District"/>.
        /// </summary>
        public int? DistrictId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated <see cref="District"/>.
        /// </summary>
        public virtual District District { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the associated community council.
        /// </summary>
        public int CommunityCouncilId { get; set; }

        /// <summary>
        /// Gets or sets the community council where the validation took place.
        /// </summary>
        public virtual CommunityCouncil CommunityCouncil { get; set; }

        /// <summary>
        /// Gets or sets the foreign key reference to the plan status in <see cref="SystemCodeDetail"/>.
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the status <see cref="SystemCodeDetail"/>.
        /// </summary>
        [ForeignKey(nameof(StatusId))]
        public virtual SystemCodeDetail Status { get; set; }

        /// <summary>
        /// Gets or sets the collection of validation details associated with the validation list.
        /// </summary>
        public virtual ICollection<ValidationDetail> ValidationDetails { get; set; } = new List<ValidationDetail>();
    }
}