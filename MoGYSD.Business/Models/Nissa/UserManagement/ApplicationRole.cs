using Microsoft.AspNetCore.Identity;
using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;

namespace MoGYSD.Business.Models.Nissa.UserManagement;
/// <summary>
/// Represents an application role extending ASP.NET Core Identity's <see cref="IdentityRole"/>
/// with audit capabilities through <see cref="IAuditableEntity"/> implementation.
/// </summary>
/// <remarks>
/// Includes role management features such as claims association and active status tracking.
/// </remarks>
public class ApplicationRole : IdentityRole, IAuditableEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationRole"/> class.
    /// </summary>
    public ApplicationRole()
    {
        RoleClaims = new HashSet<ApplicationRoleClaim>();
        UserRoles = new HashSet<ApplicationUserRole>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationRole"/> class with a role name.
    /// </summary>
    /// <param name="roleName">The name of the role to create</param>
    public ApplicationRole(string roleName) : base(roleName)
    {
        RoleClaims = new HashSet<ApplicationRoleClaim>();
        UserRoles = new HashSet<ApplicationUserRole>();
    }

    /// <summary>
    /// Gets or sets a value indicating whether the role is currently active.
    /// </summary>
    /// <value>
    /// <c>true</c> if the role is active and can be assigned; otherwise, <c>false</c>.
    /// </value>
    public bool IsActive { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether the role is self register.
    /// </summary>
    /// <value>
    /// <c>true</c> if the role is self register, users can register online; otherwise, <c>false</c>.
    /// </value>
    public bool IsSelfRegister { get; set; }
    public int? SystemCodeDetailId { get; set; }
    public string Description { get; set; } = string.Empty;
    public virtual SystemCodeDetail SystemCodeDetail { get; set; }

    /// <summary>
    /// Gets or sets the collection of claims associated with this role.
    /// </summary>
    public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }

    /// <summary>
    /// Gets or sets the collection of user-role associations for this role.
    /// </summary>
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

    /// <summary>
    /// Gets or sets the UTC date and time when the role was created.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who created this role.
    /// </summary>
    public string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the creator <see cref="ApplicationUser"/>.
    /// </summary>
    public ApplicationUser CreatedBy { get; set; } = null;

    /// <summary>
    /// Gets or sets the UTC date and time when the role was last modified.
    /// </summary>
    /// <remarks>
    /// Null if the role has never been modified after creation.
    /// </remarks>
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who last modified this role.
    /// </summary>
    public string ModifiedById { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the last modifier <see cref="ApplicationUser"/>.
    /// </summary>
    public ApplicationUser ModifiedBy { get; set; } = null;
}
