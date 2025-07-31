using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.Admin;

/// <summary>
/// Represents a partner organization entity that collaborates with the system,
/// inheriting audit tracking capabilities from <see cref="BaseAuditableEntity{T}"/>.
/// </summary>
public class Partner : BaseAuditableEntity<int>
{
    /// <summary>
    /// Gets or sets the foreign key reference to the organization type in <see cref="SystemCodeDetail"/>.
    /// </summary>
    public int OrgTypeId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the organization type <see cref="SystemCodeDetail"/>.
    /// </summary>
    public virtual SystemCodeDetail OrgType { get; set; }

    /// <summary>
    /// Gets or sets the legal name of the partner organization.
    /// </summary>
    public string PartnerName { get; set; }

    /// <summary>
    /// Gets or sets the physical location address of the partner organization.
    /// </summary>
    public string PhysicalAddress { get; set; }

    /// <summary>
    /// Gets or sets the mailing address for correspondence with the partner.
    /// </summary>
    public string PostalAddress { get; set; }

    /// <summary>
    /// Gets or sets the primary landline contact number for the partner.
    /// </summary>
    public string TelephoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the mobile contact number for the partner.
    /// </summary>
    public string MobileNumber { get; set; }

    /// <summary>
    /// Gets or sets the mobile number prefix for the partner.
    /// </summary>
    public string MobileNumberPrefix { get; set; }

    /// <summary>
    /// Gets or sets the primary email contact address for the partner.
    /// </summary>
    public string EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the <see cref="District"/> where the partner operates.
    /// </summary>
    public int DistrictId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the associated <see cref="District"/>.
    /// </summary>
    public virtual District District { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the registration purpose in <see cref="SystemCodeDetail"/>.
    /// </summary>
    public int RegistrationPurposeId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the registration purpose <see cref="SystemCodeDetail"/>.
    /// </summary>
    public virtual SystemCodeDetail RegistrationPurpose { get; set; }

    /// <summary>
    /// Gets or sets the custom purpose description when 'Other' is selected as registration purpose.
    /// </summary>
    public string OtherPurpose { get; set; }

    /// <summary>
    /// Gets or sets additional notes or comments about the partner organization.
    /// </summary>
    public string DetailedRemarks { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the partner has accepted the privacy protocols.
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
    /// Gets or sets the foreign key reference to the partner status in <see cref="SystemCodeDetail"/>.
    /// </summary>
    public int StatusId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the status <see cref="SystemCodeDetail"/>.
    /// </summary>
    public virtual SystemCodeDetail Status { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who created this record.
    /// </summary>
    public virtual ApplicationUser CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who last modified this record.
    /// </summary>
    public virtual ApplicationUser ModifiedBy { get; set; }
    public string AreaOfOperation { get; set; } = null!;
}