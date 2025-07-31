using System.ComponentModel.DataAnnotations;

namespace MoGYSD.Business.Models.Nissa.Admin;

/// <summary>
/// Represents a system configuration setting used for application-wide parameters
/// </summary>
public class SystemSetting
{
    /// <summary>
    /// Gets or sets the unique identifier for the system setting
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the unique key identifying the setting
    /// </summary>
    /// <remarks>
    /// Used to retrieve the setting programmatically.
    /// Examples: "AppTimeoutMinutes", "MaxLoginAttempts", "DefaultPageSize"
    /// </remarks>
    [Required]
    public string Key { get; set; }

    /// <summary>
    /// Gets or sets the value of the system setting
    /// </summary>
    /// <remarks>
    /// Stored as text but may represent different data types (numbers, JSON, etc.)
    /// </remarks>
    [DataType(DataType.MultilineText), Required]
    public string Value { get; set; }
}