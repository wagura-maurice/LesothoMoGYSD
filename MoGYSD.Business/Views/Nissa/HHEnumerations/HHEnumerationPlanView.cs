using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.DistrictRegistrations;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Business.Views.Nissa.HHEnumerations;
public class HHEnumerationPlanView
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public int DistrictId { get; set; }
    public string DistrictName { get; set; } = string.Empty;
    public DateTime ProjectedStartDate { get; set; }
    public DateTime? ProjectedEndDate { get; set; }
    public DateTime ActualStartDate { get; set; }
    public DateTime? ActualEndDate { get; set; }
    public int? StatusId { get; set; }
    public string StatusName { get; set; } = string.Empty;
    public int? RegistrationCentreId { get; set; }
    public string RegistrationCentreName { get; set; } = string.Empty;
    public int? HHListingPlanId { get; set; }
    public string HHListingPlanName { get; set; } = string.Empty;
    //public int? CCRegistrationActivityId { get; set; }
    //public string CCRegistrationActivityName { get; set; } = string.Empty;
    //public int? PlanTypeId { get; set; }
    //public string PlanTypeName { get; set; } = string.Empty;
}

public class EnumerationAreaView
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int HHEnumerationPlanId { get; set; }
    public string HHEnumerationPlanName { get; set; } = string.Empty;
    public int DistrictId { get; set; }
    public string DistrictName { get; set; } = string.Empty;
    public int CommunityCouncilId { get; set; }
    public string CommunityCouncilName { get; set; } = string.Empty;
    public int VillageId { get; set; }
    public string VillageName { get; set; } = string.Empty;
    public int CCRegistrationActivityId { get; set; }
    public string CCRegistrationActivityName { get; set; } = string.Empty;

}

public class EnumerationTeamView
{
    public int Id { get; set; }
    public int HHEnumerationPlanId { get; set; }
    public string HHEnumerationPlanName { get; set; } = string.Empty;
    public int EnumerationAreaId { get; set; }
    public string EnumerationAreaName { get; set; } = string.Empty;
    public string EnumeratorId { get; set; } = string.Empty;
    public string EnumeratorNames { get; set; } = string.Empty;
    public bool IsSupervisor { get; set; }
    public int? DistrictId { get; set; }
    public string DistrictName { get; set; } = string.Empty;
    public int? CommunityCouncilId { get; set; }
    public string CommunityCouncilName { get; set; } = string.Empty;
    public int? VillageId { get; set; }
    public string VillageName { get; set; } = string.Empty;
}

public class EnumeratorsCCView
{
    public string Id { get; set; }
    public string EnumeratorNames { get; set; } = string.Empty;
    public int CCId { get; set; }
    public string CCName { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
}