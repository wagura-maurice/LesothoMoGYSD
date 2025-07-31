namespace MoGYSD.Business.Views.Nissa.Districtregistrations;
/// <summary>
/// Represents a comprehensive view of district registration plan information including
/// master plan association, budget details, and timeline tracking for planning and reporting.
/// </summary>
public class DistrictRegistrationPlanView
{
    /// <summary>
    /// Gets or sets the unique identifier for the district registration plan.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the master registration plan.
    /// </summary>
    public int MasterRegistrationPlanId { get; set; }

    /// <summary>
    /// Gets or sets the name of the associated master registration plan.
    /// </summary>
    public string MasterRegistrationName { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the target district.
    /// </summary>
    public int DistrictId { get; set; }

    /// <summary>
    /// Gets or sets the name of the target district.
    /// </summary>
    public string DistrictName { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the plan status.
    /// </summary>
    public int StatusId { get; set; }

    /// <summary>
    /// Gets or sets the name of the plan status (e.g., "Draft", "In Progress").
    /// </summary>
    public string StatusName { get; set; }

    /// <summary>
    /// Gets or sets the name of the district registration plan.
    /// </summary>
    public string RegistrationPlanName { get; set; }

    /// <summary>
    /// Gets or sets the detailed description of the registration plan.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the approved budget amount for the registration activities.
    /// </summary>
    public decimal ApprovedBudgetAmount { get; set; }

    /// <summary>
    /// Gets or sets the expected number of households to be registered.
    /// </summary>
    public int ExpectedNoHouseholds { get; set; }

    /// <summary>
    /// Gets or sets the planned start date for registration activities.
    /// </summary>
    public DateTime? ProjectedStartDate { get; set; }

    /// <summary>
    /// Gets or sets the planned completion date for registration activities.
    /// </summary>
    public DateTime? ProjectedEndDate { get; set; }

    /// <summary>
    /// Gets or sets the actual start date of registration activities.
    /// </summary>
    public DateTime? ActualStartDate { get; set; }

    /// <summary>
    /// Gets or sets the actual completion date of registration activities.
    /// </summary>
    public DateTime? ActualEndDate { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the plan was created.
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who created this plan.
    /// </summary>
    public string CreatedById { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who created this plan.
    /// </summary>
    public string CreatedByName { get; set; }

    /// <summary>
    /// Gets or sets the email of the user who created this plan.
    /// </summary>
    public string CreatedByEmail { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the plan was last modified.
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who last modified this plan.
    /// </summary>
    public string ModifiedById { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who last modified this plan.
    /// </summary>
    public string ModifiedByName { get; set; }

    /// <summary>Identifier for the type of data collection.</summary>
    public int DataCollectionTypeId { get; set; }

    /// <summary>Name of the data collection type.</summary>
    public string DataCollectionTypeName { get; set; }
}
