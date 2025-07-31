using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.UserManagement;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.Business.Models.Missa.Setups
{
    /// <summary>
    /// Represents the type of a facility including its name, fee structure, and audit details.
    /// </summary>
    public class FacilityType : BaseAuditableEntity<int>
    {
       

        /// <summary>
        /// Gets or sets the name of the facility type.
        /// </summary>

        public string Name { get; set; }
      
        /// <summary>
        /// Gets or sets a value indicating whether the facility type is active.
        /// </summary>

        public bool IsActive { get; set; }

        /// <summary>
        /// Navigation property for the user who created the record.
        /// </summary>
        public virtual ApplicationUser CreatedBy { get; set; }

        /// <summary>
        /// Navigation property for the user who last modified the record.
        /// </summary>
        public virtual ApplicationUser ModifiedBy { get; set; }
    }
}
