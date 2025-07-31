namespace MoGYSD.Business.Views.Nissa.Districtregistrations;

/// <summary>
/// Represents a view of registered community councils including their association with
/// district registration plans and current status for tracking purposes.
/// </summary>
public class CCsRegisteredView
{
    /// <summary>
    /// Gets or sets the unique identifier for the community council registration.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the district registration plan.
    /// </summary>
    public int DistrictRegistrationPlanId { get; set; }

    /// <summary>
    /// Gets or sets the name of the associated district registration plan.
    /// </summary>
    public string DistrictRegistrationPlanName { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the community council.
    /// </summary>
    public int CommunityCouncilId { get; set; }

    /// <summary>
    /// Gets or sets the name of the registered community council.
    /// </summary>
    public string CommunityCouncilName { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the registration status.
    /// </summary>
    public int StatusId { get; set; }

    /// <summary>
    /// Gets or sets the name of the registration status (e.g., "Pending", "Approved").
    /// </summary>
    public string StatusName { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the registration was created.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who created this registration.
    /// </summary>
    public string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who created this registration.
    /// </summary>
    public string CreatedByName { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the registration was last modified.
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who last modified this registration.
    /// </summary>
    public string ModifiedById { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who last modified this registration.
    /// </summary>
    public string ModifiedByName { get; set; }
}
