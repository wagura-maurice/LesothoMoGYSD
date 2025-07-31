namespace MoGYSD.Business.Views.Nissa.Admin;

/// <summary>
/// Represents a view model combining contact person details with associated partner information
/// for reporting and display purposes.
/// </summary>
public class ContactPersonView
{
    /// <summary>
    /// Gets or sets the unique identifier for the contact person record.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the associated partner organization.
    /// </summary>
    public int PartnerId { get; set; }

    /// <summary>
    /// Gets or sets the name of the associated partner organization.
    /// </summary>
    /// <remarks>
    /// This denormalized field improves query performance for display purposes.
    /// </remarks>
    public string PartnerName { get; set; }
    public string OrgTypeName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the foreign key reference to the contact type classification.
    /// </summary>
    /// <remarks>
    /// References a SystemCodeDetail value (e.g., "Primary Contact", "Technical Contact").
    /// </remarks>
    public int ContactTypeId { get; set; }

    /// <summary>
    /// Gets or sets the contact person's first name.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the contact person's surname (last name).
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// Gets or sets the contact person's mobile phone number.
    /// </summary>
    /// <remarks>
    /// Format should follow international standards (e.g., +26712345678).
    /// </remarks>
    public string MobileNumber { get; set; }

    /// <summary>
    /// Gets or sets the contact person's email address.
    /// </summary>
    /// <remarks>
    /// Must be a valid email format according to system validation rules.
    /// </remarks>
    public string EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who created this contact record.
    /// </summary>
    public string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who last modified this contact record.
    /// </summary>
    public string ModifiedById { get; set; }

    /// <summary>
    /// Gets or sets the display name of the user who created this contact record.
    /// </summary>
    public string CreatedByName { get; set; }

    /// <summary>
    /// Gets or sets the display name of the user who last modified this contact record.
    /// </summary>
    public string ModifiedByName { get; set; }
}