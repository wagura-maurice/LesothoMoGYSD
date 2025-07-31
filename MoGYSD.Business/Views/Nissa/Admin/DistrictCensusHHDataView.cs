namespace MoGYSD.Business.Views.Nissa.Admin;

/// <summary>
/// Represents census data for a district household in a specific year.
/// </summary>
public class DistrictCensusHHDataView
{
    public int Id { get; set; }
    /// <summary>
    /// The unique identifier of the district.
    /// </summary>
    public int DistrictId { get; set; }

    /// <summary>
    /// Navigation property to the related District entity.
    /// </summary>
    public string DistrictName { get; set; }

    /// <summary>
    /// The census year, must be a 4-digit number between 1000 and 9999.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Number of households recorded in the census, must be non-negative.
    /// </summary>
    public int HouseholdData { get; set; }

    /// <summary>
    /// Population count recorded in the census, must be non-negative.
    /// </summary>
    public int PopulationData { get; set; }
}
