namespace MoGYSD.ViewModels.Nissa.DistrictRegistrations;
using System;
using System.ComponentModel.DataAnnotations;
/// <summary>
/// ViewModel for District Registration Plan management
/// </summary>
public class DistrictRegistrationPlanViewModel
{
    /// <summary>
    /// Unique identifier for the registration plan
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Reference to the master registration plan
    /// </summary>
    [Required(ErrorMessage = "Master Registration Plan reference is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Invalid Master Plan reference")]
    [Display(Name = "Master Plan")]
    public int? MasterRegistrationPlanId { get; set; }

    [Required(ErrorMessage = "Master Registration Plan reference is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Invalid Master Plan reference")]
    [Display(Name = "Master Plan")]
    public int? DistrictRegistrationPlanId { get; set; }

    /// <summary>
    /// District where the plan will be implemented
    /// </summary>
    [Required(ErrorMessage = "District is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid district")]
    [Display(Name = "District")]
    public int? DistrictId { get; set; }

    /// <summary>
    /// Current status of the registration plan
    /// </summary>
    [Required(ErrorMessage = "Plan status is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid status")]
    [Display(Name = "Plan Status")]
    public int? StatusId { get; set; }

    /// <summary>
    /// Name of the registration plan
    /// </summary>
    [Required(ErrorMessage = "Plan name is required")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Plan name must be between 5 and 100 characters")]
    [Display(Name = "Plan Name")]
    public string RegistrationPlanName { get; set; }

    /// <summary>
    /// Detailed description of the registration plan
    /// </summary>
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    [DataType(DataType.MultilineText)]
    [Display(Name = "Plan Description")]
    public string Description { get; set; }

    /// <summary>
    /// Approved budget amount for the plan
    /// </summary>
    [Required(ErrorMessage = "Approved budget amount is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Budget must be greater than 0")]
    [DataType(DataType.Currency)]
    [Display(Name = "Approved Budget")]
    public decimal? ApprovedBudgetAmount { get; set; }

    /// <summary>
    /// Expected number of households to be registered
    /// </summary>
    [Required(ErrorMessage = "Expected households count is required")]
    [Range(1, 1000000, ErrorMessage = "Household count must be between 1 and 1,000,000")]
    [Display(Name = "Expected Households")]
    public int? ExpectedNoHouseholds { get; set; }

    /// <summary>
    /// Projected start date for the registration plan
    /// </summary>
    [Required(ErrorMessage = "Projected start date is required")]
    [DataType(DataType.Date)]
    [Display(Name = "Projected Start")]
    public DateTime? ProjectedStartDate { get; set; }

    /// <summary>
    /// Projected end date for the registration plan
    /// </summary>
    [DataType(DataType.Date)]
    [Display(Name = "Projected End")]
    [DateGreaterThan(nameof(ProjectedStartDate), ErrorMessage = "End date must be after start date")]
    public DateTime? ProjectedEndDate { get; set; }

    /// <summary>
    /// Actual start date of the registration plan
    /// </summary>
    [DataType(DataType.Date)]
    [Display(Name = "Actual Start")]
    public DateTime? ActualStartDate { get; set; }

    /// <summary>
    /// Actual end date of the registration plan
    /// </summary>
    [DataType(DataType.Date)]
    [Display(Name = "Actual End")]
    [DateGreaterThan(nameof(ActualStartDate), ErrorMessage = "End date must be after start date")]
    public DateTime? ActualEndDate { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedOn { get; set; }
}
