using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.Admin;

/// <summary>
/// Represents a registration center entity used for organizing and managing registration activities,
/// inheriting audit tracking capabilities from <see cref="BaseAuditableEntity{T}"/>.
/// </summary>
public class RegistrationCentre : BaseAuditableEntity<int>
{
    /// <summary>
    /// Gets or sets the unique code identifier for the registration center.
    /// </summary>
    /// <remarks>
    /// Typically follows a standardized format for system reference.
    /// </remarks>
    public string CentreCode { get; set; }

    /// <summary>
    /// Gets or sets the official name of the registration center.
    /// </summary>
    public string CentreName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the registration center is currently active.
    /// </summary>
    /// <value>
    /// <c>true</c> if the center is active; otherwise, <c>false</c>.
    /// </value>
    public bool IsActive { get; set; }
    /// <summary>
    /// Gets or sets the ID of the supervisor user responsible for this center.
    /// </summary>
    public string SupervisorId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> supervisor.
    /// </summary>
    public virtual ApplicationUser Supervisor { get; set; } = null!;

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who created this record.
    /// </summary>
    public virtual ApplicationUser CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> who last modified this record.
    /// </summary>
    public virtual ApplicationUser ModifiedBy { get; set; }
    public ICollection<UserRegistrationCentreAssignment> UserAssignments { get; set; } = new List<UserRegistrationCentreAssignment>();

}