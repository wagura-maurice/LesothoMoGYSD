namespace MoGYSD.Business.Views.HouseHoldListings;
/// <summary>
/// Represents a view entity for Housing/Household (HH) listing plans with additional 
/// descriptive information and audit fields.
/// This is typically mapped to a SQL database view that joins multiple related tables.
/// </summary>
public class HHListingPlanView
{
    /// <summary>
    /// Primary key identifier for the listing plan record
    /// </summary>
    public int Id { get; set; }
    public string HHListingActivityName { get; set; } = string.Empty;

    public int? DistrictId { get; set; }
    public string? DistrictName { get; set; } = string.Empty;

    public int? DistrictRegistrationPlanId { get; set; }
    public string? DistrictRegistrationPlanName { get; set; } = string.Empty;
    public string? MasterRegistrationPlanName { get; set; } = string.Empty;
    public int? ExpectedNoHouseholds { get; set; }
    public int? PartnersId { get; set; }
    public string? PartnerName { get; set; } = string.Empty;
    public int? ContactPersonId { get; set; }
    public string? ContactPersonName { get; set; } = string.Empty;
    /// <summary>
    /// Current status identifier of the listing plan
    /// </summary>
    public int StatusId { get; set; }

    /// <summary>
    /// Descriptive name of the current status
    /// </summary>
    public string StatusName { get; set; } = string.Empty;

    /// <summary>
    /// Projected start date of the listing plan (nullable)
    /// </summary>
    public DateTime? ProjectedStartDate { get; set; }

    /// <summary>
    /// Projected end date of the listing plan (nullable)
    /// </summary>
    public DateTime? ProjectedEndDate { get; set; }

    /// <summary>
    /// Actual start date when implementation began (nullable)
    /// </summary>
    public DateTime? ActualStartDate { get; set; }

    /// <summary>
    /// Actual completion date (nullable)
    /// </summary>
    public DateTime? ActualEndDate { get; set; }

    /// <summary>
    /// Date when the record was initially created
    /// </summary>
    public DateTime? CreatedOn { get; set; }

    /// <summary>
    /// ID of the user who created the record
    /// </summary>
    public string CreatedById { get; set; } = string.Empty;
    public string CreatedByName { get; set; } = string.Empty;
    public string CreatedByEmail { get; set; } = string.Empty;
    public DateTime? ModifiedOn { get; set; }
    public string ModifiedById { get; set; } = string.Empty;
    public string ModifiedByName { get; set; } = string.Empty;
    public int DataCollectionTypeId { get; set; }
    public string DataCollectionTypeName { get; set; } = string.Empty;
}
