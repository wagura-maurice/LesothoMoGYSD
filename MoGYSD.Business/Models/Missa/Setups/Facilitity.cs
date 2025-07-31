using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Missa.Enrolments;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.Business.Models.Missa.Setups
{
    /// <summary>
    /// Represents a facility (e.g., a school) where OVC-B beneficiaries are enrolled.
    /// </summary>
    public class Facility : BaseAuditableEntity<int>
    {
    

        /// <summary>
        /// Gets or sets the unique code for the facility.
        /// </summary>

        [StringLength(50)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the ID of the bank associated with the facility.
        /// </summary>

        [ForeignKey("Bank")]
        public int BankId { get; set; }

        /// <summary>
        /// Gets or sets the bank account number of the facility.
        /// </summary>

        public string AccountNo { get; set; }

        /// <summary>
        /// Gets or sets the bank branch code.
        /// </summary>

        public string BranchCode { get; set; }

        /// <summary>
        /// Gets or sets the unique identification number (e.g., NISSA/MISSA number) for the facility.
        /// </summary>

        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the facility.
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ID of the facility type.
        /// </summary>

        [ForeignKey("FacilityType")]
        public int FacilityTypeId { get; set; }

        /// <summary>
        /// Gets or sets the category ID of the facility.
        /// </summary>

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the first name of the facility head.
        /// </summary>

        public string HeadName { get; set; }

        /// <summary>
        /// Gets or sets the surname of the facility head.
        /// </summary>

        public string HeadSurname { get; set; }

        /// <summary>
        /// Gets or sets the email address of the facility head.
        /// </summary>

        [EmailAddress]
        public string HeadEmail { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the facility head.
        /// </summary>

        public string HeadPhoneNumber { get; set; }

        // Navigation properties

        /// <summary>
        /// Navigation property for the associated bank.
        /// </summary>
        public virtual Bank Bank { get; set; }

        /// <summary>
        /// Navigation property for the facility type.
        /// </summary>
        public virtual FacilityType FacilityType { get; set; }

        /// <summary>
        /// Navigation property for the facility category.
        /// </summary>
        public virtual SystemCodeDetail Category { get; set; }

        /// <summary>
        /// Navigation property for the grade associated with the facility.
        /// </summary>
        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

        /// <summary>
        /// Navigation property for the user who created the facility record.
        /// </summary>
        public virtual ApplicationUser CreatedBy { get; set; }

        /// <summary>
        /// Navigation property for the user who last modified the facility record.
        /// </summary>
        public virtual ApplicationUser ModifiedBy { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();
    }
}
