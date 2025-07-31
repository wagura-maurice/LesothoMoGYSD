namespace MoGYSD.Business.Views.HouseHoldListings;

public class CbcCategorizationView
{
    /// <summary>
    /// Primary key identifier of the CBC categorization record
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Global Unique Identifier uniquely identifying data coming from mobile app
    /// </summary>
    public string Guid { get; set; } = string.Empty;
    /// <summary>
    /// Foreign key reference to the associated CBC activity
    /// </summary>
    public int CBCActivityId { get; set; }
    public string CBCPlanName { get; set; }
    /// <summary>
    /// Date when the CBC categorization was created
    /// </summary>
    public DateTime DateCBC { get; set; }

    public int? HHListingId { get; set; }
    public string HHHeadNames { get; set; } = string.Empty;

    public int? CBCOutcomeCategoryId { get; set; }
    public string CBCOutcomeCategoryName { get; set; } = string.Empty;

    public int? CBCOutcomeCategoryReasonId { get; set; }
    public string CBCOutcomeCategoryReasonName { get; set; } = string.Empty;
    /// <summary>
    /// Timestamp when the record was initially created (audit field)
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// ID of the user who created the record (audit field)
    /// </summary>
    public string CreatedById { get; set; } = string.Empty;

    /// <summary>
    /// Timestamp when the record was last modified (audit field)
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// ID of the user who last modified the record (audit field)
    /// </summary>
    public string ModifiedById { get; set; } = string.Empty;

    /// <summary>
    /// Full name of the creator (from joined User table)
    /// </summary>
    public string CreatedByName { get; set; } = string.Empty;

    /// <summary>
    /// Full name of the last modifier (from joined User table)
    /// </summary>
    public string ModifiedByName { get; set; } = string.Empty;
    public int ValidatedById { get; set; }
    public string ValidatedBy { get; set; } = string.Empty;
    public string ValidatedNames { get; set; } = string.Empty;
    public int? StatusId { get; set; }
    public string StatusName { get; set; } = string.Empty;
}