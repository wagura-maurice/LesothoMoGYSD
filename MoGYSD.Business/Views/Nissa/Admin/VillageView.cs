namespace MoGYSD.Business.Views.Nissa.Admin;

/// <summary>
/// Represents a view model for Village information, including its administrative hierarchy and audit trail.
/// </summary>
public class VillageView
{
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the unique code identifier for the village.
    /// </summary>
    /// <example>"VL001" or "A1"</example>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the official name of the village.
    /// </summary>
    /// <example>"Green Valley"</example>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the ID of the parent Community Council this village belongs to.
    /// </summary>
    public int CommunityCouncilId { get; set; }

    /// <summary>
    /// Gets or sets the name of the parent Community Council this village belongs to.
    /// </summary>
    /// <example>"Springfield Community Council"</example>
    public string CommunityCouncilName { get; set; }
    /// <summary>
    /// Gets or sets the ID of the Constituency to which this village belongs to.
    /// </summary>
    public int ConstituencyId { get; set; }

    /// <summary>
    /// Gets or sets the name of the Constituency to which this village belongs to.
    /// </summary>
    public string ConstituencyName { get; set; }

    /// <summary>
    /// Gets or sets the ID of the District this village belongs to.
    /// </summary>
    public int DistrictId { get; set; }

    /// <summary>
    /// Gets or sets the name of the District this village belongs to.
    /// </summary>
    /// <example>"Northern District"</example>
    public string DistrictName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the village is currently active.
    /// </summary>
    /// <value>
    /// <c>true</c> if the village is active; otherwise, <c>false</c>.
    /// </value>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who created this village record.
    /// </summary>
    /// <remarks>
    /// System-managed field. Automatically populated when the record is created.
    /// </remarks>
    public string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who last modified this village record.
    /// </summary>
    /// <remarks>
    /// System-managed field. Automatically updated when the record is modified.
    /// </remarks>
    public string ModifiedById { get; set; }

    /// <summary>
    /// Gets or sets the display name of the user who created this village record.
    /// </summary>
    /// <remarks>
    /// Typically shows the user's full name for reporting purposes.
    /// </remarks>
    public string CreatedByName { get; set; }

    /// <summary>
    /// Gets or sets the display name of the user who last modified this village record.
    /// </summary>
    public string ModifiedByName { get; set; }
}
