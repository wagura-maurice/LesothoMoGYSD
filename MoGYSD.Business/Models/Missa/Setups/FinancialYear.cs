using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.UserManagement;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.Business.Models.Missa.Setups
{
    /// <summary>
    /// Represents a financial year configuration within the system.
    /// </summary>
    public class FinancialYear : BaseAuditableEntity<int>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the financial year.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name or label of the financial year.
        /// </summary>     
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the starting date of the financial year.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the ending date of the financial year.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this financial year is currently active.
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
