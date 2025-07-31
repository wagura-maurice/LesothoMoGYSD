namespace MoGYSD.Business.Models.Nissa.Admin;

/// <summary>
/// Represents a detailed code value within a system code category, used for lookup/reference data
/// </summary>
public class SystemCodeDetail
{
    /// <summary>
    /// Gets or sets the unique identifier for the code detail
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the parent <see cref="SystemCode"/> category
    /// </summary>
    public int SystemCodeId { get; set; }

    /// <summary>
    /// Gets or sets the short code value used for programmatic reference
    /// </summary>
    /// <remarks>
    /// Typically an abbreviated or standardized identifier (e.g., "M" for Male, "ACT" for Active)
    /// </remarks>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the display order position within the code list
    /// </summary>
    public int OrderNo { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the parent <see cref="SystemCode"/> category
    /// </summary>
    public SystemCode SystemCode { get; set; }

    /// <summary>
    /// Gets or sets the descriptive text for the code value
    /// </summary>
    /// <remarks>
    /// This is the human-readable description displayed in UIs
    /// </remarks>
    public string Description { get; set; }

    /// <summary>
    /// Gets the display name for the code (returns the Description value)
    /// </summary>
    /// <remarks>
    /// Provides a convenient property for display purposes, aliasing the Description field
    /// </remarks>
    public string Name => Description;
}