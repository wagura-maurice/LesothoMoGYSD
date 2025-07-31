namespace MoGYSD.Business.Views.Nissa.Admin;
/// <summary>
/// Represents a comprehensive view of partner organization information combining core details,
/// contact information, registration purposes, and compliance status for partnership management.
/// </summary>
public class PartnerView
{
    /// <summary>
    /// Gets or sets the unique identifier for the partner record.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the organization type in SystemCodeDetail.
    /// </summary>
    public int OrgTypeId { get; set; }

    /// <summary>
    /// Gets or sets the name of the organization type (e.g., "NGO", "Government Agency").
    /// </summary>
    public string OrgTypeName { get; set; }

    /// <summary>
    /// Gets or sets the legal name of the partner organization.
    /// </summary>
    public string PartnerName { get; set; }

    /// <summary>
    /// Gets or sets the physical location address of the partner's offices.
    /// </summary>
    public string PhysicalAddress { get; set; }

    /// <summary>
    /// Gets or sets the mailing address for official correspondence.
    /// </summary>
    public string PostalAddress { get; set; }

    /// <summary>
    /// Gets or sets the primary landline contact number.
    /// </summary>
    /// <remarks>
    /// Expected format: Country code + number (e.g., "+267 1234567").
    /// </remarks>
    public string TelephoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the primary mobile contact number.
    /// </summary>
    /// <remarks>
    /// Expected format: Country code + number (e.g., "+267 71234567").
    /// </remarks>
    public string MobileNumber { get; set; }
    public string MobileNumberPrefix { get; set; }

    /// <summary>
    /// Gets or sets the primary email contact address.
    /// </summary>
    public string EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the partner's primary District.
    /// </summary>
    public int DistrictId { get; set; }

    /// <summary>
    /// Gets or sets the name of the partner's primary District.
    /// </summary>
    public string DistrictName { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the registration purpose in SystemCodeDetail.
    /// </summary>
    public int RegistrationPurposeId { get; set; }

    /// <summary>
    /// Gets or sets the name of the registration purpose (e.g., "Service Delivery", "Data Collection").
    /// </summary>
    public string RegistrationPurposeName { get; set; }

    /// <summary>
    /// Gets or sets the custom purpose description when "Other" is selected.
    /// </summary>
    public string OtherPurpose { get; set; }

    /// <summary>
    /// Gets or sets additional notes or comments about the partnership.
    /// </summary>
    public string DetailedRemarks { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the partner has accepted data privacy protocols.
    /// </summary>
    /// <value>
    /// <c>true</c> if privacy protocols were accepted; otherwise, <c>false</c>.
    /// </value>
    public bool PrivacyProtocolsAccepted { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the partner is currently active in the system.
    /// </summary>
    /// <value>
    /// <c>true</c> if the partner is active; otherwise, <c>false</c>.
    /// </value>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the partner status in SystemCodeDetail.
    /// </summary>
    public int StatusId { get; set; }

    /// <summary>
    /// Gets or sets the name of the partner status (e.g., "Approved", "Pending Review").
    /// </summary>
    public string StatusName { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who created this partner record.
    /// </summary>
    public string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who last modified this partner record.
    /// </summary>
    public string ModifiedById { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who created this partner record.
    /// </summary>
    public string CreatedByName { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who last modified this partner record.
    /// </summary>
    public string ModifiedByName { get; set; }
    /// <summary>
    /// Gets or sets area of operation for a partner record.
    /// </summary>
    public string AreaOfOperation { get; set; } = null!;

}