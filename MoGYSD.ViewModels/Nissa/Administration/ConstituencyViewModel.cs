using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Nissa.Administration;

public class ConstituencyViewModel
{
    /// <summary>
    /// Unique identifier for the Constituency
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Name of the Constituency
    /// </summary>
    [Required(ErrorMessage = "Constituency name is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
    [Display(Name = "Constituency Name")]
    public string Name { get; set; }
    /// <summary>
    /// Code of the Constituency
    /// </summary>
    [Required(ErrorMessage = "Constituency code is required")]
    [RegularExpression(@"^\d{2}-\d{2}$", ErrorMessage = "Code must be in the format 12-15")]
    [Display(Name = "Constituency Code")]
    public string Code { get; set; }
    /// <summary>
    /// Indicates whether the Constituency is currently active
    /// </summary>
    [Display(Name = "Active")]
    public bool Status { get; set; }

    /// <summary>
    /// Foreign key reference to the District this Community Council belongs to
    /// </summary>
    [Required(ErrorMessage = "District is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid District")]
    [Display(Name = "District")]
    public int? DistrictId { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedOn { get; set; }
    [Required(ErrorMessage = "Community council code is required")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "Code must be 2 digits")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Code must contain digits only")]
    [Display(Name = "Code")]
    public string UserCodeSuffix { get; set; } = string.Empty;
}