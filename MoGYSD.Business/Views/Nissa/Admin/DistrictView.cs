namespace MoGYSD.Business.Views.Nissa.Admin;

public class DistrictView
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public int CountryId { get; set; }
    public int? CensusYear { get; set; }
    public int? CensusHouseholdData { get; set; }
    public int? CensusPopulationData { get; set; }
}