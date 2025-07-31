namespace MoGYSD.Business.Views.Nissa.Admin;
/// <summary>
/// Represents a view of system code details including hierarchical relationships and display properties,
/// optimized for reference data management interfaces.
/// </summary>
public class SystemCodeDetailsView
{
    /// <summary>
    /// Gets or sets the unique identifier for the system code detail record.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the parent code value from the associated <see cref="SystemCode"/>.
    /// </summary>
    /// <remarks>
    /// Represents the category code this detail belongs to.
    /// Example: For a gender detail "M", the parent code might be "GENDER".
    /// </remarks>
    public string ParentCode { get; set; }
    /// <summary>
    /// Gets the parent code id from the associated <see cref="SystemCode"/>.
    /// </summary>
    /// <remarks>
    /// Represents the Id this detail belongs to.
    /// </remarks>
    public int SystemCodeId { get; set; }

    /// <summary>
    /// Gets or sets the short code value used for programmatic reference.
    /// </summary>
    /// <remarks>
    /// Typically an abbreviated identifier (e.g., "M" for Male, "ACT" for Active).
    /// </remarks>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the detailed description of the code value.
    /// </summary>
    /// <remarks>
    /// Provides human-readable context for the code value.
    /// </remarks>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the display name for the code value (typically same as Description).
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the sort order position for display purposes.
    /// </summary>
    /// <remarks>
    /// Null indicates no specific sorting preference.
    /// Lower numbers appear first in ordered lists.
    /// </remarks>
    public int? OrderNo { get; set; }
}
