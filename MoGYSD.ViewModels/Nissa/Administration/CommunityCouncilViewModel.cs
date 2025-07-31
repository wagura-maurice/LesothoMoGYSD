using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Nissa.Administration;

/// <summary>
/// ViewModel representing a Community Council entity for UI interaction
/// </summary>
public class CommunityCouncilViewModel
{
    /// <summary>
    /// Unique identifier for the Community Council
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Unique code identifying the Community Council
    /// </summary>
    [Required(ErrorMessage = "Village code is required")]
    [RegularExpression(@"^\d{2}-\d{2}-\d{2}$", ErrorMessage = "Code must be in the format 12-15-13")]
    [Display(Name = "Village Code")]
    public string Code { get; set; }

    [Required(ErrorMessage = "Community council code is required")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "Code must be 2 digits")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Code must contain digits only")]
    [Display(Name = "Code")]
    public string UserCodeSuffix { get; set; } = string.Empty;

    /// <summary>
    /// Name of the Community Council
    /// </summary>
    [Required(ErrorMessage = "Community Council name is required")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 100 characters")]
    [Display(Name = "Community Council Name")]
    public string CommunityCouncilName { get; set; }

    /// <summary>
    /// Indicates whether the Community Council is currently active
    /// </summary>
    [Display(Name = "Active")]
    public bool IsActive { get; set; }

    /// <summary>
    /// Foreign key reference to the District this Community Council belongs to
    /// </summary>
    [Required(ErrorMessage = "District is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid District")]
    [Display(Name = "District")]
    public int? DistrictId { get; set; }

    /// <summary>
    /// Foreign key reference to the Constituency this Community Council belongs to
    /// </summary>
    [Required(ErrorMessage = "Constituency is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid Constituency")]
    [Display(Name = "Constituency")]
    public int? ConstituencyId { get; set; }
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who created the entity.
    /// </summary>
    public string CreatedById { get; set; }
}

