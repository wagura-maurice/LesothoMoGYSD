using System.ComponentModel.DataAnnotations;
namespace MoGYSD.ViewModels.Nissa.MasterRegistrations;
/// <summary>
/// ViewModel for managing Districts within Registration Plans
/// </summary>
public class RegistrationDistrictViewModel
{
    /// <summary>
    /// Unique identifier for the district registration
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Reference to the master registration plan
    /// </summary>
    [Required(ErrorMessage = "Master registration plan is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Invalid master plan reference")]
    [Display(Name = "Master Plan")]
    public int MasterRegistrationPlanId { get; set; }

    /// <summary>
    /// District identifier
    /// </summary>
    [Required(ErrorMessage = "District is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid district")]
    [Display(Name = "District")]
    public int? DistrictId { get; set; }

    /// <summary>
    /// Name of the district
    /// </summary>
    [Required(ErrorMessage = "District name is required")]
    [StringLength(100, ErrorMessage = "District name cannot exceed 100 characters")]
    [Display(Name = "District Name")]
    public string Name { get; set; }

    /// <summary>
    /// Current population of the district
    /// </summary>
    [Required(ErrorMessage = "Current population is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Population must be at least 1")]
    [Display(Name = "Current Population")]
    public int? CurrentPopulation { get; set; }

    /// <summary>
    /// Estimated population of the district
    /// </summary>
    [Required(ErrorMessage = "Estimated population is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Population must be at least 1")]
    [Display(Name = "Estimated Population")]
    public int? EstimatedPopulation { get; set; }

    /// <summary>
    /// Prior coverage percentage
    /// </summary>
    [Required(ErrorMessage = "Prior coverage is required")]
    [Range(0, 100, ErrorMessage = "Prior coverage must be between 0 and 100")]
    [Display(Name = "Prior Coverage %")]
    public int? PriorCoverage { get; set; }

    /// <summary>
    /// Current coverage percentage
    /// </summary>
    [Required(ErrorMessage = "Current coverage is required")]
    [Range(1, 100, ErrorMessage = "Current coverage must be between 1 and 100")]
    [Display(Name = "Current Coverage")]
    public int? CurrentCoverage { get; set; }

    /// <summary>
    /// Total households to target
    /// </summary>
    [Required(ErrorMessage = "Household target is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Household target must be at least 1")]
    [Display(Name = "Target Households")]
    public int? TotalHHsToTarget { get; set; }

    /// <summary>
    /// Total households to target
    /// </summary>
    [Required(ErrorMessage = "Population target is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Population target must be at least 1")]
    [Display(Name = "Target Population")]
    public int? TotalPopulationToTarget { get; set; }

    /// <summary>
    /// Indicates whether work can be performed on this district
    /// </summary>
    [Display(Name = "Active for Work")]
    public bool CanWorkOn { get; set; }

    public bool HasError { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedOn { get; set; }
}
