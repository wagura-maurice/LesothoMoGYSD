namespace MoGYSD.Business.Views.Nissa.Admin;

/// <summary>
/// Represents a comprehensive view of registration center information combining core details,
/// supervisor information, and geographic context for operational reporting and management.
/// </summary>
public class RegistrationCentreView
{
    /// <summary>
    /// Gets or sets the unique identifier for the registration center.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the official code assigned to the registration center.
    /// </summary>
    /// <remarks>
    /// Follows standardized format (e.g., "RC-1001") for system reference.
    /// </remarks>
    public string CentreCode { get; set; }

    /// <summary>
    /// Gets or sets the formal name of the registration center.
    /// </summary>
    public string CentreName { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether the registration center is currently operational.
    /// </summary>
    /// <value>
    /// <c>true</c> if the center is active and accepting registrations; otherwise, <c>false</c>.
    /// </value>
    public bool IsActive { get; set; }
    /// <summary>
    /// Gets or sets the user ID of the assigned supervisor.
    /// </summary>
    public string SupervisorId { get; set; }

    /// <summary>
    /// Gets or sets the full name of the assigned supervisor.
    /// </summary>
    /// <remarks>
    /// Format: "FirstName LastName" from associated user profile.
    /// </remarks>
    public string SupervisorName { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who created this registration center record.
    /// </summary>
    public string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who created this registration center record.
    /// </summary>
    public string CreatedByName { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who last modified this registration center record.
    /// </summary>
    public string ModifiedById { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who last modified this registration center record.
    /// </summary>
    public string ModifiedByName { get; set; }


}
