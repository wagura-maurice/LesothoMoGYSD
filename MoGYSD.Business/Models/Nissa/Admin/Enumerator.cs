using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Models.Nissa.Admin;

/// <summary>
/// Represents an enumerator entity that implements <see cref="IAuditableEntity"/> for audit tracking.
/// Enumerators are field data collectors associated with registration centers.
/// </summary>
public class Enumerator : IAuditableEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the enumerator record.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the foreign key to the <see cref="ApplicationUser"/> account for this enumerator.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the <see cref="ApplicationUser"/> account.
    /// </summary>
    public virtual ApplicationUser User { get; set; }

    /// <summary>
    /// Gets or sets the foreign key to the assigned <see cref="RegistrationCentre"/>.
    /// </summary>
    public int RegistrationCentreId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the assigned <see cref="RegistrationCentre"/>.
    /// </summary>
    public virtual RegistrationCentre RegistrationCentre { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this enumerator has supervisor privileges.
    /// </summary>
    /// <value>
    /// <c>true</c> if the enumerator is a supervisor; otherwise, <c>false</c>.
    /// </value>
    public bool IsSupervisor { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this enumerator account is active.
    /// </summary>
    /// <value>
    /// <c>true</c> if the enumerator is active; otherwise, <c>false</c>.
    /// </value>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the date and time when this enumerator record was created.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the foreign key to the <see cref="ApplicationUser"/> who created this record.
    /// </summary>
    public string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the creator <see cref="ApplicationUser"/>.
    /// </summary>
    public ApplicationUser CreatedBy { get; set; } = null;

    /// <summary>
    /// Gets or sets the date and time when this enumerator record was last modified.
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// Gets or sets the foreign key to the <see cref="ApplicationUser"/> who last modified this record.
    /// </summary>
    public string ModifiedById { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the modifier <see cref="ApplicationUser"/>.
    /// </summary>
    public ApplicationUser ModifiedBy { get; set; } = null;
}