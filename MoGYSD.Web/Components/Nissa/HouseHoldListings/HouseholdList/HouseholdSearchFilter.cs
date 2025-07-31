namespace MoGYSD.Web.Components.Nissa.HouseHoldListings.HouseholdList;

public class HouseholdSearchFilter
{
    public string Name { get; set; } = string.Empty;
    public int? HHListingPlanId { get; set; }
    public int? VillageId { get; set; }
    public int? CommunityCouncilId { get; set; }
    public int? DistrictId { get; set; }
    public int? StatusId { get; set; }
    public string HHHeadName { get; set; }
    public string NationalId { get; set; }

}
