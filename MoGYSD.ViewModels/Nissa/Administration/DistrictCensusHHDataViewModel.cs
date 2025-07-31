using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Nissa.Administration;

/// <summary>
/// Represents census data for a district household in a specific year.
/// </summary>
public class DistrictCensusHHDataViewModel
{
    public int Id { get; set; }
    /// <summary>
    /// The unique identifier of the district.
    /// </summary>
    public int? DistrictId { get; set; }

    /// <summary>
    /// The census year, must be a 4-digit number between 1000 and 9999.
    /// </summary>
    [Range(1000, 9999, ErrorMessage = "Year must be a 4-digit number.")]
    public int? Year { get; set; }

    /// <summary>
    /// Number of households recorded in the census, must be non-negative.
    /// </summary>
    [Range(0, int.MaxValue, ErrorMessage = "HouseholdData must be non-negative.")]
    public int? HouseholdData { get; set; }

    /// <summary>
    /// Population count recorded in the census, must be non-negative.
    /// </summary>
    [Range(0, int.MaxValue, ErrorMessage = "PopulationData must be non-negative.")]
    public int? PopulationData { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedOn { get; set; }
}