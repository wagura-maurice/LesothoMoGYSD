using Microsoft.AspNetCore.Identity;
using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;

namespace MoGYSD.Business.Models.Nissa.UserManagement;
/// <summary>
/// Represents the application user entity extending ASP.NET Core Identity's <see cref="IdentityUser"/>
/// with additional user profile information, geographic associations, and audit capabilities
/// through <see cref="IAuditableEntity"/> implementation.
/// </summary>
public class ApplicationUser : IdentityUser, IAuditableEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationUser"/> class.
    /// </summary>
    public ApplicationUser()
    {
        UserRoles = new HashSet<ApplicationUserRole>();
    }

    /// <summary>
    /// Gets or sets the user's first name.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the user's middle name.
    /// </summary>
    public string MiddleName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the user's surname (last name).
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// Gets the user's full name by combining first, middle, and last names.
    /// </summary>
    public string FullName => $"{FirstName} {MiddleName} {Surname}";
    public string CountryCode { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the date and time when the user last changed their password.
    /// </summary>
    /// <remarks>
    /// Null if the user has never changed their password.
    /// </remarks>
    public DateTime? LastPasswordChangedDate { get; set; }

    /// <summary>
    /// Gets or sets the date and time of the user's last successful login.
    /// </summary>
    /// <remarks>
    /// Null if the user has never logged in.
    /// </remarks>
    public DateTime? LastLoginDate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user account is active.
    /// </summary>
    /// <value>
    /// <c>true</c> if the account is active; otherwise, <c>false</c>.
    /// </value>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the user status in <see cref="SystemCodeDetail"/>.
    /// </summary>
    public int StatusId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the user status <see cref="SystemCodeDetail"/>.
    /// </summary>
    public SystemCodeDetail Status { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the user's gender in <see cref="SystemCodeDetail"/>.
    /// </summary>
    public int? SexId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the gender <see cref="SystemCodeDetail"/>.
    /// </summary>
    public SystemCodeDetail Sex { get; set; }

    /// <summary>
    /// Gets or sets the user's national identification number.
    /// </summary>
    public string IDNumber { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the user account was created.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who created this account.
    /// </summary>
    public string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the creator <see cref="ApplicationUser"/>.
    /// </summary>
    public ApplicationUser CreatedBy { get; set; } = null;

    /// <summary>
    /// Gets or sets the date and time when the user account was last modified.
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who last modified this account.
    /// </summary>
    public string ModifiedById { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the last modifier <see cref="ApplicationUser"/>.
    /// </summary>
    public ApplicationUser ModifiedBy { get; set; } = null;

    /// <summary>
    /// Gets or sets the primary role ID for the user.
    /// </summary>
    public string RoleId { get; set; }
    public bool IsChangePassword { get; set; }
    /// <summary>
    /// Gets or sets the collection of role associations for this user.
    /// </summary>
    public ICollection<ApplicationUserRole> UserRoles { get; set; }
    public int? IDTypeId { get; set; }
    public SystemCodeDetail? IDTypeDetail { get; set; }

    public bool PrivacyProtocolsAccepted { get; set; }
    public List<RegistrationImage> Documents { get; set; }
    public List<RegistrationImage> PhotoDocuments { get; set; }
    public string SourceOfRegistration { get; set; } //"Template","Self-Registration","Internal Registration"
    public ICollection<UserDistrictAssignment> UserDistricts { get; set; } = new List<UserDistrictAssignment>();
    public ICollection<UserCommunityCouncilAssignment> UserCommunityCouncils { get; set; } = new List<UserCommunityCouncilAssignment>();
    public ICollection<UserVillageAssignment> UserVillages { get; set; } = new List<UserVillageAssignment>();
    public ICollection<UserRegistrationCentreAssignment> UserRegistrationCentres { get; set; } = new List<UserRegistrationCentreAssignment>();


}
public class RegistrationImage
{
    public required string Name { get; set; }
    public decimal Size { get; set; }
    public required string Url { get; set; }
}