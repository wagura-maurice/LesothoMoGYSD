using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Nissa.Administration;

/// <summary>
/// ViewModel representing a District entity for UI interaction
/// </summary>
public class DistrictViewModel
{
    /// <summary>
    /// Unique identifier for the District
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Unique code identifying the District (must be exactly 2 digits)
    /// </summary>
    [Required(ErrorMessage = "District code is required")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "Code must be exactly 2 digits")]
    [RegularExpression(@"^[0-9]{2}$", ErrorMessage = "Code must contain exactly 2 digits (0-9)")]
    [Display(Name = "District Code")]
    public string Code { get; set; }

    /// <summary>
    /// Name of the District
    /// </summary>
    [Required(ErrorMessage = "District name is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
    [Display(Name = "District Name")]
    public string Name { get; set; }

    /// <summary>
    /// Indicates whether the District is currently active
    /// </summary>
    [Display(Name = "Active")]
    public bool IsActive { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedOn { get; set; }
}
