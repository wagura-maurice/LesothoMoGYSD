namespace MoGYSD.Web.Components.DistrictRegistrations;
public class DistrictRegistrationSearchFilter
{
    public int? MasterRegistrationPlanId { get; set; }
    public int? DistrictId { get; set; }
    public int? StatusId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal? ApprovedBudgetAmount { get; set; }

}
