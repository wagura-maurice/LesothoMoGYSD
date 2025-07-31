using System.ComponentModel.DataAnnotations;
namespace MoGYSD.ViewModels.Nissa.MasterRegistrations;
/// <summary>
/// ViewModel for managing Community Councils within Registration Districts
/// </summary>
public class RegistrationDistrictCCViewModel
{
    /// <summary>
    /// Unique identifier for the community council registration
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Reference to the district registration
    /// </summary>
    [Required(ErrorMessage = "District registration reference is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Invalid district registration reference")]
    [Display(Name = "District Registration")]
    public int RegistrationDistrictId { get; set; }

    /// <summary>
    /// Name of the community council
    /// </summary>
    [Required(ErrorMessage = "Community council name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    [Display(Name = "Community Council")]
    public string Name { get; set; }

    /// <summary>
    /// Community council identifier
    /// </summary>
    [Required(ErrorMessage = "Community council is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid community council")]
    [Display(Name = "Community Council")]
    public int? CCId { get; set; }

    /// <summary>
    /// Projected number of households
    /// </summary>
    [Required(ErrorMessage = "Projected households is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Household count must be at least 1")]
    [Display(Name = "Projected Households")]
    public int? ProjectedHHs { get; set; }
    public bool HasError { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedOn { get; set; }
}