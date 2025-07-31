namespace MoGYSD.Business.Views.Nissa.Admin;
/// <summary>
/// Represents a view model for Community Council information, including associated district and audit information.
/// </summary>
public class CommunityCouncilView
{
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the unique code identifier for the community council.
    /// </summary>
    /// <example>"CC01"</example>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the name of the community council.
    /// </summary>
    /// <example>"Springfield Community Council"</example>
    public string CommunityCouncilName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the community council is currently active.
    /// </summary>
    /// <value>True if the council is active; otherwise, false.</value>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the ID of the district to which this community council belongs.
    /// </summary>
    public int DistrictId { get; set; }

    /// <summary>
    /// Gets or sets the name of the district to which this community council belongs.
    /// </summary>
    public string DistrictName { get; set; }
    /// <summary>
    /// Gets or sets the ID of the district to which this community council belongs.
    /// </summary>
    public int ConstituencyId { get; set; }

    /// <summary>
    /// Gets or sets the name of the district to which this community council belongs.
    /// </summary>
    public string ConstituencyName { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who created this community council record.
    /// </summary>
    /// <remarks>
    /// This value is automatically set by the system when the record is first created.
    /// </remarks>
    public string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who last modified this community council record.
    /// </summary>
    /// <remarks>
    /// This value is updated automatically by the system whenever the record is modified.
    /// </remarks>
    public string ModifiedById { get; set; }

    /// <summary>
    /// Gets or sets the display name of the user who created this community council record.
    /// </summary>
    /// <remarks>
    /// This is typically the user's full name or username for display purposes.
    /// </remarks>
    public string CreatedByName { get; set; }

    /// <summary>
    /// Gets or sets the display name of the user who last modified this community council record.
    /// </summary>
    public string ModifiedByName { get; set; }
}
