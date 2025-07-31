using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;
namespace MoGYSD.Business.Models.Missa.Enrolments
{
    /// <summary>
    /// This entity stores the details of the proxies.
    /// Inherits audit tracking properties from <see cref="BaseAuditableEntity{int}"/>.
    /// </summary>
    public class Proxie : BaseAuditableEntity<int>
    {
        // Id is inherited from BaseAuditableEntity<int> and serves as the PK.

        /// <summary>
        /// Gets or sets the unique identifier of a proxy.
        /// </summary>
        public string GUId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the PaymentDetails entity.
        /// (This implies a Many-to-One relationship from Proxie to PaymentDetails)
        /// </summary>
        public int PaymentDetailsId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the associated PaymentDetails entity.
        /// </summary>
        public virtual PaymentDetail PaymentDetail { get; set; }

        /// <summary>
        /// Gets or sets the unique identification number of the proxy.
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// Gets or sets the first name of the proxy.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle name of the proxy.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the Gender entity (e.g., SystemCodeDetail).
        /// </summary>
        public int GenderId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the Gender of the proxy.
        /// (Assuming Gender is represented by a SystemCodeDetail)
        /// </summary>
        public virtual SystemCodeDetail Gender { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the proxy.
        /// </summary>
        public DateTime DateofBirth { get; set; }

        /// <summary>
        /// Gets or sets the contact phone number of the proxy.
        /// </summary>
        public string PhoneNumber { get; set; }

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