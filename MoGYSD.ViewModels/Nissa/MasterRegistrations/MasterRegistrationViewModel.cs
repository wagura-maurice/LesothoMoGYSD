using MoGYSD.ViewModels.Nissa.DistrictRegistrations;
using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Nissa.Nissa.MasterRegistrations;
/// <summary>
/// ViewModel for managing Master Registration Plans
/// </summary>
public class MasterRegistrationViewModel
{
    /// <summary>
    /// Unique identifier for the master registration plan
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Data collection type identifier
    /// </summary>
    [Required(ErrorMessage = "Data collection type is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid data collection type")]
    [Display(Name = "Data Collection Type")]
    public int? DataCollectionTypeId { get; set; }

    /// <summary>
    /// Display name of the data collection type
    /// </summary>
    [Display(Name = "Data Collection Type")]
    public string DataCollectionType { get; set; }

    /// <summary>
    /// Status identifier for the plan
    /// </summary>
    [Required(ErrorMessage = "Status is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid status")]
    [Display(Name = "Status")]
    public int? StatusId { get; set; }

    /// <summary>
    /// Display name of the status
    /// </summary>
    [Display(Name = "Status")]
    public string Status { get; set; }

    /// <summary>
    /// Plan type identifier
    /// </summary>
    [Required(ErrorMessage = "Plan type is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid plan type")]
    [Display(Name = "Plan Type")]
    public int? PlanTypeId { get; set; }

    /// <summary>
    /// Display name of the plan type
    /// </summary>
    [Display(Name = "Plan Type")]
    public string PlanType { get; set; }

    /// <summary>
    /// PMT formula identifier
    /// </summary>
    [Required(ErrorMessage = "PMT formula is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid PMT formula")]
    [Display(Name = "PMT Formula")]
    public int? PMTFormulaId { get; set; }

    /// <summary>
    /// Name of the master plan
    /// </summary>
    [Required(ErrorMessage = "Master plan name is required")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "Plan name must be between 5 and 100 characters")]
    [Display(Name = "Master Plan Name")]
    public string MasterPlanName { get; set; }

    /// <summary>
    /// Description of the master plan
    /// </summary>
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    [DataType(DataType.MultilineText)]
    [Display(Name = "Description")]
    public string Description { get; set; }

    /// <summary>
    /// Financial year for the plan
    /// </summary>
    [Required(ErrorMessage = "Financial Year is required")]
    [Display(Name = "Financial Year")]
    public string FinancialYear { get; set; }
    [Required(ErrorMessage = "Financial Year is required")]
    [Display(Name = "Financial Year")]
    public DateTime? FinancialYears { get; set; }

    /// <summary>
    /// Approved budget amount
    /// </summary>
    [Required(ErrorMessage = "Approved budget amount is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Budget must be greater than 0")]
    [DataType(DataType.Currency)]
    [Display(Name = "Approved Budget")]
    public decimal? ApprovedBudgetAmount { get; set; }

    /// <summary>
    /// Estimated number of households
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "Household count must be at least 1")]
    [Display(Name = "Estimated Households")]
    public int? EstimatedHHs { get; set; }

    /// <summary>
    /// Projected start date
    /// </summary>
    [DataType(DataType.Date)]
    [Display(Name = "Projected Start Date")]
    public DateTime? ProjectedStartDate { get; set; }

    /// <summary>
    /// Projected end date
    /// </summary>
    [DataType(DataType.Date)]
    [Display(Name = "Projected End Date")]
    [DateGreaterThan(nameof(ProjectedStartDate), ErrorMessage = "End date must be after start date")]
    public DateTime? ProjectedEndDate { get; set; }


    public DateTime? ActualStartDate { get; set; }

    public DateTime? ActualEndDate { get; set; }

    /// <summary>
    /// Date when the record was created
    /// </summary>
    [Display(Name = "Created On")]
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Identifier of the user who created the record
    /// </summary>
    [Display(Name = "Created By")]
    public string CreatedById { get; set; }

    /// <summary>
    /// Name of the user who created the record
    /// </summary>
    [Display(Name = "Created By")]
    public string CreatedBy { get; set; }

    /// <summary>
    /// Date when the record was last modified
    /// </summary>
    [Display(Name = "Modified On")]
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// Identifier of the user who last modified the record
    /// </summary>
    [Display(Name = "Modified By")]
    public string ModifiedById { get; set; }

    /// <summary>
    /// Name of the user who last modified the record
    /// </summary>
    [Display(Name = "Modified By")]
    public string ModifiedBy { get; set; }
    /// <summary>
    /// Gets or sets the categorization discrepancy as a percentage.
    /// </summary>
    /// <remarks>
    /// This value must be positive and is expressed as a decimal (e.g., 0.25 for 25%).
    /// </remarks>
    [Display(Name = "Categorization Discrepancy (%)")]
    [Range(0, 100, ErrorMessage = "Discrepancy must be between 0% and 100%.")]
    public decimal? CategorizationDiscrepancy { get; set; }
    public int? CurrencyId { get; set; }
    public decimal? ExchangeRate { get; set; }
    public decimal? CurrencyAmount { get; set; }

}
