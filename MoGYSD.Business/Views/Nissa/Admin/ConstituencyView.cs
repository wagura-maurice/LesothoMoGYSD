namespace MoGYSD.Business.Views.Nissa.Admin;

public class ConstituencyView
{
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the unique code identifier for the Constituency.
    /// </summary>
    /// <example>"ED001" or "B2"</example>
    public string Code { get; set; }
    /// <summary>
    /// Gets or sets the official name of the Constituency.
    /// </summary>
    /// <example>"Central Division"</example>
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets the ID of the parent District this Constituency belongs to.
    /// </summary>
    public int DistrictId { get; set; }
    /// <summary>
    /// Gets or sets the name of the District this Constituency belongs to.
    /// </summary>
    /// <example>"Southern District"</example>
    public string DistrictName { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether the Constituency is currently active.
    /// </summary>
    public bool Status { get; set; }
}