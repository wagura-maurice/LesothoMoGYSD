namespace MoGYSD.Business.Views.HouseHoldListings;

public class HHListingView
{
    public int Id { get; set; }
    public string Guid { get; set; }
    public int HHListingPlanId { get; set; }
    public string HHListingActivityName { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the ID of the District this village belongs to.
    /// </summary>
    public int DistrictId { get; set; }

    /// <summary>
    /// Gets or sets the name of the District this village belongs to.
    /// </summary>
    /// <example>"Northern District"</example>
    public string DistrictName { get; set; }
    /// <summary>
    /// Gets or sets the ID of the parent Community Council this village belongs to.
    /// </summary>
    public int CommunityCouncilId { get; set; }

    /// <summary>
    /// Gets or sets the name of the parent Community Council this village belongs to.
    /// </summary>
    /// <example>"Springfield Community Council"</example>
    public string CommunityCouncilName { get; set; }
    public int VillageId { get; set; }
    public string VillageName { get; set; } = string.Empty;
    public int StatusId { get; set; }
    public string StatusName { get; set; } = string.Empty;
    public string HHHeadFullName { get; set; } = string.Empty;
    public string NationalId { get; set; } = string.Empty;
    public string NationalIDPhoto { get; set; } = string.Empty;
    public int HHSize { get; set; }
    public string GeoCoordinates { get; set; } = string.Empty;
    public string PhysicalAddress { get; set; } = string.Empty;
    public string CreatedById { get; set; } = string.Empty;
    public string CreatedByName { get; set; } = string.Empty;
    public string CreatedByEmail { get; set; } = string.Empty;
    public DateTime? ModifiedOn { get; set; }
    public string ModifiedById { get; set; } = string.Empty;
    public string ModifiedByName { get; set; } = string.Empty;
}