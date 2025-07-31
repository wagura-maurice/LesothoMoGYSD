using MoGYSD.ViewModels.Nissa.DistrictRegistrations;
using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Nissa.HouseHoldListings;
/// <summary>
/// ViewModel representing a listing plan for HH (likely Housing/Household) related operations
/// </summary>
public class HHListingPlanViewModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the listing plan
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the household listing activity
    /// Required field with minimum 3 and maximum 100 characters
    /// </summary>
    [Required(ErrorMessage = "Listing activity name is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Listing activity name must be between 3 and 100 characters")]
    [Display(Name = "Listing Activity Name")]
    public string HHListingActivityName { get; set; }

    /// <summary>
    /// Gets or sets the district identifier where the listing will occur
    /// Must be a positive number if provided
    /// </summary>
    [Required(ErrorMessage = "District is required")]
    [Display(Name = "District")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid district")]
    public int? DistrictId { get; set; }

    /// <summary>
    /// Gets or sets the district registration plan identifier
    /// Links to the broader registration plan for the district
    /// </summary>
    [Required(ErrorMessage = "District registration plan is required")]
    [Display(Name = "District Registration Plan")]
    public int? DistrictRegistrationPlanId { get; set; }

    /// <summary>
    /// Gets or sets the partner organization identifier
    /// Must be a positive number if provided
    /// </summary>
    [Required(ErrorMessage = "Partner is required")]
    [Display(Name = "Partner")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid partner")]
    public int? PartnersId { get; set; }

    /// <summary>
    /// Gets or sets the contact person identifier
    /// Represents the primary point of contact for this listing plan
    /// </summary>
    [Required(ErrorMessage = "Contact person is required")]
    [Display(Name = "Contact Person")]
    public int? ContactPersonId { get; set; }

    /// <summary>
    /// Gets or sets the name of the master registration plan
    /// Maximum length of 100 characters
    /// </summary>
    [Display(Name = "Master Registration Plan")]
    [StringLength(100, ErrorMessage = "Master registration plan name cannot exceed 100 characters")]
    public string MasterRegistrationPlanName { get; set; }

    /// <summary>
    /// Gets or sets the expected number of households to be listed
    /// Must be zero or positive number if provided
    /// </summary>
    [Display(Name = "Expected Number of Households")]
    [Range(0, int.MaxValue, ErrorMessage = "Expected households must be a positive number")]
    public int? ExpectedNoHouseholds { get; set; }

    /// <summary>
    /// Gets or sets the current status identifier of the listing plan
    /// Required field with valid status value (positive number)
    /// </summary>
    [Required(ErrorMessage = "Status is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Invalid status value")]
    [Display(Name = "Status")]
    public int StatusId { get; set; }

    /// <summary>
    /// Gets or sets the projected start date for the registration plan
    /// Required field that must be today or in the future
    /// </summary>
    [Required(ErrorMessage = "Projected start date is required")]
    [DataType(DataType.Date)]
    [Display(Name = "Projected Start")]
    [FutureDate(ErrorMessage = "Start date cannot be in the past")]
    public DateTime? ProjectedStartDate { get; set; }

    /// <summary>
    /// Gets or sets the projected end date for the registration plan
    /// Must be after the projected start date if provided
    /// </summary>
    [DataType(DataType.Date)]
    [Display(Name = "Projected End")]
    [DateGreaterThan(nameof(ProjectedStartDate), ErrorMessage = "End date must be after start date")]
    public DateTime? ProjectedEndDate { get; set; }

    /// <summary>
    /// Gets or sets the actual start date of the registration plan
    /// Captures when the listing activity actually began
    /// </summary>
    [DataType(DataType.Date)]
    [Display(Name = "Actual Start")]
    public DateTime? ActualStartDate { get; set; }

    /// <summary>
    /// Gets or sets the actual end date of the registration plan
    /// Must be after the actual start date if provided
    /// Captures when the listing activity actually completed
    /// </summary>
    [DataType(DataType.Date)]
    [Display(Name = "Actual End")]
    [DateGreaterThan(nameof(ActualStartDate), ErrorMessage = "End date must be after start date")]
    public DateTime? ActualEndDate { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who created this plan
    /// System-generated field
    /// </summary>
    public string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the date and time when this plan was created
    /// System-generated field
    /// </summary>
    public DateTime CreatedOn { get; set; }
}