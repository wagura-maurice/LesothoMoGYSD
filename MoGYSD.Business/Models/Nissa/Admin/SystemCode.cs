namespace MoGYSD.Business.Models.Nissa.Admin;

/// <summary>
/// Represents a category or grouping of system reference codes used throughout the application
/// </summary>
public class SystemCode
{
    /// <summary>
    /// Gets or sets the unique identifier for the system code category
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the unique code identifying the category
    /// </summary>
    /// <remarks>
    /// Examples: "GENDER", "STATUS", "COUNTRY"
    /// </remarks>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the human-readable description of the code category
    /// </summary>
    /// <remarks>
    /// Used for display purposes in administration interfaces
    /// </remarks>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the collection of <see cref="SystemCodeDetail"/> items belonging to this category
    /// </summary>
    /// <remarks>
    /// Represents the individual valid values within this code category
    /// </remarks>
    public ICollection<SystemCodeDetail> SystemCodeDetails { get; set; }
}