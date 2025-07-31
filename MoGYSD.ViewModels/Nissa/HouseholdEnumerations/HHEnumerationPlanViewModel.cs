using MoGYSD.Business.Models.Nissa.HouseHoldListings;
using MoGYSD.ViewModels.Nissa.DistrictRegistrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.ViewModels.Nissa.HouseholdEnumerations;


/// <summary>
/// Represents a Household Enumeration Plan for registration activities
/// </summary>
public class HHEnumerationPlanViewModel
{
    /// <summary>
    /// Primary key identifier
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Foreign key reference to associated Household Listing Plan
    /// </summary>
    [Display(Name = "Household Listing Plan")]
    [Required(ErrorMessage = "HH Listing Plan is required")]
    public int? HHListingPlanId { get; set; }

    /// <summary>
    /// Current status of the enumeration plan
    /// </summary>
    [Display(Name = "Status")]
    [Required(ErrorMessage = "Status is required")]
    public int? StatusId { get; set; }

    /// <summary>
    /// Registration center where enumeration will occur
    /// </summary>
    [Display(Name = "Registration Center")]
    public int? RegistrationCentreId { get; set; }

    /// <summary>
    /// Planned start date for enumeration activities
    /// </summary>
    [Display(Name = "Projected Start Date")]
    [Required(ErrorMessage = "Projected start date is required")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? ProjectedStartDate { get; set; }

    /// <summary>
    /// Planned completion date for enumeration activities
    /// </summary>
    [Display(Name = "Projected End Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    [DateGreaterThan(nameof(ProjectedStartDate), ErrorMessage = "End date must be after start date")]
    public DateTime? ProjectedEndDate { get; set; }

    /// <summary>
    /// Actual date when enumeration began
    /// </summary>
    [Display(Name = "Actual Start Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? ActualStartDate { get; set; }

    /// <summary>
    /// Actual date when enumeration was completed
    /// </summary>
    [Display(Name = "Actual End Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    [DateGreaterThan(nameof(ActualStartDate), ErrorMessage = "End date must be after start date")]
    public DateTime? ActualEndDate { get; set; }

    /// <summary>
    /// Name/Title of the enumeration plan
    /// </summary>
    [Display(Name = "Plan Name")]
    [Required(ErrorMessage = "Plan name is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3-100 characters")]
    public string Name { get; set; }

    /// <summary>
    /// Detailed description of the enumeration activities
    /// </summary>
    [Display(Name = "Description")]
    [DataType(DataType.MultilineText)]
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Date when the plan was created
    /// </summary>
    [Display(Name = "Created On")]
    [DataType(DataType.DateTime)]
    [ScaffoldColumn(false)]
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// User who created the plan
    /// </summary>
    [Display(Name = "Created By")]
    [ScaffoldColumn(false)]
    public string CreatedById { get; set; }

    /// <summary>
    /// Date when the plan was last modified
    /// </summary>
    [Display(Name = "Modified On")]
    [DataType(DataType.DateTime)]
    [ScaffoldColumn(false)]
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// User who last modified the plan
    /// </summary>
    [Display(Name = "Modified By")]
    [ScaffoldColumn(false)]
    public string ModifiedById { get; set; } = string.Empty;
}


public class EnumerationPlanCCSummary
{
    public string Name { get; set; } = string.Empty;
    public int CommunityCouncilId { get; set; }
    public string CommunityCouncilName { get; set; } = string.Empty;
    public int VillageCount { get; set; }
}

public class EnumerationAreaViewModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the Enumeration Area.
    /// Should be 0 or omitted for new records.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the Enumeration Area.
    /// </summary>
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(200, ErrorMessage = "Name cannot exceed 200 characters.")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the ID of the related HH Enumeration Plan.
    /// </summary>
    [Required(ErrorMessage = "HH Enumeration Plan Id is required.")]
    public int HHEnumerationPlanId { get; set; }

    /// <summary>
    /// Gets or sets the list of village IDs associated with this Enumeration Area.
    /// </summary>
    [Required(ErrorMessage = "At least one village must be selected.")]
    [MinLength(1, ErrorMessage = "At least one village must be selected.")]
    public List<int> EnumerationAreaVillageIds { get; set; } = new();

    /// <summary>
    /// Date when the plan was created
    /// </summary>
    [Display(Name = "Created On")]
    [DataType(DataType.DateTime)]
    [ScaffoldColumn(false)]
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// User who created the plan
    /// </summary>
    [Display(Name = "Created By")]
    [ScaffoldColumn(false)]
    public string CreatedById { get; set; }

    /// <summary>
    /// Date when the plan was last modified
    /// </summary>
    [Display(Name = "Modified On")]
    [DataType(DataType.DateTime)]
    [ScaffoldColumn(false)]
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// User who last modified the plan
    /// </summary>
    [Display(Name = "Modified By")]
    [ScaffoldColumn(false)]
    public string ModifiedById { get; set; } = string.Empty;
}

public class EnumerationTeamViewModel
{
    /// <summary>
    /// Unique identifier for the enumeration team
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Identifier for the enumeration area this team belongs to
    /// </summary>
    public int EnumerationAreaId { get; set; }
    /// <summary>
    /// Identifier for the enumerator (user)
    /// </summary>
    public string EnumeratorId { get; set; }
    /// <summary>
    /// Indicates if this team member is a supervisor
    /// </summary>
    public bool IsSupervisor { get; set; }

    /// <summary>
    /// Date when the plan was created
    /// </summary>
    [Display(Name = "Created On")]
    [DataType(DataType.DateTime)]
    [ScaffoldColumn(false)]
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// User who created the plan
    /// </summary>
    [Display(Name = "Created By")]
    [ScaffoldColumn(false)]
    public string CreatedById { get; set; }

    /// <summary>
    /// Date when the plan was last modified
    /// </summary>
    [Display(Name = "Modified On")]
    [DataType(DataType.DateTime)]
    [ScaffoldColumn(false)]
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// User who last modified the plan
    /// </summary>
    [Display(Name = "Modified By")]
    [ScaffoldColumn(false)]
    public string ModifiedById { get; set; } = string.Empty;
}