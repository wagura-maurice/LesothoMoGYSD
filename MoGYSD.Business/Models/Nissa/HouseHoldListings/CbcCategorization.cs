using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;

namespace MoGYSD.Business.Models.Nissa.HouseHoldListings;

public class CbcCategorization : BaseAuditableEntity<int>
{
    /// <summary>
    /// Global Unique Identifier uniquely identifying data coming from mobile app
    /// </summary>
    public string Guid { get; set; } = System.Guid.NewGuid().ToString();

    // Foreign Key Relationships:

    /// <summary>
    /// Required relationship: CBCCategorization → CBCActivity (Many-to-One, Mandatory)
    /// Links this categorization to the CBC activity during which it was created
    /// </summary>
    public int CBCActivityId { get; set; }
    public CbcActivity CBCActivity { get; set; }

    /// <summary>
    /// Optional relationship: CBCCategorization → HHListings (Many-to-One, Optional)
    /// Links this categorization to a specific household listing (may be null for general categorizations)
    /// </summary>
    public int? HHListingId { get; set; }
    public HHListing HHListing { get; set; }

    /// <summary>
    /// Required relationship: CBCCategorization → SystemCodeDetail (Many-to-One, Mandatory)
    /// The outcome category assigned during CBC process (e.g., Eligible, Ineligible, Pending Review)
    /// </summary>
    public int CBCOutcomeCategoryId { get; set; }
    public SystemCodeDetail CBCOutcomeCategory { get; set; }

    /// <summary>
    /// Optional relationship: CBCCategorization → SystemCodeDetail (Many-to-One, Optional)
    /// The reason for the outcome category (e.g., Income too high, Missing documents, etc.)
    /// </summary>
    public int? CBCOutcomeCategoryReasonId { get; set; }
    public SystemCodeDetail CBCOutcomeCategoryReason { get; set; }

    // CBC Categorization Details
    public DateTime DateCBC { get; set; }

    public int? ValidatedById { get; set; }
    public SystemCodeDetail ValidatedBy { get; set; }

    public string ValidatedNames { get; set; }
    /// <summary>
    /// Gets or sets the foreign key reference to the plan status in <see cref="SystemCodeDetail"/>.
    /// </summary>
    /// <remarks>
    /// Common statuses: "Draft", "Approved", "InProgress", "Completed"
    /// </remarks>
    public int StatusId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the status <see cref="SystemCodeDetail"/>.
    /// </summary>
    public SystemCodeDetail Status { get; set; }
}
