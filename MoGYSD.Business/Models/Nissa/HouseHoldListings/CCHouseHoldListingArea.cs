using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;

namespace MoGYSD.Business.Models.Nissa.HouseHoldListings;

public class CCHouseHoldListingArea : BaseAuditableEntity<int>
{

    /// <summary>
    /// Required relationship: HHListingPlan → CommunityCouncil (Many-to-One, Mandatory)
    /// Identifies the community council where this registration activity is taking place
    /// </summary>
    public int CCId { get; set; }
    public CommunityCouncil CommunityCouncil { get; set; }

    public int HHListingPlanId { get; set; }
    public HHListingPlan HHListingPlan { get; set; }
}