namespace MoGYSD.Web.Components.HouseHoldListings.CBCActivities;
public class CBCActivitySearchFilter
{
    public string Name { get; set; } = string.Empty;
    public int? DistrictId { get; set; }
    public int? CommunityCouncilId { get; set; }
    public int? PartnerId { get; set; }

}
public class VillageSelect
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TotalNumberofCBCParticipants { get; set; }
    public bool IsSelected { get; set; } = false;
}