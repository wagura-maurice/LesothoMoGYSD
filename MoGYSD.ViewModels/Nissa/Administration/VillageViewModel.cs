using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Nissa.Administration;

/// <summary>
/// ViewModel representing a Village entity for UI interaction
/// </summary>
public class VillageViewModel
{
    /// <summary>
    /// Unique identifier for the Village
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Unique code identifying the Village (must be exactly 3 digits)
    /// </summary>
    [Required(ErrorMessage = "Village code is required")]
    [RegularExpression(@"^\d{2}-\d{2}-\d{2}-\d{3}$", ErrorMessage = "Code must be in the format 12-15-13-254")]
    [Display(Name = "Village Code")]
    public string Code { get; set; }

    [Required(ErrorMessage = "Village code is required")]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "Code must be 3 digits")]
    [Display(Name = "Code")]
    public string UserCodeSuffix { get; set; } = string.Empty;

    /// <summary>
    /// Name of the Village
    /// </summary>
    [Required(ErrorMessage = "Village name is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
    [Display(Name = "Village Name")]
    public string Name { get; set; }

    /// <summary>
    /// Indicates whether the Village is currently active
    /// </summary>
    [Display(Name = "Active")]
    public bool IsActive { get; set; }

    /// <summary>
    /// Foreign key reference to the Community Council this Village belongs to
    /// </summary>
    [Required(ErrorMessage = "Community Council is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid Community Council")]
    [Display(Name = "Community Council")]
    public int? CommunityCouncilId { get; set; }
    /// <summary>
    /// Foreign key reference to the District
    /// </summary>
    public int? DistrictId { get; set; }
    /// <summary>
    /// Foreign key reference to the Constituency
    /// </summary>
    public int? ConstituencyId { get; set; }
    /// <summary>
    /// ID of the user who created the Village
    /// </summary>
    public string CreatedById { get; set; }
    /// <summary>
    /// Timestamp for when the Village was created
    /// </summary>
    public DateTime CreatedOn { get; set; }
}
