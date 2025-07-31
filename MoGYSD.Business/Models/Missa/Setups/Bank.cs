using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.UserManagement;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.Business.Models.Missa.Setups
{
    /// <summary>
    /// Represents a bank that is used by facilities for payments and other financial transactions.
    /// </summary>
    public class Bank:BaseAuditableEntity<int>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the bank.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets a description or code of the bank.
        /// </summary>
        public string BankDescription { get; set; }

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
