namespace MoGYSD.Business.Views.Nissa.Admin;

/// <summary>
/// Represents a comprehensive view of enumerator information combining user account details,
/// registration center assignment, and operational status for field team management.
/// </summary>
public class EnumeratorView
{
    /// <summary>
    /// Gets or sets the unique identifier for the enumerator record.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the associated user account ID from Identity system.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Gets or sets the username/login of the enumerator.
    /// </summary>
    public string UserUserName { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the assigned registration center.
    /// </summary>
    public int RegistrationCentreId { get; set; }

    /// <summary>
    /// Gets or sets the name of the assigned registration center.
    /// </summary>
    public string RegistrationCentreName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the enumerator has supervisor privileges.
    /// </summary>
    /// <value>
    /// <c>true</c> if the enumerator can supervise other field staff; otherwise, <c>false</c>.
    /// </value>
    public bool IsSupervisor { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the enumerator account is active.
    /// </summary>
    /// <value>
    /// <c>true</c> if the enumerator can log in and perform work; otherwise, <c>false</c>.
    /// </value>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the enumerator record was created.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who created this enumerator record.
    /// </summary>
    public string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the enumerator record was last modified.
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who last modified this enumerator record.
    /// </summary>
    public string ModifiedById { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who created this enumerator record.
    /// </summary>
    public string CreatedByName { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who last modified this enumerator record.
    /// </summary>
    public string ModifiedByName { get; set; }
}