using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.Business.Views.Nissa.Admin;

/// <summary>
/// Represents a comprehensive view of user information combining identity, profile,
/// geographic associations, and role data for reporting and administration purposes.
/// </summary>
public class UserSummaryView
{
    /// <summary>
    /// Gets or sets the unique identifier for the user (inherited from IdentityUser).
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the user's first name.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the user's middle name.
    /// </summary>
    public string MiddleName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the user's surname (last name).
    /// </summary>
    public string Surname { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the user's email address (also serves as username).
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the user's primary contact phone number.
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the user account is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the user account was created.
    /// </summary>
    public DateTime? CreatedOn { get; set; }
    /// <summary>
    /// Gets or sets the date and time when the user account was created.
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the user's status in SystemCodeDetail.
    /// </summary>
    public int? StatusId { get; set; }

    /// <summary>
    /// Gets or sets the description of the user's current status.
    /// </summary>
    public string StatusDescription { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the foreign key reference to the user's gender in SystemCodeDetail.
    /// </summary>
    public int? SexId { get; set; }

    /// <summary>
    /// Gets or sets the description of the user's gender.
    /// </summary>
    public string SexDescription { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the primary role identifier for the user.
    /// </summary>
    public string RoleId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the user's primary role.
    /// </summary>
    public string RoleName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the identifier of the user who created this account.
    /// </summary>
    public string CreatedById { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the full name of the user who created this account.
    /// </summary>
    public string CreatedByFullName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the identifier of the user who last modified this account.
    /// </summary>
    public string ModifiedById { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the full name of the user who last modified this account.
    /// </summary>
    public string ModifiedByFullName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the foreign key reference to the user's RegistrationCentre (for enumerators).
    /// </summary>
    public int? RegistrationCentreId { get; set; }

    /// <summary>
    /// Gets or sets the name of the user's associated RegistrationCentre.
    /// </summary>
    public string RegistrationCentreName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the user has supervisor privileges.
    /// </summary>
    public bool IsSupervisor { get; set; }
    public string IDNumber { get; set; } = string.Empty;
    public bool PrivacyProtocolsAccepted { get; set; }
    
    public string Documents { get; set; } = string.Empty;
    
    public string PhotoDocuments { get; set; } = string.Empty;
    public string SourceOfRegistration { get; set; } = string.Empty;
    public int? IDTypeId { get; set; }
    public string IDType { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;

}
