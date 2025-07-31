using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.Admin;

/// <summary>
/// Represents a contact person entity in the database, tracking individuals associated with partner organizations.
/// Inherits from <see cref="BaseAuditableEntity{T}"/> for audit tracking with integer primary key.
/// </summary>
public class ContactPerson : BaseAuditableEntity<int>
{
    /// <summary>
    /// Gets or sets the foreign key reference to the associated <see cref="Partner"/> entity.
    /// </summary>
    /// <remarks>
    /// This is a required relationship - every contact person must be associated with a partner.
    /// </remarks>
    public int PartnerId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the associated <see cref="Partner"/> entity.
    /// </summary>
    public virtual Partner Partner { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the contact type classification.
    /// </summary>
    /// <remarks>
    /// References a ContactType entity (not explicitly shown in current domain model).
    /// This is a required field - every contact must have a type classification.
    /// </remarks>
    public int ContactTypeId { get; set; }

    /// <summary>
    /// Gets or sets the first name of the contact person.
    /// </summary>
    /// <remarks>
    /// This is a required field with maximum length configured via Fluent API or data annotations.
    /// </remarks>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the surname (last name) of the contact person.
    /// </summary>
    /// <remarks>
    /// This is a required field with maximum length configured via Fluent API or data annotations.
    /// </remarks>
    public string Surname { get; set; }

    /// <summary>
    /// Gets or sets the mobile phone number for the contact person.
    /// </summary>
    /// <remarks>
    /// Format validation and maximum length are typically enforced via data annotations or Fluent API.
    /// </remarks>
    public string MobileNumber { get; set; }

    /// <summary>
    /// Gets or sets the email address for the contact person.
    /// </summary>
    /// <remarks>
    /// Format validation and maximum length are typically enforced via data annotations or Fluent API.
    /// This is a required field for all contact persons.
    /// </remarks>
    public string EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who created this record.
    /// </summary>
    public virtual ApplicationUser CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who last modified this record.
    /// </summary>
    public virtual ApplicationUser ModifiedBy { get; set; }
}