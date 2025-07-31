using Microsoft.AspNetCore.Identity;
using MoGYSD.Business.Models.Common;

namespace MoGYSD.Business.Models.Nissa.UserManagement;
/// <summary>
/// Represents an extended role claim entity that combines ASP.NET Core Identity's <see cref="IdentityRoleClaim{TKey}"/>
/// with additional permission metadata and audit capabilities through <see cref="IAuditableEntity"/>.
/// </summary>
public class ApplicationRoleClaim : IdentityRoleClaim<string>, IAuditableEntity
{
    /// <summary>
    /// Gets or sets the display name of the permission associated with this claim.
    /// </summary>
    /// <remarks>
    /// Used for administrative interfaces to show human-readable permission names.
    /// Example: "UserManagement.Create", "Reports.Generate"
    /// </remarks>
    public string PermissionName { get; set; }

    /// <summary>
    /// Gets or sets the detailed description of the permission's scope and purpose.
    /// </summary>
    public string PermissionDescription { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the associated <see cref="ApplicationRole"/>.
    /// </summary>
    public ApplicationRole Role { get; set; }

    /// <summary>
    /// Gets or sets the UTC date and time when the claim was created.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who created this claim assignment.
    /// </summary>
    public string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the creator <see cref="ApplicationUser"/>.
    /// </summary>
    public ApplicationUser CreatedBy { get; set; } = null;

    /// <summary>
    /// Gets or sets the UTC date and time when the claim was last modified.
    /// </summary>
    /// <remarks>
    /// Null if the claim assignment has never been modified after creation.
    /// </remarks>
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who last modified this claim assignment.
    /// </summary>
    public string ModifiedById { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the last modifier <see cref="ApplicationUser"/>.
    /// </summary>
    public ApplicationUser ModifiedBy { get; set; } = null;
}
