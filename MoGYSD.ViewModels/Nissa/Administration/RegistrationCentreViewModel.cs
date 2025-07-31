using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Nissa.Administration;

/// <summary>
/// Represents a registration centre with associated details and assigned villages.
/// Used for creating/editing registration centres in the system.
/// </summary>
public class RegistrationCentreViewModel
{
    /// <summary>
    /// Unique identifier for the registration centre.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Code assigned to the registration centre (e.g., "RC-1001").
    /// - Required field.
    /// - Maximum length: 20 characters.
    /// </summary>
    public string CentreCode { get; set; }

    /// <summary>
    /// Name of the registration centre (e.g., "Main City Registration").
    /// - Required field.
    /// - Maximum length: 100 characters.
    /// </summary>
    [Required(ErrorMessage = "Centre Name is required.")]
    [StringLength(100, ErrorMessage = "Centre Name cannot exceed 100 characters.")]
    [Display(Name = "Centre Name")]
    public string CentreName { get; set; }

    /// <summary>
    /// ID of the supervisor responsible for this centre.
    /// - Required field.
    /// - Could reference a User ID or Employee ID.
    /// </summary>
    [Required(ErrorMessage = "Supervisor ID is required.")]
    [Display(Name = "Supervisor")]
    public string SupervisorId { get; set; }

    /// <summary>
    /// Indicates whether the centre is currently active.
    /// - Defaults to false if not set.
    /// </summary>
    [Display(Name = "Active Status")]
    public bool IsActive { get; set; }

    /// <summary>
    /// List of village IDs assigned to this registration centre.
    /// - At least one village must be selected.
    /// - Used for multi-select dropdowns in forms.
    /// </summary>
    [Required(ErrorMessage = "At least one village must be selected.")]
    [MinLength(1, ErrorMessage = "At least one village must be selected.")]
    [Display(Name = "Assigned Villages")]
    public List<int> VillageIds { get; set; } = new();
    [Required(ErrorMessage = "Assigned Village is required.")]
    [Display(Name = "Assigned Village")]
    public int? VillageIId { get; set; }

    [Required(ErrorMessage = "Community Council is required.")]
    public int? CommunityCouncilId { get; set; }

    [Required(ErrorMessage = "District is required.")]
    public int? DistrictId { get; set; }

    [Required(ErrorMessage = "Constituency is required.")]
    public int? ConstituencyId { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedOn { get; set; }
}
