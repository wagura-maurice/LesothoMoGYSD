using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;

namespace MoGYSD.Business.Models.Nissa.HouseHoldListings;

/// <summary>
/// CBCActivities - Stores header information of CBC (Community-Based Categorization) process
/// </summary>
public class CbcActivity : BaseAuditableEntity<int>
{
    // Foreign Key Relationships:

    /// <summary>
    /// Required relationship: CBCActivities → HHListingPlan (Many-to-One, Mandatory)
    /// Links this CBC activity to the household listing plan it belongs to
    /// </summary>
    public int HHListingPlanId { get; set; }
    public HHListingPlan HHListingPlan { get; set; }

    // CBC Activity Details
    public DateTime DateCBCConducted { get; set; }
    public int? TotalNumberofCBCParticipants { get; set; }

    public int PartnerId { get; set; }
    public Partner Partner { get; set; }

    public int ContactPersonId { get; set; }
    public ContactPerson ContactPerson { get; set; }

    public int CommunityCouncilId { get; set; }
    public CommunityCouncil CommunityCouncil { get; set; }

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

    /// <summary>
    /// One-to-Many: CBCActivities → CbcCategorization
    /// All categorizations made during this CBC activity
    /// </summary>
    public virtual ICollection<CbcCategorization> CbcCategorizations { get; set; } = new List<CbcCategorization>();
    // Navigation property to join entity
    public ICollection<CbcActivityVillage> CbcActivityVillages { get; set; }
}


public class CbcActivityVillage
{
    public int CbcActivityId { get; set; }
    public CbcActivity CbcActivity { get; set; }
    public int VillageId { get; set; }
    public Village Village { get; set; }
}