using MoGYSD.Business.Models.Nissa.HouseHoldListings;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.Business.Views.HouseHoldListings;


/// <summary>
/// SQL View representing Community-Based Committee (CBC) activities with associated location and audit information.
/// This view typically joins the CBC activities table with village, council, district, and user tables.
/// </summary>
public class CbcActivitiesView
{
    /// <summary>
    /// Primary key identifier of the CBC activity record
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Foreign key reference to the associated Household Listing Plan (HHListingPlan)
    /// </summary>
    public int HHListingPlanId { get; set; }
    public string HHListingActivityName { get; set; }

    /// <summary>
    /// Date when the CBC activity was conducted (required)
    /// </summary>
    public DateTime DateCBCConducted { get; set; }

    /// <summary>
    /// Total number of participants in the CBC activity
    /// </summary>
    public int TotalNumberofCBCParticipants { get; set; }

    public int DistrictId { get; set; }
    public int CommunityCouncilId { get; set; }

    /// <summary>
    /// Name of the community council (from joined CommunityCouncil table)
    /// </summary>
    public string CommunityCouncilName { get; set; } = string.Empty;
    //public string CommunityCouncilId { get; set; }

    /// <summary>
    /// Name of the district (from joined District table)
    /// </summary>
    public string DistrictName { get; set; } = string.Empty;
    public int PartnerId { get; set; }
    public string PartnerName { get; set; }

    public int ContactPersonId { get; set; }
    public string ContactPersonName { get; set; }
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
    public int StatusId { get; set; }
    public string StatusName { get; set; } = string.Empty;
    [NotMapped]
    public int VillageCount { get; set; }

}

public class CbcActivityVillageView
{
    public int CbcActivityId { get; set; }
    public int VillageId { get; set; }
    public string VillageName { get; set; }
}